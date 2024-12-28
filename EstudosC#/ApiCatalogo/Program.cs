using System.Text.Json.Serialization;
using ApiCatalogo.Context;
using ApiCatalogo.Extensions;
using ApiCatalogo.Filters;
using ApiCatalogo.Loggin;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//configura para que nao tenha referencias ciclicas de objetos nos controllers, quando uma entidade tiver
//outra entidade de referencia
builder.Services.AddControllers().AddJsonOptions(options=> 
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnetion");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(mySqlConnection,
    ServerVersion.AutoDetect(mySqlConnection)
    ));

//filtro
builder.Services.AddScoped<ApiLoggingFilter>();

//logger
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    Loglevel = LogLevel.Information
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //configura o tratamento de erros global (status 500)
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
