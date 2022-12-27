using AutoMapper;
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
        private readonly IMapper _mapper;

        public PurchaseRequisitionService(ISendToSalesForceCase useCase,ILogger<PurchaseRequisitionService> logger, IMapper mapper)
        {
            _useCase = useCase;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ValidationResult> Integrate(ItemPurchaseRequisistionViewModel request)
        {
            _logger.LogInformation("PurchaseRequisition - Iniciando integração", request);

            var validation = new ValidationResult();

            switch (request.StatusPurchaseRequisition)
            {
                case "0":
                    request.StatusPurchaseRequisition = "Cancelado";
                    break;
                case "1":
                    request.StatusPurchaseRequisition = "Negado";
                    break;
                case "9":
                    request.StatusPurchaseRequisition = "Aprovado";
                    break;
                case "3":
                    request.StatusPurchaseRequisition = "Faturado";
                    break;
            }

            var finalModel = _mapper.Map<ItemPurchaseRequisistionToSalesForceViewModel>(request);

            if (!await _useCase.Execute(finalModel))
            {
                _logger.LogInformation("Service - Finalizando integração sem sucesso", finalModel);
                validation.Errors.Add(new ValidationFailure(String.Empty, "Integração não realizada"));
            }

            _logger.LogInformation("Service - Finalizando integração", request);

            return validation;
        }
    }
}
