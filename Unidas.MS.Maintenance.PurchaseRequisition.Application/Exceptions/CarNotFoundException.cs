namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.Exceptions
{
    internal sealed class CarNotFoundException : ApplicationException
    {
        internal CarNotFoundException(string message)
            : base(message)
        { }
    }
}
