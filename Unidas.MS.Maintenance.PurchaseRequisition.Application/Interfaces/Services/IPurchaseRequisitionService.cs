using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Requests;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces.Services
{
    public interface IPurchaseRequisitionService
    {
        Task<ValidationResult> Integrate(ItemPurchaseRequisistionViewModel request);
    }
}
