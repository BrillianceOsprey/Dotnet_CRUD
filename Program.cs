using Dotnet_CRUD.Domain.DBContexts;
using Dotnet_CRUD.Domain.Repository.Interfaces;
using Dotnet_CRUD.Domain.Repository;
using Dotnet_CRUD.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMappper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// TODO: db
#region [Declare DBContext]
builder.Services.AddDbContext<dotnet_DBContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("DB_Connection")));
builder.Services.AddScoped<IDBUnitOfWork, DBUnitofwork>();
#endregion

// TODO: service
#region [Declare Service]
builder.Services.AddInfraStructure();
builder.Services.AddResponseConfig();
#endregion

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