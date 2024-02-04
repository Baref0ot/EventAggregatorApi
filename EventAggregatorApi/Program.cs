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



using Microsoft.EntityFrameworkCore;
using EventAggregatorApi.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
