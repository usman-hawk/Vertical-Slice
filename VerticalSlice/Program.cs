using MediatR;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using VerticalSlice.Application.Users.Create;
using VerticalSlice.Application.Interfaces;
using VerticalSlice.Infrastructure.Persistence;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register the DbContext (Scoped as it usually involves DB access)


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("VerticalSliceDb"));

// Register MediatR and FluentValidation
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateUserHandler>());
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserHandler>();
builder.Services.AddFluentValidationAutoValidation();

// Register repositories and handlers
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRequestHandler<CreateUserCommand, CreateUserResponse>, CreateUserHandler>();

// Register controllers and swagger
builder.Services.AddControllers();
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


