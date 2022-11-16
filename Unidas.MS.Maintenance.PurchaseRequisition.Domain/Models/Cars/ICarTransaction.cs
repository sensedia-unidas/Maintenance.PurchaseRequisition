﻿namespace Unidas.MS.Maintenance.PurchaseRequisition.Domain.Models.Cars
{
    public interface ICarTransaction
    {
        DateTime TransactionDate { get;  }
        string RentedBy { get;  }
        string Action { get;  }
        long Latitude { get; }
        long Longitude { get; }
    }
}
