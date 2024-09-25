using DotnetBlazor.Application.Interfaces;
//using DotnetBlazor.Application.Validators;
using DotnetBlazor.Components;
using DotnetBlazor.Domain.Entities;
using DotnetBlazor.Infrastructure.Context;
using DotnetBlazor.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("AppConnection"));
});

builder.Services.AddScoped<ICameraRepository, CameraRepository>();
builder.Services.AddScoped<IBalanceRepository, BalanceRepository>();

builder.Services.AddScoped<IValidator<Camera>, CameraValidator>();
builder.Services.AddScoped<IValidator<Balance>, BalanceValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
