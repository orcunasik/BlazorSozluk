using BlazorSozluk.Api.Application.Extensions;
using BlazorSozluk.Api.Application.Features.Commands.User.Login;
using BlazorSozluk.Infrastructure.Persistence.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services
    .AddValidatorsFromAssembly(typeof(LoginUserCommandValidator).Assembly)
    .AddFluentValidationAutoValidation();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureRegistration(builder.Configuration);
builder.Services.AddApplicationRegistration();

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
