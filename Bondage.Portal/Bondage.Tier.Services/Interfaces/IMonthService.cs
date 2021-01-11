using System.Collections.Generic;
using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Updates;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Services.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IMonthService"/> interface. Inherits <see cref="IBaseService"/>.
    /// </summary>
    public interface IMonthService : IBaseService
    {
        /// <summary>
        /// Finds All Month
        /// </summary>
        /// <returns>Instance of <see cref="Task{IList{ViewMonth}}"/></returns>
        Task<ICollection<ViewMonth>> FindAllMonth();

        /// <summary>
        /// Finds Month By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Month}"/></returns>
        Task<Month> FindMonthById(int @id);

        /// <summary>
        /// Removes Month By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        Task RemoveMonthById(int @id);

        /// <summary>
        /// Updates Month
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateMonth"/></param>
        /// <returns>Instance of <see cref="Task{ViewMonth}"/></returns>
        Task<ViewMonth> UpdateMonth(UpdateMonth @viewModel);

        /// <summary>
        /// Adds Month
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddMonth"/></param>
        /// <returns>Instance of <see cref="Task{ViewMonth}"/></returns>
        Task<ViewMonth> AddMonth(AddMonth @viewModel);

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddMonth"/></param>
        /// <returns>Instance of <see cref="Task{Month}"/></returns>
        Task<Month> CheckName(AddMonth @viewModel);

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateMonth"/></param>
        /// <returns>Instance of <see cref="Task{Month}"/></returns>
        Task<Month> CheckName(UpdateMonth @viewModel);
    }
}
