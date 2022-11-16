using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Car.Results;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces.Commands.RegisterCar
{
    public interface IRegisterCarUseCase
    {
        Task<RegisterCarResult> Execute(string description, string plate);
    }
}
