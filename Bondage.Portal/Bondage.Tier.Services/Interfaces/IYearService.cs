using System.Collections.Generic;
using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Updates;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Services.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IYearService"/> interface. Inherits <see cref="IBaseService"/>.
    /// </summary>
    public interface IYearService : IBaseService
    {
        /// <summary>
        /// Finds All Year
        /// </summary>
        /// <returns>Instance of <see cref="Task{IList{ViewYear}}"/></returns>
        Task<ICollection<ViewYear>> FindAllYear();

        /// <summary>
        /// Finds Year By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Year}"/></returns>
        Task<Year> FindYearById(int @id);

        /// <summary>
        /// Removes Year By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        Task RemoveYearById(int @id);

        /// <summary>
        /// Updates Year
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateYear"/></param>
        /// <returns>Instance of <see cref="Task{ViewYear}"/></returns>
        Task<ViewYear> UpdateYear(UpdateYear @viewModel);

        /// <summary>
        /// Adds Year
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddYear"/></param>
        /// <returns>Instance of <see cref="Task{ViewYear}"/></returns>
        Task<ViewYear> AddYear(AddYear @viewModel);

        /// <summary>
        /// Checks Number
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddYear"/></param>
        /// <returns>Instance of <see cref="Task{Year}"/></returns>
        Task<Year> CheckNumber(AddYear @viewModel);

        /// <summary>
        /// Checks Number
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateYear"/></param>
        /// <returns>Instance of <see cref="Task{Year}"/></returns>
        Task<Year> CheckNumber(UpdateYear @viewModel);
    }
}
