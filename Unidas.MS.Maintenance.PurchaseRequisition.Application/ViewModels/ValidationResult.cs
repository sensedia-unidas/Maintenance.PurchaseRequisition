namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels
{
    public class ValidationResult2
    {
        public bool IsValid { get; set; }
        public Dictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
