using AutoMapper;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Mappings.Classes
{
    public class ModelingProfile : Profile
    {
        public ModelingProfile()
        {
            CreateMap<ApplicationRole, ViewApplicationRole>();

            CreateMap<ApplicationUser, ViewApplicationUser>();

            CreateMap<ApplicationUserRole, ViewApplicationUserRole>();

            CreateMap<ApplicationUserToken, ViewApplicationUserToken>();

            CreateMap<Effort, ViewEffort>();

            CreateMap<Break, ViewBreak>();

            CreateMap<Kind, ViewKind>();
        }
    }
}
