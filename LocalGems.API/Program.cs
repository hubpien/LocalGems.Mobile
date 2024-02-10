using LocalGems.API.Models;
using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

//var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
//builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

var sqlCon = builder.Configuration["ConnectionStrings"];

// Add services to the container.

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();
builder.Services.AddSqlServer<AppDbContext>(sqlCon, options => options.EnableRetryOnFailure());
//builder.Services.AddDbContext<AppDbContext>(options =>
//  options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

var app = builder.Build();


app.MapIdentityApi<IdentityUser>();

app.MapGet("/", () => "Hello World!");

app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandler("/Error");

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory())),
    RequestPath = "/doc"
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
