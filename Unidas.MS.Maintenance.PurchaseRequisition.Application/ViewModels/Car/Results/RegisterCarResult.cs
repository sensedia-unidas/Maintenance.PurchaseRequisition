using Unidas.MS.Maintenance.PurchaseRequisition.Domain.Models.Cars;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Car.Results
{
    public class RegisterCarResult
    {
        public CarResult Car { get; }

        public RegisterCarResult(Cars car)
        {
            Car = new CarResult(car);

        }
    }
}
