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

        Task<ICollection<ViewEffort>> FindAllEffortByApplicationUserById(int id);

        Task<ApplicationUser> FindApplicationUserById(int id);

        Task<ViewEffort> Start(AddEffort viewModel);

        Task<ViewEffort> Pause(AddBreak viewModel);

        Task<ViewEffort> Resume(AddBreak viewModel);

        Task<ViewEffort> Stop(AddBreak viewModel);

        Task AddStartBreak(Effort entity);

        Task AddPauseBreak(Effort entity);

        Task AddResumeBreak(Effort entity);

        Task AddStopBreak(Effort entity);

        Task RemoveEffortById(int id);

        Task<Effort> FindEffortById(int id);

        Task<Kind> FindKindById(int id);

        Task<Effort> CheckDate(AddEffort viewModel);

        Task<Effort> CheckDate(AddBreak viewModel);
    }
}
