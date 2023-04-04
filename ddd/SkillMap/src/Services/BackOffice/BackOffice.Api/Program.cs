using BackOffice.Api.Extensions;
using BackOffice.Application.Events.Integration;
using SkillMap.EventBus.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var pathBase = builder.Configuration["PATH_BASE"];

// Building AppSettings Configuration File
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", false, true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Custom dependencies
//builder.Services.AddCustomSwagger(builder.Configuration);
builder.Services.AddCustomConfiguration(builder.Configuration);
builder.Services.AddCustomDbContext(builder.Configuration);
builder.Services.AddDependencies(builder.Configuration);
builder.Services.AddCustomIntegrations(builder.Configuration);
builder.Services.AddEventBus(builder.Configuration);
//builder.Services.AddHealthChecks(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
        .SetIsOriginAllowed((host) => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

await using WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //app.UseSwagger()
    //       .UseSwaggerUI(c =>
    //       {
    //           c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty) }/swagger/v1/swagger.json", "Ordering.API V1");
    //           c.OAuthClientId("backofficeswaggerui");
    //           c.OAuthAppName("BackOffice Swagger UI");
    //       });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseDeveloperExceptionPage();

// Use custom services
app.UseCors("CorsPolicy");

ConfigureEventBus(app);

//ConfigureAuth(app);

app.Run();


void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

    eventBus.Subscribe<TagAddedIntegrationEvent, IIntegrationEventHandler<TagAddedIntegrationEvent>>();
}

void ConfigureAuth(IApplicationBuilder app)
{
    app.UseAuthentication();
    app.UseAuthorization();
}


