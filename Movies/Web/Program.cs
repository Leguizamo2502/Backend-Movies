using Entity.Domain.Config;
using Entity.DTOs.Auth.User.Create;
using Entity.Validations.Interfaces;
using Entity.Validations.Modules.Auth.User;
using Entity.Validations.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Web.Middleware;
using Web.ProgramService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Jwt
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddCustomCors(builder.Configuration);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.Configure<CookieSettings>(builder.Configuration.GetSection("Cookie"));

//Validations
builder.Services.AddScoped<IValidatorService, ValidatorService>();
builder.Services.AddValidatorsFromAssemblyContaining<UserCreateValidatorDto>();
builder.Services.AddFluentValidationAutoValidation();

//Services 
builder.Services.AddApplicationServices();
builder.Services.AddSwaggerWithJwt();
builder.Services.AddDatabase(builder.Configuration);



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//MigrationManager.MigrateAllDatabases(app.Services, builder.Configuration);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors();

app.UseAuthorization();

app.UseMiddleware<DbContextMiddleware>();

app.MapControllers();

app.Run();
