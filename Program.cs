using FileEncryption.Models;
using FileEncryption.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICryptoService, CryptoService>();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
