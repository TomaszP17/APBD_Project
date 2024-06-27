using APBD_Project.Contexts;
using APBD_Project.Endpoints;
using APBD_Project.Services;
using APBD_Project.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddValidatorsFromAssemblyContaining<IndividualClientValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CompanyClientValidator>();
builder.Services.AddDbContext<DataBaseContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGroup("/api").RegisterClientsEndpoints();
app.Run();