namespace Unidas.MS.Maintenance.PurchaseRequisition.Domain.Models
{
    public class DomainException : Exception
    {
        internal DomainException(string businessMessage)
            : base(businessMessage)
        {

          

        }
    }
}
