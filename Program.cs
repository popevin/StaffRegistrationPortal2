using AutoMapper;
using StaffApplication2.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using System.Text;
using StaffApplication2.DTOs;
using Newtonsoft.Json;


var config = new ConfigurationBuilder();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Host.UseSerilog();

// Register services

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddHttpClient();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();


/*builder.Services.AddHttpClient<IUserService, UserService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7117");
});
*/



// Read JWT configuration from appsettings.json
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var jwtSettings = configuration.GetSection("Jwt");

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Staff Registration WebApi", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Jwt authorization header using bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    }, new List<string>()
                }}
    );
});


try
{
    Log.Information("Application starting up");
    var app = builder.Build();

    // Add UseExceptionHandler middleware
    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("An unexpected error occurred.");
        });
    });

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
        app.UseHsts();
    if (app.Environment.IsDevelopment())
        app.UseDeveloperExceptionPage();


    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Parkway.MPGS.WebApi v1"));

    app.UseHttpsRedirection();

    app.UseSerilogRequestLogging();

    app.UseRouting();

    app.UseCors(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

    var forwardOptions = new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
        RequireHeaderSymmetry = false
    };

    forwardOptions.KnownNetworks.Clear();
    forwardOptions.KnownProxies.Clear();

    app.UseForwardedHeaders(forwardOptions);

    app.UseAuthentication();

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.Run();
    Log.Information("Application started correctly.");
}
catch (Exception ex)
{
    Log.Fatal("The apllication failed to start correctly :", ex);
}
finally
{
    Log.CloseAndFlush();
}
