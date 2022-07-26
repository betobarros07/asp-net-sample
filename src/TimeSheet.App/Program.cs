using MediatR;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using TimeSheet.Domain.Handlers;
using TimeSheet.Domain.Repositories;
using TimeSheet.Domain.Settings;
using TimeSheet.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(HealthCheckHandler).Assembly);

var keyVaultEndpoint = Environment.GetEnvironmentVariable("KEY_VAULT_ENDPOINT");
var keyVaultClientId = Environment.GetEnvironmentVariable("KEY_VAULT_CLIENT_ID");
var keyVaultClientSecret = Environment.GetEnvironmentVariable("KEY_VAULT_CLIENT_SECRET");

KeyVaultClient keyVaultClient = new(async (string authority, string resource, string scope) =>
{

    AuthenticationContext context = new(authority, TokenCache.DefaultShared);
    ClientCredential credential = new(keyVaultClientId, keyVaultClientSecret);
    AuthenticationResult result = await context.AcquireTokenAsync(resource, credential);
    if (result == null)
    {
        throw new InvalidOperationException("Falha ao recuperar token");
    }

    return result.AccessToken;
}, new HttpClient());

var cacheSecret = await keyVaultClient.GetSecretAsync(keyVaultEndpoint, "timesheet-connectionstring");
SqlConnectionStringSettings sqlConnectionStringSettings = new(cacheSecret.Value);
builder.Services.AddSingleton<SqlConnectionStringSettings>(sqlConnectionStringSettings);

builder.Services.AddScoped<IHealthCheckRepository, HealthCheckRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
