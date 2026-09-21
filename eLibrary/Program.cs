using Azure.Identity;
using Azure.Search.Documents;
using CommonLib;
using CommonLib.Data;
using CommonLib.Data.Interface;
using CommonLib.Services;
using CommonLib.Services.Interface;
using eLibrary.Services;
using eLibrary.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using System.Text.Json.Serialization;
//using eLibrary.Services;
//using eLibrary.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IDataClass1, DataClass1>();
builder.Services.AddTransient<ISubCategoriesService, SubCategoriesService>();
builder.Services.AddTransient<ICategoriesService, CategoriesService>();
builder.Services.AddTransient<IBooksService, BooksService>();
builder.Services.AddTransient<ILanguagesService, LanguagesService>();
builder.Services.AddTransient<IHTTPRequestService, HTTPRequestService>();
builder.Services.AddTransient<ApplicationDbContext>();

// Enable the keyvault logic
#region  Uncomment the below code to prepare the release package
//string vaultUri = builder.Configuration["KeyVault:VaultUri"];
//string secretName = builder.Configuration["KeyVault:SqlConnSecretName"];
//var keyVaultService = new KeyVaultService(vaultUri);
//string connectionString = keyVaultService.GetSecret(secretname);
//builder.Services.AddSingleton<IKeyVaultService>(new KeyVaultService(vaultUri));
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(connectionString);
//});
//string blobsecretName = builder.Configuration["KeyVault:DatalakeConectionString"];
//var DatalakeConnection = keyVaultService.GetSecret(blobsecretName);
//var Container = builder.Configuration.GetValue<string>("DataLake:Container");
//builder.Services.AddOptions<CommonLib.Services.DataLakeOptions>()
//    .Configure<IConfiguration>((options, configuration) =>
//    {
//        options.DatalakeConnection = DatalakeConnection;
//        options.Container = Container;
//    });
//builder.Services.AddSingleton<DataLakeHandler>();
#endregion

#region Uncomment to run the solution in the localhost
var DatalakeConnection = builder.Configuration.GetValue<string>("DataLake:DatalakeConnection");
var Container = builder.Configuration.GetValue<string>("DataLake:Container");
builder.Services.AddOptions<CommonLib.Services.DataLakeOptions>()
    .Configure<IConfiguration>((options, configuration) =>
    {
        options.DatalakeConnection = DatalakeConnection;
        options.Container = Container;
    });
builder.Services.AddSingleton<DataLakeHandler>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection")
    //builder => builder.EnableRetryOnFailure()
    );
});
#endregion

builder.Services.AddControllers();

// for custom Web API skillset
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

// Register Azure Search SearchClient using RBAC
builder.Services.AddSingleton<SearchClient>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    // appsettings.json values
    string searchServiceUrl = configuration["SearchServiceUrl"];
    string indexName = configuration["SearchIndexName"];
    var endpoint = new Uri(searchServiceUrl);
    // RBAc Authentication (No API Key)
    var credentials = new DefaultAzureCredential();
    return new SearchClient(
        endpoint,
        indexName,
        credentials
    );
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

//Add middleware here
app.CallRequestMiddleware();
app.CallResponseMiddleware();
var logger = app.Services.GetRequiredService<ILogger<Program>>();

app.Use(async (context, next) =>
{
    var hasAuthorizationHeader =
        context.Request.Headers.ContainsKey("Authorization");

    logger.LogInformation(
        "Incoming request: {Method} {Path}, Has Authorization header: {HasAuth}",
        context.Request.Method,
        context.Request.Path,
        hasAuthorizationHeader);

    await next();
});
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
