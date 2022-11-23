using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels
{
    public class AppSettings
    {
        public SalesForce SalesForce { get; set; } = new SalesForce();
    }

    public class SalesForce
    {
        public string Url { get; set; }
        public string GetToken { get; set; }
        public string ClientId { get; set; }
        public string UserName { get; set; }
        public string ClientSecret { get; set; }
        public string Password { get; set; }
    }
}
