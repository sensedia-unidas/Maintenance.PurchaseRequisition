using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces.Commands.PickUpCar;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces.Commands.RegisterCar;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Commands.PickupCar;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Commands.RegisterCar;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Validation;
using Unidas.MS.Maintenance.PurchaseRequisition.Domain.Interfaces.Repositories;
using Unidas.MS.Maintenance.PurchaseRequisition.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces.Services.CaseSalesForce;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Services.CaseSalesForce;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Services;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces.Services;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Infra.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //REPOSITORY
            services.AddScoped<ICarReadOnlyRepository, CarRepository>();
            services.AddScoped<ICarWriteOnlyRepository, CarRepository>();
            //services.AddScoped<IPurchaseRequisitionRepository, CarRepository >();

            //SERVICE
            services.AddScoped<IPickUpCarUseCase, PickUpCarUseCase>();
            services.AddScoped<IRegisterCarUseCase, RegisterUseCase>();
            services.AddScoped<ISendToSalesForceCase, SendToSalesForceCase>();
            services.AddScoped<IPurchaseRequisitionService, PurchaseRequisitionService>();

            services.AddSingleton<InMemoryDbContext>();
            services.AddScoped<IMinimalValidator, MinimalValidator>();
        }
    }
}
