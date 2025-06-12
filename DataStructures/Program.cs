using System.ComponentModel;
using WorkerData.Repostiories;
using WorkerData.Repostiories.Interfaces;
using WorkerData.Services;
using WorkerData.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddSingleton<WorkerDataInterface, WorkerService>();
builder.Services.AddSingleton<IWorkerRepo, WorkerRepo>();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.MapOpenApi();


app.UseHttpsRedirection();


app.Run();

