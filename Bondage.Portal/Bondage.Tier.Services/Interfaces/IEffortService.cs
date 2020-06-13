using System.Collections.Generic;
using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Services.Interfaces
{
    public interface IEffortService : IBaseService
    {
        Task<ViewEffort> FindLastActiveEffortByApplicationUserId(int @id);

        Task<Effort> FindCurrenDayActiveEffortByApplicationUserId(int @id);

        Task<Effort> FindFormerDayActiveEffortByApplicationUserId(int @id);

        Task<ICollection<ViewEffort>> FindAllEffort();

        Task<ICollection<ViewEffort>> FindAllEffortByApplicationUserId(int @id);

        Task<ApplicationUser> FindApplicationUserById(int @id);

        Task RemoveEffortById(int @id);

        Task<Effort> FindEffortById(int @id);

        Task<Kind> FindKindById(int @id);

        Task<Effort> AddStartEffort(AddEffort @viewmodel);

        Task<Effort> AddPauseEffort(AddEffort @viewmodel);

        Task<Effort> AddResumeEffort(AddEffort @viewmodel);

        Task<Effort> AddStopEffort(AddEffort @viewmodel);

        Task DeActivateStop(AddEffort @viewmodel);

        Task<ViewEffort> Start(AddEffort @viewmodel);

        Task DeActivateStart(AddEffort @viewmodel);

        Task<ViewEffort> Pause(AddEffort @viewmodel);

        Task DeActivatePause(AddEffort @viewmodel);

        Task<ViewEffort> Resume(AddEffort @viewmodel);

        Task DeActivateResume(AddEffort @viewmodel);

        Task<ViewEffort> Stop(AddEffort @viewmodel);
    }
}
