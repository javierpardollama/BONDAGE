using System;
using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;

using Microsoft.EntityFrameworkCore;

namespace Bondage.Tier.Contexts.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IApplicationContext"/> interface. Inherits <see cref="IDisposable"/>.
    /// </summary>
    public interface IApplicationContext : IDisposable
    {
        /// <summary>
        /// Gets or Sets <see cref="DbSet{ApplicationRole}"/>
        /// </summary>
        DbSet<ApplicationRole> ApplicationRole { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{ApplicationRoleClaim}"/>
        /// </summary>
        DbSet<ApplicationRoleClaim> ApplicationRoleClaim { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{ApplicationUser}"/>
        /// </summary>
        DbSet<ApplicationUser> ApplicationUser { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{ApplicationUserClaim}"/>
        /// </summary>
        DbSet<ApplicationUserClaim> ApplicationUserClaim { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{ApplicationUserLogin}"/>
        /// </summary>
        DbSet<ApplicationUserLogin> ApplicationUserLogin { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{ApplicationUserRole}"/>
        /// </summary>
        DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{ApplicationUserToken}"/>
        /// </summary>
        DbSet<ApplicationUserToken> ApplicationUserToken { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Effort}"/>
        /// </summary>
        DbSet<Effort> Effort { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Kind}"/>
        /// </summary>
        DbSet<Kind> Kind { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Grade}"/>
        /// </summary>
        DbSet<Grade> Grade { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Absence}"/>
        /// </summary>
        DbSet<Absence> Absence { get; set; }

        /// <summary>
        /// Saves Changes Syncronously
        /// </summary>
        /// <returns>Instance of <see cref="int"/></returns>
        int SaveChanges();

        /// <summary>
        /// Saves Changes Asyncronously
        /// </summary>
        /// <returns>Instance of <see cref="Task{int}"/></returns>
        Task<int> SaveChangesAsync();
    }
}
