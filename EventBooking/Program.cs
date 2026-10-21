using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Event booking v1",
        Contact = new OpenApiContact
        { 
           Name = "Atul Pathrikar",
           Email= "Pathrikaratul7@gmail.com",
         //  Url = new Uri("Https://")
        
        },
        Description = "This is Event booking App",
       // TermsOfService  = new Uri("Https://")
        
    });

});




// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseSwagger();
app.MapSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
