
using DemoApplication.WebAPI.DatabaseContext;
using DemoApplication.WebAPI.DatabaseSeeder;
using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.ServiceConfiguration;
using DemoApplication.WebAPI.Services;
using DemoApplication.WebAPI.Services.ObjectMapping;
using DemoApplication.WebAPI.Shared.Contracts;
using DemoApplication.WebAPI.Shared.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<ApplicationDbContext>(options => {
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

//builder.Services.AddScoped<IDateTimeService, DateTimeService>();
//builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

//builder.Services.AddScoped<EmployeeSeeder>();
//builder.Services.AddScoped<DepartmentSeeder>();

//builder.Services.AddScoped<IEmployeeService,EmployeeService>();
//builder.Services.AddScoped<IEmployeeMappingService, EmployeeMapping>();

//builder.Services.AddScoped<ICustomMapper, CustoMapper>();

builder.Services.AddMappingConfiguration();
builder.Services.AddServiceConfiguration(builder.Configuration);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddept")
    SeedDepartmentData(app);

if (args.Length == 1 && args[0].ToLower() == "seedemp")
    SeedEmployeeData(app);

void SeedDepartmentData(IHost app)
{
    var scopeFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopeFactory.CreateScope()) {

        var department = scope.ServiceProvider.GetService<DepartmentSeeder>();

        department.Seed();     
 
    }

};

void SeedEmployeeData(IHost app)
{
    var scopeFactory = app.Services.GetService<IServiceScopeFactory>();
  

    using (var scope = scopeFactory.CreateScope())
    {
        var employee = scope.ServiceProvider.GetService<EmployeeSeeder>();

        employee.Seed();

    }

};
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
