// Add: Dependencies: EntityFrameworkCore, EntityFrameworkCore.SqlServer, EntityFrameworkCore.Design, EntityFrameworkCore.Tools, EntityFrameworkCore.InMemory (for unit testing and Moq dbs)
// Install: SqlServer on machine
// Install: SSMS on machine
// Connect: to server via SSMS and Create Database
// Add: ConnectionStrings property with db connection string to appsettings.json file 
// Add: Usings for Entity Framework
// Create: project Folder structure (Controllers, Services, Models, DTOs, Interfaces, Repositories, Data)
// Create: Test Project for unit Test
// Add: AppDbContext.cs file for DBSets<> in "Data"
// Configure: DB Services to AddDbContext so that your AppDbContext uses your sql server database in Program.cs
// Define: your model/entity classes in "Models"
// Add: DBSet<ModelName> for entities you've defined in "Data
// Create: Migration "Add-Migration InitalCreate" via package manager console
// Ensure: A valid SSL certificate is obtained from a certified authority fo production application and the sql server it will be talking to
    /* if development or testing environment is used, you can add "TrustServerCertificate=True" to your connection string to bypass SSL.*/
// Apply: Apply the migration to your database "Update-database"
// Create: API Controllers
// Register: di your dependicies via constructor injection and register in Program.cs
// Register: your a HttpClient with a client baseAddress URI and client DefaultRequestHeaders for Authorization with API Keys
// Use: Use your named HttpClient in your service by requesting it from IHttpClientFactory
// Impliment: Your GET Request method to Get API data using the named client



using Microsoft.EntityFrameworkCore;
using EventAggregatorApi.Data;
using EventAggregatorApi.Services;
using EventAggregatorApi.Interfaces;
using EventAggregatorApi.Repositories;


var builder = WebApplication.CreateBuilder(args);
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddHttpClient();
builder.Services.AddScoped<IEventBriteEventService, EventBriteEventService>();
builder.Services.AddScoped<IEventBriteEventRepository, EventBriteEventRepository>();

builder.Services.AddHttpClient("EventBriteClient", client => {
    client.BaseAddress = new Uri("https://www.eventbriteapi.com/v3/");
    client.DefaultRequestHeaders.Add("Authorization", "");

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
