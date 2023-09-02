using Data;
using Data.Repository;
using Domain.Interface;
using Domain.Interface.Repository;
using Domain.Interface.ServicesRepository;
using Domain.services.serviceUser;
using Domain.services.serviceUser.Criptorgrafia;
using Domain.services.serviceUser.InterfaceUsersServices;
using Exceptions.ExceptionBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddApplication(builder.Configuration);

builder.Services.AddDbContext<TaskDbContex>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SistemaDeTarefas"),
    b => b.MigrationsAssembly("SistemaDeTarefas"));
});

//using DbContextOptionsBuilder. E.g. options.UseSqlServer(connection, b => b.MigrationsAssembly("SistemaDeTarefas"))
builder.Services.AddScoped<IUserRepositoryDomain, UserRepositoryData>();
builder.Services.AddScoped<ITaskRepositoryDomain, TaskRepositoryData>();
builder.Services.AddScoped<ITaskRepositoryService, TaskService>();

builder.Services.AddScoped<IPostUser, PostUser>();
builder.Services.AddScoped<IAllUsers, AllUsers>();

builder.Services.AddScoped<IUserId, UserId>();
builder.Services.AddScoped<ISearchEamil, SEamil>();

builder.Services.AddScoped<IUserUp, UserUp>();
builder.Services.AddScoped<IDeleteUser, DeleteUser>();



// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.IgnoreNullValues = true;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddMvc(optins => optins.Filters.Add(typeof(FilterExcepetion)));


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
