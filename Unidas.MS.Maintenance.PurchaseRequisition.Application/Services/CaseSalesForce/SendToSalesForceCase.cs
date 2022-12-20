using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces.Services.CaseSalesForce;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Requests;


namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.Services.CaseSalesForce
{
    public class SendToSalesForceCase : ISendToSalesForceCase
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger<SendToSalesForceCase> _logger;
        private readonly IAuthenticationService _authenticationService;

        public SendToSalesForceCase(AppSettings appSettings, ILogger<SendToSalesForceCase> logger, IAuthenticationService authenticationService)
        {
            _appSettings = appSettings;
            _logger = logger;
            _authenticationService = authenticationService;
        }

        public async Task<bool> Execute(ItemPurchaseRequisistionViewModel item)
        {
            try
            {
                _logger.LogInformation("SendCaseToSF - Iniciando envio para o SF", item);

                var client = new HttpClient
                {
                    BaseAddress = new Uri(_appSettings.SalesForce.Url + item.IdSalesForce)
                };

                //var token = await GetTokenSF();
                var token = await _authenticationService.GetTokenSF();

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

        /*private async Task<string> GetTokenSF()
        {
            var client = new HttpClient();

            var parameters = new FormUrlEncodedContent(new[]
               {
                    new KeyValuePair<string, string>("client_id", _appSettings.SalesForce.ClientId),
                    new KeyValuePair<string, string>("client_secret", _appSettings.SalesForce.ClientSecret),
                    new KeyValuePair<string, string>("username", _appSettings.SalesForce.UserName),
                    new KeyValuePair<string, string>("password", _appSettings.SalesForce.Password),
                });

            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(_appSettings.SalesForce.GetToken, content);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var token = Convert.ToString(JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync()).token);
                
                    return token;
                }

                
            }
            catch (Exception e)
            {

            }

            return "";
        }*/
    }
}
