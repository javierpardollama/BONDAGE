using System.Collections.Generic;
using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Updates;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Services.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IKindService"/> interface. Inherits <see cref="IBaseService"/>.
    /// </summary>
    public interface IKindService : IBaseService
    {
        /// <summary>
        /// Finds All Kind
        /// </summary>
        /// <returns>Instance of <see cref="Task{IList{ViewKind}}"/></returns>
        Task<ICollection<ViewKind>> FindAllKind();

        /// <summary>
        /// Finds Kind By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Kind}"/></returns>
        Task<Kind> FindKindById(int @id);

        /// <summary>
        /// Removes Kind By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        Task RemoveKindById(int @id);

        /// <summary>
        /// Updates Kind
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateKind"/></param>
        /// <returns>Instance of <see cref="Task{ViewKind}"/></returns>
        Task<ViewKind> UpdateKind(UpdateKind @viewModel);

        /// <summary>
        /// Adds Kind
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddKind"/></param>
        /// <returns>Instance of <see cref="Task{ViewKind}"/></returns>
        Task<ViewKind> AddKind(AddKind @viewModel);

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddKind"/></param>
        /// <returns>Instance of <see cref="Task{Kind}"/></returns>
        Task<Kind> CheckName(AddKind @viewModel);

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateKind"/></param>
        /// <returns>Instance of <see cref="Task{Kind}"/></returns>
        Task<Kind> CheckName(UpdateKind @viewModel);
    }
}
