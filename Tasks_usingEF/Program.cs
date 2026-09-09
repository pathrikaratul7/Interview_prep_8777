using Microsoft.OpenApi;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using System.Linq.Expressions;
using System.Xml;
using Tasks_usingEF.Database;
using Microsoft.EntityFrameworkCore;
using Tasks_usingEF.InterfaceService;
using Tasks_usingEF.RepositoryService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(SwagOption =>
{

    SwagOption.SwaggerDoc("v1", new OpenApiInfo()
    {

        Title = "This App is created for testing",
        Version = "v1",
        Description = "ASP.NET CORE WEB API APPLICATION 9.0",

        Contact = new OpenApiContact()
        {
            Name = "Atul & Saee 8777",
            Email = "Pathrikaratul7@gmail.com",
            Extensions = new Dictionary<string, IOpenApiExtension>()
            {

            },
            Url = new Uri("https://www.linkedin.com/in/pathrikaratul7/"),

        },
        License = new OpenApiLicense()
        {

            Extensions = new Dictionary<string, IOpenApiExtension>()
            {


            },
           
            Name = "SWAGGER UI",
            Url = new Uri("https://www.linkedin.com/in/pathrikaratul7/")
        },
       // Summary = "Learn this using swagger",
        TermsOfService = new Uri("https://www.linkedin.com/in/pathrikaratul7/")

    });


});
builder.Services.AddScoped<IDivision, DivRepo>();
var app = builder.Build();
app.MapSwagger();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
