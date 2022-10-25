using AppMappingProfile;
using Interfaces.Repositories;
using Repositories;
using RootDb;
using System.Text.Json.Serialization;

using WebApi.Extensions;
using WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(options => options.Filters.Add(typeof(HttpGlobalExceptionFilter)))
    .AddJsonOptions(options => 
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.IgnoreNullValues = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatRDependency();

builder.Services.AddDbContext<RootDbContext>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddAutoMapper(typeof(RootDbMappingProfile));
builder.Services.AddSwaggerGen();

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
