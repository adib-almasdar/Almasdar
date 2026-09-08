using CommonLib;
using CommonLib.Data;
using CommonLib.Data.Interface;
using CommonLib.Services.Interface;
using CommonLib.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddTransient<IDataClass1, DataClass1>();
builder.Services.AddTransient<IHTTPRequestService, HTTPRequestService>();

// Enable the keyvalt logic to create release package
string vaultUri = builder.Configuration["KeyVault:VaultUri"];
string secretName = builder.Configuration["KeyVault:SqlConnSecretName"];
var keyVaultService = new KeyVaultService(vaultUri);
string connectionString = keyVaultService.GetSecret(secretName);
builder.Services.AddSingleton<IKeyVaultService>(new KeyVaultService(vaultUri));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

//#region Uncomment to run the solution in the localhost
//builder.Services.AddSingleton<DataLakeHandler>();
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection")
//    builder => builder.EnableRetryOnFailure()
//    );
//});
//#endregion

// enable the below code to run in local machine
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection")
//    //builder => builder.EnableRetryOnFailure()
//    );
//});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
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


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
