using System.Collections.Generic;
using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Services.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IEffortService"/> interface. Inherits <see cref="IBaseService"/>.
    /// </summary>
    public interface IEffortService : IBaseService
    {
        /// <summary>
        /// Finds Last Active Effort By Application User Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{ViewEffort}"/></returns>
        Task<ViewEffort> FindLastActiveEffortByApplicationUserId(int @id);

        /// <summary>
        /// Finds Current Day Active Effort By Application User Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        Task<Effort> FindCurrentDayActiveEffortByApplicationUserId(int @id);

        /// <summary>
        /// Finds Former Day Active Effort By Application User Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        Task<Effort> FindFormerDayActiveEffortByApplicationUserId(int @id);

        /// <summary>
        /// Finds All Effort
        /// </summary>
        /// <returns>Instance of <see cref="Task{ICollection{ViewEffort}}"/></returns>
        Task<ICollection<ViewEffort>> FindAllEffort();

        /// <summary>
        /// Finds All Effort By Application User Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{ICollection{ViewEffort}}"/></returns>
        Task<ICollection<ViewEffort>> FindAllEffortByApplicationUserId(int @id);

        /// <summary>
        /// Finds Application User By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{ApplicationUser}"/></returns>
        Task<ApplicationUser> FindApplicationUserById(int @id);

        /// <summary>
        /// Removes Effort By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        Task RemoveEffortById(int @id);

        /// <summary>
        /// Finds Effort By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        Task<Effort> FindEffortById(int @id);

        /// <summary>
        /// Finds Kind By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Kind}"/></returns>
        Task<Kind> FindKindById(int @id);

        /// <summary>
        /// Add Start Effort
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        Task<Effort> AddStartEffort(AddEffort @viewmodel);

        /// <summary>
        /// Add Pause Effort
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        Task<Effort> AddPauseEffort(AddEffort @viewmodel);

        /// <summary>
        /// Add Resume Effort
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        Task<Effort> AddResumeEffort(AddEffort @viewmodel);

        /// <summary>
        /// Add Stop Effort
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        Task<Effort> AddStopEffort(AddEffort @viewmodel);

        /// <summary>
        /// De Activates Stop
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        Task DeActivateStop(AddEffort @viewmodel);

        /// <summary>
        /// Starts
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task{ViewEffort}"/></returns>
        Task<ViewEffort> Start(AddEffort @viewmodel);

        /// <summary>
        /// De Activates Start
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        Task DeActivateStart(AddEffort @viewmodel);

        /// <summary>
        /// Pauses
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task{ViewEffort}"/></returns>
        Task<ViewEffort> Pause(AddEffort @viewmodel);

        /// <summary>
        /// De Activates Pause
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        Task DeActivatePause(AddEffort @viewmodel);

        /// <summary>
        /// Resumes
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task{ViewEffort}"/></returns>
        Task<ViewEffort> Resume(AddEffort @viewmodel);

        /// <summary>
        /// De Activates Resume
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        Task DeActivateResume(AddEffort @viewmodel);

        /// <summary>
        /// Stops
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task{ViewEffort}"/></returns>
        Task<ViewEffort> Stop(AddEffort @viewmodel);
    }
}
