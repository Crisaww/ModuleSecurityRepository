using Business.Implements;
using Business.Interfaces;
using Data.Implements;
using Data.Interfaces;
using Entity.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Configura DbContext con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection")));

// Add services to the container.
//Configuraci�n Data I.S
builder.Services.AddScoped<ICityData, CityData>();
builder.Services.AddScoped<ICountryData, CountryData>();
builder.Services.AddScoped<IModuleData, ModuleData>();
builder.Services.AddScoped<IPersonData, PersonData>();
builder.Services.AddScoped<IRoleData, RoleData>();
builder.Services.AddScoped<IRoleViewData, RoleViewData>();
builder.Services.AddScoped<IStateData, StateData>();
builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<IUserRoleData, UserRoleData>();
builder.Services.AddScoped<IViewData, ViewData>();

//Configuraci�n de Business I.S
builder.Services.AddScoped<ICityBusiness, CityBusiness>();
builder.Services.AddScoped<ICountryBusiness, CountryBusiness>();
builder.Services.AddScoped<IModuleBusiness, ModuleBusiness>();
builder.Services.AddScoped<IPersonBusiness, PersonBusiness>();
builder.Services.AddScoped<IRoleBusiness, RoleBusiness>();
builder.Services.AddScoped<IRoleViewBusiness, RoleViewBusiness>();
builder.Services.AddScoped<IStateBusiness, StateBusiness>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IUserRoleBusiness, UserRoleBusiness>();
builder.Services.AddScoped<IViewBusiness, ViewBusiness>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


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


