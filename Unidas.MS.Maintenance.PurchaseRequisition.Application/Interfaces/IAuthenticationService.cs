using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GetTokenSF();
    }
}
