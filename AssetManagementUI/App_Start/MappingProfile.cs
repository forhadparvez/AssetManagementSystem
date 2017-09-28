using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetManagementUI.ViewModels;
using AutoMapper;

namespace AssetManagementUI.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // view model to entity model
            CreateMap<OrganizationViewModel, Organization>();

        }



    }
}