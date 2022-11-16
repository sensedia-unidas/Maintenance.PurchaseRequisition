using FluentValidation;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Car;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Car.Requests;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.Validation.Car
{
    public class PickUpCarRequestValidator : AbstractValidator<PickupCarRequest>
    {
        public PickUpCarRequestValidator()
        {
            RuleFor(m => m.CarId).NotEmpty();
            RuleFor(m => m.RentedBy).NotEmpty();
        }
    }
}
