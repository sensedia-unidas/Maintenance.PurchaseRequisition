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
using Unidas.MS.Maintenance.PurchaseRequisition.Application.AutoMapper;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Infra.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //REPOSITORY
            //services.AddScoped<ICarReadOnlyRepository, CarRepository>();
            //services.AddScoped<ICarWriteOnlyRepository, CarRepository>();

            //SERVICE
            services.AddScoped<ISendToSalesForceCase, SendToSalesForceCase>();
            services.AddScoped<IPurchaseRequisitionService, PurchaseRequisitionService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            

            services.AddSingleton<InMemoryDbContext>();
            services.AddScoped<IMinimalValidator, MinimalValidator>();

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
