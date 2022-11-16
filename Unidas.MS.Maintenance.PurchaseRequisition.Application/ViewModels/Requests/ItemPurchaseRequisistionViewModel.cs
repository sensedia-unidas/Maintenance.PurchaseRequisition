using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Requests
{
    public class ItemPurchaseRequisistionViewModel
    {
        /*public string RcNumber { get; set; }
        public string IssueKey { get; set; }
        public string StatusRC { get; set; }
        public string IdSalesForce { get; set; }
        public string StatusAX { get; set; }
        public List<Item> Itens { get; set; }

        public class Item
        {
            public string OrdemCompraId { get; set; }
            public string StatusItem { get; set; }
            public string OperationTypeId { get; set; }
        }*/

        [JsonPropertyName("NumeroRC__c")]
        public string NumeroRC { get; set; }

        [JsonPropertyName("StatusRC__c")]
        public string StatusRC { get; set; }

        [JsonPropertyName("Ordem_de_compra_produtos__c")]
        public string OrdemCompraProdutos { get; set; }

        [JsonPropertyName("Ordem_de_compra_servicos__c")]
        public string OrdemCompraServico { get; set; }

        [JsonPropertyName("StatusOCProdutos__c")]
        public string StatusOrdemCompraProduto { get; set; }

        [JsonPropertyName("StatusOCServicos__c")]
        public string StatusOrdemCompraServico { get; set; }

        [JsonPropertyName("OrdemCompraId")]
        public string ItemOrdemCompraId { get; set; }

        [JsonPropertyName("StatusItem")]
        public string ItemStatus { get; set; }

        [JsonPropertyName("OperationTypeId")]
        public string ItemOperationTypeId { get; set; }
    }



}
