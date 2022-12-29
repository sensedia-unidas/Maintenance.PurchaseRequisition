global using Microsoft.AspNetCore.Mvc;
global using Newtonsoft.Json;
global using System;
global using System.Linq;
global using System.Net;
using FluentValidation;
using Unidas.MS.Maintenance.PurchaseRequisition.API.Helpers;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces.Commands.PickUpCar;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces.Commands.RegisterCar;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces.Commands.PickUpCar;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces.Commands.RegisterCar;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Car;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Car.Requests;
using Unidas.MS.Maintenance.PurchaseRequisition.Infra.IoC;
using Microsoft.OpenApi.Models;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Requests;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces.Services;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region Configuracoes adicionadas - builder.services
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("V1", new OpenApiInfo() { Title = "API V1", Version = "V1.0" });
    //options.SwaggerDoc("V2", new OpenApiInfo() { Title = "API V2", Version = "V2.0" });
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    options.CustomSchemaIds(x => x.FullName);
});

NativeInjector.RegisterServices(builder.Services);

//builder.Services.AddValidatorsFromAssemblyContaining<Program>();

//builder.Services.AddApplicationInsightsTelemetry(options =>
//{
//    options.ConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"];
//});

//builder.Services.AddApiVersioning(options =>
//{
//    options.DefaultApiVersion = new ApiVersion(1, 0);
//    options.ReportApiVersions = true;
//    options.AssumeDefaultVersionWhenUnspecified = true;
//    options.ApiVersionReader = ApiVersionReader.Combine(
//        new HeaderApiVersionReader("Api-Version"),
//        new QueryStringApiVersionReader("Api-Version"));
//}).EnableApiVersionBinding();

builder.Services.AddMvc(options =>
{
    //options.Filters.Add(typeof(DomainExceptionFilter));
    options.Filters.Add(typeof(ValidateActionFilterAttribute));
});
#endregion

var appSettings = new AppSettings();
builder.Configuration.Bind("AppSettings", appSettings);
builder.Services.AddSingleton(appSettings);

var app = builder.Build();

#region Configuracoes adicionadas - app
//var versionSet = app.NewApiVersionSet()
//                    .HasApiVersion(1.0)
//                    .ReportApiVersions()
//                    .Build();

app.UseMiddleware(typeof(ApiExceptionMiddleware));
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint($"/swagger/V1/swagger.json", "V1.0");
        //options.SwaggerEndpoint($"/swagger/V2/swagger.json", "V2.0");
    });
}

app.UseHttpsRedirection();


#region Endpoints
//TODO: Versao pronta para versionar, porém o Swagger precisa ser implementado corretamente para separar as versoes e mostrar como chamar cada uma delas
//app.MapGet("/GetMessage", () => "This is an example of a minimal API").WithApiVersionSet(versionSet).MapToApiVersion(1.0);
//app.MapGet("/GetMessage", () => "2222222222 This is an example of a minimal API 2").WithApiVersionSet(versionSet).MapToApiVersion(2.0);
//app.MapGet("/GetText", () => "This is yet another example of a minimal API").WithApiVersionSet(versionSet).WithApiVersionSet(versionSet).IsApiVersionNeutral();

// GET /GetMessage?api-version=1.0
// GET /GetMessage

// POST
app.MapPost("/PurchaseRequisition/integrate", async (ItemPurchaseRequisistionViewModel request, IPurchaseRequisitionService service) =>
{
    app.Logger.LogInformation($"Integração Purchase Requisition (ordem de compra)", request);


    return Results.Ok(await service.Integrate(request));
});



#endregion


app.Run();
