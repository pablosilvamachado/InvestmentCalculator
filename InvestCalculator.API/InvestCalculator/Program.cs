

using InvestmentCalculator.Application;
using InvestmentCalculator.Domain.Entities.Cdb;
using InvestmentCalculator.Domain.Interfaces;
using InvestmentCalculator.Domain.UserCases;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Adicionar serviços ao contêiner.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICalculatorEngine, CalculatorEngine>();
builder.Services.AddScoped<IManager, CdbManager>();
builder.Services.AddScoped<IService, InvestmentCalculatorService>();

builder.Services.AddScoped<IInvestimento, Cdb>();


string[] origens = ["http://localhost:4200", "https://localhost:4200", "http://localhost:8080", "http://localhost:8081", "http://localhost:3000"];

builder.Services.AddCors(
                options => options.AddPolicy(
                    MyAllowSpecificOrigins,
                    builder => builder
                        .WithOrigins(origens)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                )
            );




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins); // Enable CORS!

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
