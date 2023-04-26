using eTrade.Business.DependencyResolver.DependencyInjection.ServiceDependency;
using eTrade.Core.CrossCuttingConcern.DependencyInjection.ServiceDependency;
using eTrade.SignalR.ServiceDependency;
using eTrade.Core.CrossCuttingConcern.Storage.Concretes.Azure;
using eTrade.Core.CrossCuttingConcern.Storage.Concretes.Local;
using eTrade.WebApi.Configurations;
using eTrade.WebApi.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.IdentityModel.Tokens;
using NpgsqlTypes;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;
using System.Security.Claims;
using System.Text;
using eTrade.WebApi.Filter;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => {
    options.Filters.Add<RolePermissionFilter>();
});
builder.Services.AddPersistenceServices();
builder.Services.AddCoreServices();
builder.Services.AddCQRSServices();
builder.Services.AddSignalRServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddStorage<LocalStorage>();
//builder.Services.AddStorage<AzureStorage>();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.WithOrigins("https://localhost:7214", "http://localhost:5144", "http://localhost:4760").AllowAnyHeader().AllowAnyMethod().AllowCredentials()));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("Admin", options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,

        ValidAudience = builder.Configuration["Token:Audience"],
        ValidIssuer = builder.Configuration["Token:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,
        NameClaimType = ClaimTypes.Name
    };
});

Logger log = new LoggerConfiguration()
    .WriteTo.Console().WriteTo.File("logs/log.txt").WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("PostgreSQL"), "logs", needAutoCreateTable: true, columnOptions: new Dictionary<string, ColumnWriterBase>
    {
        { "message",new RenderedMessageColumnWriter()},
        { "message_template", new MessageTemplateColumnWriter()},
        { "level", new LevelColumnWriter()},
        { "time_stamp", new TimestampColumnWriter()},
        { "exception", new ExceptionColumnWriter()},
        {"log_event", new LogEventSerializedColumnWriter(NpgsqlDbType.Json)},
        {"user_name", new UsernameColumnWriter()}
    }).WriteTo.Seq(builder.Configuration["Seq:ServerURL"]).Enrich.FromLogContext().MinimumLevel.Information().CreateLogger();
builder.Host.UseSerilog(log);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());
app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseHttpLogging();
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
    LogContext.PushProperty("user_name", username);
    await next();
});
app.MapControllers();
app.MapHubs();

app.Run();