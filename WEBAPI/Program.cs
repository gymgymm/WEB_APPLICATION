using Microsoft.AspNetCore.Connections;
using WebApplication1.Helpers;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ConnectionHelper>();
builder.Services.AddScoped<IUyelerRepository, UyeRepository>();
builder.Services.AddScoped<IHareket, HareketRepository>();
builder.Services.AddScoped<IDuyuruRepository, DuyuruRepository>();
builder.Services.AddScoped<IKategoriRepository, KategoriRepository>();
builder.Services.AddScoped<IKitapRepository, KitapRepository>();
builder.Services.AddScoped<IMesajlarRepository, MesajlarRepository>();
builder.Services.AddScoped<IPersonelRepository, PersonelRepository>();
builder.Services.AddScoped<IYazarRepository, YazarRepository>();
builder.Services.AddScoped<IHakkýmýzdaRepository, HakkýmýzdaRepository>();
builder.Services.AddScoped<IIletisimRepository, IletisimRepository>();
builder.Services.AddScoped<ICezalarRepository, CezalarRepository>();
builder.Services.AddScoped<IProsedurRepository, ProsedurRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
