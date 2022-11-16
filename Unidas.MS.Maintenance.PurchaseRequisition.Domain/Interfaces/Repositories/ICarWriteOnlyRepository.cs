using Unidas.MS.Maintenance.PurchaseRequisition.Domain.Models.Cars;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Domain.Interfaces.Repositories
{

    public interface ICarWriteOnlyRepository
    {
        Task Add(Cars car);
        Task Update(Cars car, PickUpCar pickUp);
        //Task Update(Car car, DropOffCar dropOff);
        Task Delete(Cars car);
    }
}
