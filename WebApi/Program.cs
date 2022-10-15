using AppMappingProfile;
using CRUDUserFeature.DTOs;
using Interfaces.Repositories;
using MediatR;
using Repositories;
using RootDb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(RootDbMappingProfile));
builder.Services.AddDbContext<RootDbContext>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddMediatR(typeof(UserDto).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
