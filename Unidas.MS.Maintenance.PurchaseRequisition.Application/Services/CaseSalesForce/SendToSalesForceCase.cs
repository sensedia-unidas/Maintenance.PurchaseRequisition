using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces.Services.CaseSalesForce;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Requests;


namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.Services.CaseSalesForce
{
    public class SendToSalesForceCase : ISendToSalesForceCase
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger<SendToSalesForceCase> _logger;

        public SendToSalesForceCase(AppSettings appSettings, ILogger<SendToSalesForceCase> logger)
        {
            _appSettings = appSettings;
            _logger = logger;
        }

        public async Task<bool> Execute(ItemPurchaseRequisistionViewModel item)
        {
            try
            {
                _logger.LogInformation("SendCaseToSF - Iniciando envio para o SF", item);

                var client = new HttpClient
                {
                    BaseAddress = new Uri(_appSettings.SalesForce.Url)
                };

                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                client.Timeout = new TimeSpan(0, 3, 0);
                var response = await client.PostAsync(_appSettings.SalesForce.Url, content);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    _logger.LogWarning("SendCaseToSF - Falha ao tentar enviar para o AX", item, response);

                    return false;
                }

                _logger.LogInformation("SendCaseToSF - Finalizando envio para o AX", item);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("SendCaseToSF - Erro ao tentar envio para o SF", ex);

                throw;
            }

        }
    }
}
