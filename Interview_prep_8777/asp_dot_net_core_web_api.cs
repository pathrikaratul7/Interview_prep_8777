using System;

namespace Interview_prep_8777
{
    public class AspDotNetCoreWebApi
    {
        #region 1. What is ASP.NET Core Web API?

        /*
         * ASP.NET Core Web API is a framework used to build RESTful HTTP services.
         *
         * Banking Example:
         *
         * GET /api/account/1001
         *
         * Response:
         * {
         *    "accountNo":1001,
         *    "customerName":"Saee P",
         *    "balance":25000
         * }
         */

        #endregion

        #region 2. What is REST API?

        /*
         * REST = Representational State Transfer
         *
         * HTTP Methods
         *
         * GET    -> Retrieve data
         * POST   -> Create data
         * PUT    -> Update entire resource
         * PATCH  -> Partial update
         * DELETE -> Delete resource
         *
         * Banking Example
         *
         * GET    /api/accounts
         * POST   /api/accounts
         * PUT    /api/accounts/5
         * DELETE /api/accounts/5
         */

        #endregion

        #region 3. Explain Middleware

        /*
         * Middleware executes on every HTTP request.
         *
         * Pipeline
         *
         * Client
         *   ↓
         * Authentication
         *   ↓
         * Authorization
         *   ↓
         * Logging
         *   ↓
         * Exception Handling
         *   ↓
         * Controller
         *   ↓
         * Response
         *
         * app.UseAuthentication();
         * app.UseAuthorization();
         * app.MapControllers();
         */

        #endregion

        #region 4. Dependency Injection (DI)

        /*
         * DI means supplying required objects from outside.
         *
         * Without DI
         *
         * public class AccountController
         * {
         *      AccountService service = new AccountService();
         * }
         *
         * With DI
         *
         * public class AccountController
         * {
         *      private readonly IAccountService service;
         *
         *      public AccountController(IAccountService service)
         *      {
         *          this.service = service;
         *      }
         * }
         *
         * Registration
         *
         * builder.Services.AddScoped<IAccountService, AccountService>();
         */

        #endregion

        #region 5. Singleton vs Scoped vs Transient

        /*
         * Singleton
         * ----------
         * One instance for the entire application.
         *
         * builder.Services.AddSingleton<ILogService, LogService>();
         *
         * Used for:
         * Logging
         * Configuration
         * Cache
         *
         * Scoped
         * -------
         * One instance per HTTP Request.
         *
         * builder.Services.AddScoped<IAccountService, AccountService>();
         *
         * Transient
         * ----------
         * New instance every time.
         *
         * builder.Services.AddTransient<IEmailService, EmailService>();
         */

        #endregion

        #region 6. Routing

        /*
         * [ApiController]
         * [Route("api/[controller]")]
         *
         * [HttpGet]
         * GET /api/account
         *
         * [HttpGet("{id}")]
         * GET /api/account/101
         */

        #endregion

        #region 7. IActionResult

        /*
         * return Ok(customer);         //200
         * return BadRequest();         //400
         * return Unauthorized();       //401
         * return NotFound();           //404
         * return StatusCode(500);      //500
         */

        #endregion

        #region 8. IActionResult vs ActionResult<T>

        /*
         * IActionResult
         *
         * public IActionResult Get()
         *
         * Can return:
         * Ok()
         * BadRequest()
         * NotFound()
         *
         * ActionResult<Customer>
         *
         * public ActionResult<Customer> Get()
         *
         * Returns Customer or NotFound().
         */

        #endregion

        #region 9. Model Binding

        /*
         * JSON
         *
         * {
         *    "name":"Saee P",
         *    "age":22
         * }
         *
         * Converts automatically into
         *
         * public class Customer
         * {
         *      public string Name { get; set; }
         *      public int Age { get; set; }
         * }
         */

        #endregion

        #region 10. Model Validation

        /*
         * public class Customer
         * {
         *      [Required]
         *      public string Name { get; set; }
         *
         *      [Range(18,60)]
         *      public int Age { get; set; }
         * }
         *
         * if(!ModelState.IsValid)
         * {
         *      return BadRequest(ModelState);
         * }
         */

        #endregion

        #region 11. Authentication vs Authorization

        /*
         * Authentication
         * ----------------
         * Authentication means verifying the identity of the user.
         *
         * Question:
         * Who are you?
         *
         * Examples:
         * - Username & Password
         * - OTP
         * - JWT Token
         * - Fingerprint
         * - Face ID
         *
         * Banking Example:
         *
         * User enters:
         * Username : Rahul
         * Password : ****** 
         *
         * Server verifies the credentials.
         *
         * If valid → User is authenticated.
         *
         *
         * Authorization
         * ----------------
         * Authorization means verifying what the authenticated user is allowed to do.
         *
         * Question:
         * What are you allowed to access?
         *
         * Banking Example:
         *
         * Admin
         * - Create Account
         * - Delete Account
         * - View All Customers
         *
         * Customer
         * - View Own Account
         * - Transfer Money
         * - Cannot Delete Customer
         *
         * Attributes
         *
         * [Authorize]
         *
         * [Authorize(Roles="Admin")]
         *
         * Interview Answer:
         * Authentication verifies identity.
         * Authorization verifies permissions.
         */

        #endregion

        #region 12. JWT (JSON Web Token)

        /*
         * JWT stands for JSON Web Token.
         *
         * It is used for secure authentication between Client and Server.
         *
         * JWT Structure
         *
         * Header
         * Payload
         * Signature
         *
         * Flow
         *
         * Client Login
         *      ↓
         * API Validates Username & Password
         *      ↓
         * JWT Generated
         *      ↓
         * Client Stores Token
         *      ↓
         * Client Sends Token
         *
         * Authorization : Bearer Token
         *
         * API validates the token.
         *
         * Example
         *
         * Authorization:
         * Bearer eyJhbGciOiJIUzI1NiIs...
         *
         * Advantages
         *
         * Stateless
         * Secure
         * Faster
         * No Session Required
         */

        #endregion

        #region 13. CORS

        /*
         * CORS = Cross-Origin Resource Sharing
         *
         * Browser blocks requests between different origins.
         *
         * Example
         *
         * React
         * http://localhost:3000
         *
         * API
         * https://localhost:5001
         *
         * Browser blocks the request.
         *
         * Enable CORS
         *
         * builder.Services.AddCors(options =>
         * {
         *     options.AddPolicy("AllowReact",
         *         builder =>
         *         {
         *             builder.AllowAnyOrigin()
         *                    .AllowAnyHeader()
         *                    .AllowAnyMethod();
         *         });
         * });
         *
         * app.UseCors("AllowReact");
         *
         * Interview Answer:
         * CORS allows APIs to accept requests from different domains.
         */

        #endregion

        #region 14. Swagger

        /*
         * Swagger is used to generate API documentation.
         *
         * Features
         *
         * - API Documentation
         * - API Testing
         * - Request & Response
         * - Endpoint Details
         *
         * URL
         *
         * https://localhost:5001/swagger
         *
         * Configuration
         *
         * builder.Services.AddEndpointsApiExplorer();
         *
         * builder.Services.AddSwaggerGen();
         *
         * app.UseSwagger();
         *
         * app.UseSwaggerUI();
         *
         * Interview Answer:
         * Swagger provides interactive API documentation and allows testing APIs without Postman.
         */

        #endregion

        #region 15. PUT vs PATCH

        /*
         * PUT
         *
         * Updates the complete object.
         *
         * Example
         *
         * Customer
         * Name
         * Mobile
         * Address
         *
         * Entire object is sent.
         *
         *
         * PATCH
         *
         * Updates only selected fields.
         *
         * Example
         *
         * Only Mobile Number.
         *
         * PUT Example
         *
         * PUT /api/customer/10
         *
         * {
         *   "Name":"Rahul",
         *   "Mobile":"9999999999",
         *   "Address":"Pune"
         * }
         *
         * PATCH Example
         *
         * PATCH /api/customer/10
         *
         * {
         *   "Mobile":"8888888888"
         * }
         */

        #endregion

        #region 16. Filters

        /*
         * Filters execute before or after controller actions.
         *
         * Types
         *
         * 1. Authorization Filter
         * 2. Resource Filter
         * 3. Action Filter
         * 4. Exception Filter
         * 5. Result Filter
         *
         * Example
         *
         * public class LogFilter : ActionFilterAttribute
         * {
         *     public override void OnActionExecuting(ActionExecutingContext context)
         *     {
         *         Console.WriteLine("Before Action");
         *     }
         *
         *     public override void OnActionExecuted(ActionExecutedContext context)
         *     {
         *         Console.WriteLine("After Action");
         *     }
         * }
         *
         * Usage
         *
         * [LogFilter]
         * public IActionResult Get()
         * {
         * }
         */

        #endregion

        #region 17. Exception Handling

        /*
         * Global Exception Handling
         *
         * app.UseExceptionHandler("/error");
         *
         * OR
         *
         * Custom Middleware
         *
         * try
         * {
         *     // Business Logic
         * }
         * catch(Exception ex)
         * {
         *     // Log Exception
         *     // Return 500
         * }
         *
         * Benefits
         *
         * Centralized Exception Handling
         * Logging
         * Clean Code
         * Better Security
         */

        #endregion

        #region 18. Repository Pattern

        /*
         * Repository Pattern separates database logic from business logic.
         *
         * Architecture
         *
         * Controller
         *      ↓
         * Service
         *      ↓
         * Repository
         *      ↓
         * SQL Server
         *
         * Repository Interface
         *
         * public interface ICustomerRepository
         * {
         *     List<Customer> GetAll();
         * }
         *
         * Repository
         *
         * public class CustomerRepository : ICustomerRepository
         * {
         * }
         *
         * Advantages
         *
         * Loose Coupling
         * Easy Unit Testing
         * Reusable Code
         */

        #endregion

        #region 18. Repository Pattern

        /*
         * Repository Pattern
         * ==================
         *
         * Repository Pattern is a design pattern that separates
         * Business Logic from Data Access Logic.
         *
         * It acts as a middle layer between the Service Layer and Database.
         *
         * Architecture
         *
         * Controller
         *      ↓
         * Service
         *      ↓
         * Repository
         *      ↓
         * SQL Server
         *
         * OR
         *
         * Controller
         *      ↓
         * Repository
         *      ↓
         * Database
         *
         * Repository is responsible only for Database Operations.
         *
         * -------------------------------------------------------
         * Why do we use Repository Pattern?
         * -------------------------------------------------------
         *
         * 1. Loose Coupling
         *
         * Controller doesn't know how data is fetched.
         *
         * 2. Separation of Concerns
         *
         * Business Logic and Database Logic remain separate.
         *
         * 3. Easy Unit Testing
         *
         * We can mock the Repository.
         *
         * 4. Reusable Code
         *
         * Database code is written once and reused.
         *
         * 5. Easy Maintenance
         *
         * Database changes affect only Repository.
         *
         * -------------------------------------------------------
         * Without Repository Pattern
         * -------------------------------------------------------
         *
         * Controller
         *     ↓
         * SQL Query
         *
         * public class CustomerController : ControllerBase
         * {
         *     public IActionResult GetCustomers()
         *     {
         *         SqlConnection con = new SqlConnection();
         *
         *         SqlCommand cmd = new SqlCommand();
         *
         *         // SQL Logic
         *
         *         return Ok();
         *     }
         * }
         *
         * Problems
         *
         * ❌ Controller contains SQL
         * ❌ Hard to Maintain
         * ❌ Difficult Unit Testing
         * ❌ High Coupling
         *
         * -------------------------------------------------------
         * With Repository Pattern
         * -------------------------------------------------------
         *
         * Controller
         *      ↓
         * Repository Interface
         *      ↓
         * Repository
         *      ↓
         * SQL Server
         *
         * -------------------------------------------------------
         * Step 1 : Create Model
         * -------------------------------------------------------
         *
         * public class Customer
         * {
         *     public int Id { get; set; }
         *     public string Name { get; set; }
         * }
         *
         * -------------------------------------------------------
         * Step 2 : Create Repository Interface
         * -------------------------------------------------------
         *
         * public interface ICustomerRepository
         * {
         *     List<Customer> GetAllCustomers();
         *
         *     Customer GetCustomerById(int id);
         *
         *     void AddCustomer(Customer customer);
         *
         *     void UpdateCustomer(Customer customer);
         *
         *     void DeleteCustomer(int id);
         * }
         *
         * -------------------------------------------------------
         * Step 3 : Implement Repository
         * -------------------------------------------------------
         *
         * public class CustomerRepository : ICustomerRepository
         * {
         *     public List<Customer> GetAllCustomers()
         *     {
         *         // SQL Query / EF Core
         *     }
         *
         *     public Customer GetCustomerById(int id)
         *     {
         *     }
         *
         *     public void AddCustomer(Customer customer)
         *     {
         *     }
         *
         *     public void UpdateCustomer(Customer customer)
         *     {
         *     }
         *
         *     public void DeleteCustomer(int id)
         *     {
         *     }
         * }
         *
         * -------------------------------------------------------
         * Step 4 : Register Repository
         * -------------------------------------------------------
         *
         * builder.Services.AddScoped<ICustomerRepository,
         *                            CustomerRepository>();
         *
         * -------------------------------------------------------
         * Step 5 : Inject Repository
         * -------------------------------------------------------
         *
         * public class CustomerController : ControllerBase
         * {
         *     private readonly ICustomerRepository repository;
         *
         *     public CustomerController(ICustomerRepository repository)
         *     {
         *         this.repository = repository;
         *     }
         *
         *     [HttpGet]
         *     public IActionResult GetCustomers()
         *     {
         *         var customers = repository.GetAllCustomers();
         *
         *         return Ok(customers);
         *     }
         * }
         *
         * -------------------------------------------------------
         * Banking Example
         * -------------------------------------------------------
         *
         * AccountController
         *        ↓
         * IAccountRepository
         *        ↓
         * AccountRepository
         *        ↓
         * SQL Server
         *
         * AccountController
         *
         * public class AccountController : ControllerBase
         * {
         *     private readonly IAccountRepository repository;
         *
         *     public AccountController(IAccountRepository repository)
         *     {
         *         this.repository = repository;
         *     }
         *
         *     [HttpGet("{accountNo}")]
         *     public IActionResult GetAccount(int accountNo)
         *     {
         *         return Ok(repository.GetAccount(accountNo));
         *     }
         * }
         *
         * Repository
         *
         * public interface IAccountRepository
         * {
         *     Account GetAccount(int accountNo);
         *
         *     void UpdateBalance(Account account);
         * }
         *
         * AccountRepository
         *
         * public class AccountRepository : IAccountRepository
         * {
         *     // SQL / EF Core Logic
         * }
         *
         * -------------------------------------------------------
         * Repository Pattern Advantages
         * -------------------------------------------------------
         *
         * ✔ Loose Coupling
         *
         * ✔ Separation of Concerns
         *
         * ✔ Easy Unit Testing
         *
         * ✔ Easy Maintenance
         *
         * ✔ Reusable Code
         *
         * ✔ Cleaner Controllers
         *
         * ✔ Easy to Replace Database
         *
         * -------------------------------------------------------
         * Repository Pattern Disadvantages
         * -------------------------------------------------------
         *
         * Extra Layer
         *
         * More Classes
         *
         * Can become unnecessary when EF Core DbContext already
         * provides Repository + Unit of Work functionality.
         *
         * -------------------------------------------------------
         * Repository Pattern vs Service Pattern
         * -------------------------------------------------------
         *
         * Repository
         *
         * Database Operations
         *
         * CRUD
         *
         * SQL
         *
         * EF Core
         *
         *
         * Service
         *
         * Business Logic
         *
         * Validation
         *
         * Rules
         *
         * Transactions
         *
         *
         * Architecture
         *
         * Controller
         *      ↓
         * Service
         *      ↓
         * Repository
         *      ↓
         * Database
         *
         * -------------------------------------------------------
         * Interview Question
         * -------------------------------------------------------
         *
         * Q. Why do we use Repository Pattern?
         *
         * Answer:
         *
         * Repository Pattern separates the Data Access Layer from
         * the Business Layer. It provides loose coupling, improves
         * maintainability, enables unit testing, and keeps
         * controllers clean by moving database operations into
         * dedicated repository classes.
         *
         */

        #endregion

        #region 19. AddControllers vs AddMvc vs AddControllersWithViews

        /*
         * AddControllers()
         *
         * Used only for Web API.
         *
         *
         * AddControllersWithViews()
         *
         * Used for MVC Applications.
         *
         *
         * AddMvc()
         *
         * Supports
         *
         * MVC
         * Razor
         * Web API
         *
         * Interview Answer
         *
         * Web API → AddControllers()
         *
         * MVC Website → AddControllersWithViews()
         */

        #endregion

        #region 20. Request Lifecycle

        /*
         * Client
         *    ↓
         * Middleware
         *    ↓
         * Routing
         *    ↓
         * Authentication
         *    ↓
         * Authorization
         *    ↓
         * Model Binding
         *    ↓
         * Validation
         *    ↓
         * Controller
         *    ↓
         * Service
         *    ↓
         * Repository
         *    ↓
         * SQL Server
         *    ↓
         * JSON Response
         */

        #endregion

        #region 21. Banking Transaction API Design

        /*****************************
         POST /api/transaction/transfer

         Request

         {
             "fromAccount":1001,
             "toAccount":1002,
             "amount":500
         }

         Flow

         Validate JWT
                ↓
         Validate Accounts
                ↓
         Check Balance
                ↓
         Begin SQL Transaction
                ↓
         Debit Sender
                ↓
         Credit Receiver
                ↓
         Commit Transaction
                ↓
         Return Success

         ******************************/

        #endregion

        #region 22. HTTP Status Codes

        /*
         * 200 OK
         * Request Successful
         *
         * 201 Created
         * Resource Created
         *
         * 204 No Content
         * No Data Returned
         *
         * 400 Bad Request
         * Invalid Input
         *
         * 401 Unauthorized
         * Authentication Failed
         *
         * 403 Forbidden
         * User Has No Permission
         *
         * 404 Not Found
         * Resource Doesn't Exist
         *
         * 409 Conflict
         * Duplicate Record
         *
         * 500 Internal Server Error
         * Unexpected Server Error
         */

        #endregion

        #region 23. .NET Framework vs ASP.NET Core

        /*
         * .NET Framework
         * -----------------------
         * Windows Only
         * System.Web
         * IIS Hosting
         * Limited Dependency Injection
         * Slower Startup
         *
         *
         * ASP.NET Core
         * -----------------------
         * Cross Platform
         * Lightweight
         * Built-in Dependency Injection
         * Middleware Pipeline
         * Kestrel + IIS + Docker + Linux
         * Faster Performance
         *
         * Interview Answer:
         * ASP.NET Core is modern, cross-platform, high-performance, and supports built-in dependency injection.
         */

        #endregion

        #region 24. Banking Interview Questions

        /*
         * Q1. How do you secure a Money Transfer API?
         *
         * Answer
         *
         * 1. JWT Authentication
         * 2. Authorization
         * 3. Validate Request
         * 4. Verify Account Ownership
         * 5. Check Available Balance
         * 6. SQL Transaction
         * 7. Log Transaction
         * 8. Return Proper Status Codes
         *
         *
         * Q2. Why use SQL Transactions?
         *
         * Debit and Credit should succeed together.
         *
         * If Debit succeeds and Credit fails,
         * Rollback the transaction.
         *
         *
         * Q3. Why use Dependency Injection?
         *
         * Loose Coupling
         * Easy Unit Testing
         * Easy Maintenance
         */

        #endregion

        #region 25. Important Interview Revision Topics

        /*
         * ASP.NET Core Web API
         * REST API
         * Middleware
         * Dependency Injection
         * Singleton
         * Scoped
         * Transient
         * Routing
         * Model Binding
         * Model Validation
         * Authentication
         * Authorization
         * JWT
         * Swagger
         * CORS
         * Filters
         * Exception Handling
         * Repository Pattern
         * HTTP Status Codes
         * ActionResult vs IActionResult
         * PUT vs PATCH
         * API Versioning
         * Logging
         * Async / Await
         * SQL Transactions
         * Stored Procedures
         * Indexes
         * Pagination
         * Caching
         * Performance Optimization
         *
         * These are the most frequently asked topics in ASP.NET Core Web API interviews.
         */

        #endregion
    }
}