using System.ComponentModel;
using WorkerData.Services;
using WorkerData.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddSingleton<WorkerDataInterface, WorkerService>();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapOpenApi();


app.UseHttpsRedirection();


app.Run();

