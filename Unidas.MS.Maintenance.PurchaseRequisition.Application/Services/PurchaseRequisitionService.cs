using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces.Services;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces.Services.CaseSalesForce;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Requests;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.Services
{
    public class PurchaseRequisitionService : IPurchaseRequisitionService
    {
        private readonly ISendToSalesForceCase _useCase;
        private readonly ILogger<PurchaseRequisitionService> _logger;

        public PurchaseRequisitionService(ILogger<PurchaseRequisitionService> logger)
        {
            _logger = logger;
        }

        public async Task<ValidationResult> Integrate(ItemPurchaseRequisistionViewModel request)
        {
            _logger.LogInformation("PurchaseRequisition - Iniciando integração", request);

            var validation = new ValidationResult();

            switch (request.StatusRC)
            {
                case "0":
                    request.StatusRC = "Cancelado";
                    break;
                case "1":
                    request.StatusRC = "Negado";
                    break;
                case "9":
                    request.StatusRC = "Aprovado";
                    break;
                case "3":
                    request.StatusRC = "Faturado";
                    break;
            }

            if (!await _useCase.Execute(request))
            {
                _logger.LogInformation("Service - Finalizando integração sem sucesso", request);
                validation.Errors.Add(new ValidationFailure(String.Empty, "Integração não realizada"));
            }

            _logger.LogInformation("Service - Finalizando integração", request);

            return validation;
        }
    }
}
