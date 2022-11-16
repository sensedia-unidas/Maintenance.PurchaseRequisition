namespace Unidas.MS.Maintenance.PurchaseRequisition.Domain.Models.Cars
{
   
    public sealed class CarCannotBePickupExcepction : DomainException
    {
        internal CarCannotBePickupExcepction(string message)
            : base(message)
        { }
    }
}
