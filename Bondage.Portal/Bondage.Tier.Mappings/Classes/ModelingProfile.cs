using AutoMapper;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Mappings.Classes
{
    /// <summary>
    /// Represents a <see cref="ModelingProfile"/> class. Inherits <see cref="Profile"/>
    /// </summary>
    public class ModelingProfile : Profile
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ModelingProfile"/>
        /// </summary>
        public ModelingProfile()
        {
            CreateMap<ApplicationRole, ViewApplicationRole>();

            CreateMap<ApplicationUser, ViewApplicationUser>();

            CreateMap<ApplicationUserRole, ViewApplicationUserRole>();

            CreateMap<ApplicationUserToken, ViewApplicationUserToken>();

            CreateMap<Effort, ViewEffort>();

            CreateMap<Absence, ViewAbsence>();

            CreateMap<Kind, ViewKind>();

            CreateMap<Kind, ViewKind>();

            CreateMap<Grade, ViewGrade>();

            CreateMap<Year, ViewYear>();

            CreateMap<Month, ViewMonth>();
        }
    }
}
