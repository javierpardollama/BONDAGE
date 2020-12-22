using System.Collections.Generic;
using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Updates;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Services.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IGradeService"/> interface. Inherits <see cref="IBaseService"/>.
    /// </summary>
    public interface IGradeService : IBaseService
    {
        /// <summary>
        /// Finds All Grade
        /// </summary>
        /// <returns>Instance of <see cref="Task{IList{ViewGrade}}"/></returns>
        Task<ICollection<ViewGrade>> FindAllGrade();

        /// <summary>
        /// Finds Grade By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Grade}"/></returns>
        Task<Grade> FindGradeById(int @id);

        /// <summary>
        /// Removes Grade By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        Task RemoveGradeById(int @id);

        /// <summary>
        /// Updates Grade
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateGrade"/></param>
        /// <returns>Instance of <see cref="Task{ViewGrade}"/></returns>
        Task<ViewGrade> UpdateGrade(UpdateGrade @viewModel);

        /// <summary>
        /// Adds Grade
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddGrade"/></param>
        /// <returns>Instance of <see cref="Task{ViewGrade}"/></returns>
        Task<ViewGrade> AddGrade(AddGrade @viewModel);

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddGrade"/></param>
        /// <returns>Instance of <see cref="Task{Grade}"/></returns>
        Task<Grade> CheckName(AddGrade @viewModel);

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateGrade"/></param>
        /// <returns>Instance of <see cref="Task{Grade}"/></returns>
        Task<Grade> CheckName(UpdateGrade @viewModel);
    }
}
