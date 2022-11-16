using FluentValidation.Results;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces
{
    public interface IMinimalValidator
    {
        ValidationResult Validate<T>(T model);
    }
}
