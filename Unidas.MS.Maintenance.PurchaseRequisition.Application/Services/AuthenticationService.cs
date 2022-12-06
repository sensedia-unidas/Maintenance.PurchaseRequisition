using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AppSettings _appSettings;

        public AuthenticationService(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<string> GetTokenSF()
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
                //preparar retorno com falha
            }

            return "";
        }
    }
}
