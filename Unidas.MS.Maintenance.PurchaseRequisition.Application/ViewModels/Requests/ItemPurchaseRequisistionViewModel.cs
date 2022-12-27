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

        [JsonPropertyName("IdSalesForce")]
        public string IdSalesForce { get; set; }

        [JsonPropertyName("IdPurchaseRequisition")]
        public string IdPurchaseRequisition { get; set; }

        [JsonPropertyName("StatusPurchaseRequisition")]
        public string StatusPurchaseRequisition { get; set; }

        [JsonPropertyName("IdPurchaseRequisitionProduct")]
        public string IdPurchaseRequisitionProduct { get; set; }

        [JsonPropertyName("IdPurchaseRequisitionService")]
        public string IdPurchaseRequisitionService { get; set; }

        [JsonPropertyName("StatusPurchaseRequisitionProduct")]
        public string StatusPurchaseRequisitionProduct { get; set; }

        [JsonPropertyName("StatusPurchaseRequisitionService")]
        public string StatusPurchaseRequisitionService { get; set; }

    }



}
