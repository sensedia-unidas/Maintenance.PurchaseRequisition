using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidas.MS.Maintenance.PurchaseRequisition.Application.ViewModels.Requests;

namespace Unidas.MS.Maintenance.PurchaseRequisition.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ItemPurchaseRequisistionViewModel, ItemPurchaseRequisistionToSalesForceViewModel>()
                .ForMember(x => x.IdSalesForce, y => y.MapFrom(z => z.IdSalesForce))
                .ForMember(x => x.StatusPurchaseRequisitionProduct, y => y.MapFrom(z => (z.StatusPurchaseRequisitionProduct)))
                .ForMember(x => x.StatusPurchaseRequisitionService, y => y.MapFrom(z => (z.StatusPurchaseRequisitionService)))
                .ForMember(x => x.IdPurchaseRequisitionService, y => y.MapFrom(z => (z.IdPurchaseRequisitionService)))
                .ForMember(x => x.IdPurchaseRequisitionProduct, y => y.MapFrom(z => (z.IdPurchaseRequisitionProduct)))
                .ForMember(x => x.IdPurchaseRequisition, y => y.MapFrom(z => (z.IdPurchaseRequisition)))
                .ForMember(x => x.StatusPurchaseRequisition, y => y.MapFrom(z => (z.StatusPurchaseRequisition)));

        }
    }
}
