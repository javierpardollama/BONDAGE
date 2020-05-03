using System.Collections.Generic;
using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Services.Interfaces
{
    public interface IEffortService : IBaseService
    {
        Task<ICollection<ViewEffort>> FindAllEffort();

        Task<ICollection<ViewEffort>> FindAllEffortByApplicationUserById(int @id);

        Task<ApplicationUser> FindApplicationUserById(int @id);

        Task<Effort> FindEffortByApplicationUserIdAndDate(AddBreak @viewModel);

        Task<Break> FindActiveBreak(AddBreak @viewModel);

        void UpdateBreakAsInactive(Break @break);

        Task<ViewEffort> Start(AddBreak @viewModel);

        Task<ViewEffort> Pause(AddBreak @viewModel);

        Task<ViewEffort> Resume(AddBreak @viewModel);

        Task<ViewEffort> Stop(AddBreak @viewModel);

        Task AddStartBreak(Effort @effort);

        Task AddPauseBreak(Effort @effort);

        Task AddResumeBreak(Effort @effort);

        Task AddStopBreak(Effort @effort);

        Task RemoveEffortById(int @id);

        Task<Effort> FindEffortById(int @id);

        Task<Kind> FindKindById(int @id);
    }
}
