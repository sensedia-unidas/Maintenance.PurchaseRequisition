using Unidas.MS.Maintenance.PurchaseRequisition.Domain.Models.Cars;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Domain.Interfaces.Repositories
{

    public interface ICarReadOnlyRepository
    {
        Task<Cars> Get(Guid id);
    }
}
