using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces.Commands.RegisterCar;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Car.Results;
using Unidas.MS.Maintenance.PurchaseRequisition.Domain.Interfaces.Repositories;
using Unidas.MS.Maintenance.PurchaseRequisition.Domain.Models.Cars;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.Commands.RegisterCar
{
    public sealed  class RegisterUseCase : IRegisterCarUseCase
    {


        private readonly ICarWriteOnlyRepository carWriteOnlyRepository;

        public RegisterUseCase(ICarWriteOnlyRepository carWriteOnlyRepository)
        {
            this.carWriteOnlyRepository = carWriteOnlyRepository;
        }

        public async Task<RegisterCarResult> Execute(string description, string plate)
        {
            Cars car = new Cars(description, plate);

            await carWriteOnlyRepository.Add(car);

            RegisterCarResult result = new RegisterCarResult(car);

            return result;
        }
    }
}
