using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Requests
{
    public class ItemPurchaseRequisistionToSalesForceViewModel
    {
        [JsonPropertyName("IdSalesForce")]
        public string IdSalesForce { get; set; }

        [JsonPropertyName("NumeroRC__c")]
        public string IdPurchaseRequisition { get; set; }

        [JsonPropertyName("StatusRC__c")]
        public string StatusPurchaseRequisition { get; set; }

        [JsonPropertyName("Ordem_de_compra_produtos__c")]
        public string IdPurchaseRequisitionProduct { get; set; }

        [JsonPropertyName("Ordem_de_compra_servicos__c")]
        public string IdPurchaseRequisitionService { get; set; }

        [JsonPropertyName("StatusOCProdutos__c")]
        public string StatusPurchaseRequisitionProduct { get; set; }

        [JsonPropertyName("StatusOCServicos__c")]
        public string StatusPurchaseRequisitionService { get; set; }
    }
}
