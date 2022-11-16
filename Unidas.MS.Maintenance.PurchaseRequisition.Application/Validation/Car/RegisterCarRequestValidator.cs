using FluentValidation;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Car;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Car.Requests;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.Validation.Car
{
    public class RegisterCarRequestValidator : AbstractValidator<RegisterCarRequest>
    {
        public RegisterCarRequestValidator()
        {
            RuleFor(m => m.Plate).NotEmpty();
            RuleFor(m => m.Description).NotEmpty();
        }
    }
}
