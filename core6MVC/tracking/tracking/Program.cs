using tracking.Model;
using tracking.Service;

var builder = WebApplication.CreateBuilder(args);
// Add HttpClient and configure its base addresses
     Host.CreateDefaultBuilder(args)
    .ConfigureHostConfiguration(configHost =>
    {
        configHost.SetBasePath(Directory.GetCurrentDirectory());
    })
    .ConfigureAppConfiguration((hostContext, configApp) =>
    {
        configApp.AddJsonFile("appsettings.json", optional: false);
        configApp.AddEnvironmentVariables();
    });

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
});

builder.Services.AddHttpClient("HttpBinHttpClient", clients =>
    {
        clients.BaseAddress = new Uri("https://opentest.metrofcu.org/publicapi/api/v1/application/1d130fa5-b3f4-4fd0-bd10-af5dc9415017");
    });


// Add services to the container.
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


    // ... other middleware configurations
    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

// Other configuration...

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
