using Microsoft.EntityFrameworkCore;
using Oo.Ddd.Bank.Domain.Model.Repository;
using Oo.Ddd.Bank.Infrastructure.EntityFrameworkProvider;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BankDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BankDbContext")));

builder.Services.AddScoped(typeof(DbContext), typeof(DbContext));
builder.Services.AddScoped<IContaRepository>(IContaRepository => new ContaRepository(IContaRepository.GetRequiredService<BankDbContext>()));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
