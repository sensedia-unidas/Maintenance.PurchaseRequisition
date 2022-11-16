namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.Exceptions
{
    public class ServiceException : Exception
    {
        internal ServiceException(string businessMessage)
               : base(businessMessage)
        {
        }
    }
}
