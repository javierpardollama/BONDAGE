using System.Collections.Generic;
using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Updates;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Services.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IAbsenceService"/> interface. Inherits <see cref="IBaseService"/>.
    /// </summary>
    public interface IAbsenceService : IBaseService
    {
        /// <summary>
        /// Finds All Absence
        /// </summary>
        /// <returns>Instance of <see cref="Task{ICollection{ViewAbsence}}"/></returns>
        Task<ICollection<ViewAbsence>> FindAllAbsence();

        /// <summary>
        /// Finds All Absence By Application User Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{ICollection{ViewAbsence}}"/></returns>
        Task<ICollection<ViewAbsence>> FindAllAbsenceByApplicationUserId(int @id);

        /// <summary>
        /// Finds Application User By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{ApplicationUser}"/></returns>
        Task<ApplicationUser> FindApplicationUserById(int @id);

        /// <summary>
        /// Removes Absence By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        Task RemoveAbsencetById(int @id);

        /// <summary>
        /// Finds Absence By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        Task<Absence> FindAbsenceById(int @id);

        /// <summary>
        /// Finds Grade By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Grade}"/></returns>
        Task<Grade> FindGradeById(int @id);

        /// <summary>
        /// Adds Absence
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddAbsence"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        Task<ViewAbsence> AddAbsence(AddAbsence @viewmodel);

        /// <summary>
        /// Updates Absence
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="UpdateAbsence"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        Task<ViewAbsence> UpdateAbsence(UpdateAbsence @viewmodel);
    }
}
