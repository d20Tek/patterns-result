//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using Basic.MinimalApi.Endpoints;
using D20Tek.Patterns.Result.AspNetCore.MinimalApi;
using Samples.Application;
using Samples.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddScoped(typeof(HandleResultFilter<>));
builder.Services.AddScoped(typeof(HandleResultFilter));

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

app.MapMemberEndpoints();
app.MapMemberEndpointsV2();

app.Run();
