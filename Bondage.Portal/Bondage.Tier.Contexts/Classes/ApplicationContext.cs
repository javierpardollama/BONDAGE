using System;
using System.Threading.Tasks;

using Bondage.Tier.Contexts.Extensions;
using Bondage.Tier.Contexts.Interfaces;
using Bondage.Tier.Entities.Classes;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Bondage.Tier.Contexts.Classes
{
    /// <summary>
    /// Represents a <see cref="ApplicationContext"/> class. Inherits <see cref="DbContext"/>. Implements <see cref="IApplicationContext"/>. Inherits <see cref="IdentityDbContext"/>
    /// </summary>
    public class ApplicationContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>, IApplicationContext
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ApplicationContext"/>
        /// </summary>
        /// <param name="options">Injected <see cref="DbContextOptions{ApplicationContext}"/></param>
        public ApplicationContext(DbContextOptions<ApplicationContext> @options) : base(@options)
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{ApplicationRole}"/>
        /// </summary>
        public virtual DbSet<ApplicationRole> ApplicationRole { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{ApplicationRoleClaim}"/>
        /// </summary>
        public virtual DbSet<ApplicationRoleClaim> ApplicationRoleClaim { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{ApplicationUser}"/>
        /// </summary>
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{ApplicationUserClaim}"/>
        /// </summary>
        public virtual DbSet<ApplicationUserClaim> ApplicationUserClaim { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{ApplicationUserLogin}"/>
        /// </summary>
        public virtual DbSet<ApplicationUserLogin> ApplicationUserLogin { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{ApplicationUserRole}"/>
        /// </summary>
        public virtual DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{ApplicationUserToken}"/>
        /// </summary>
        public virtual DbSet<ApplicationUserToken> ApplicationUserToken { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Effort}"/>
        /// </summary>
        public virtual DbSet<Effort> Effort { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Kind}"/>
        /// </summary>
        public virtual DbSet<Kind> Kind { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Grade}"/>
        /// </summary>
        public virtual DbSet<Grade> Grade { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Absence}"/>
        /// </summary>
        public virtual DbSet<Absence> Absence { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Year}"/>
        /// </summary>
        public virtual DbSet<Year> Year { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Month}"/>
        /// </summary>
        public virtual DbSet<Month> Month { get; set; }

        /// <summary>
        /// Saves Changes Syncronously
        /// </summary>
        /// <returns>Instance of <see cref="int"/></returns>
        public override int SaveChanges()
        {
            UpdateSoftStatus();
            return base.SaveChanges();
        }

        /// <summary>
        /// Saves Changes Asyncronously
        /// </summary>
        /// <returns>Instance of <see cref="Task{int}"/></returns>
        public async Task<int> SaveChangesAsync()
        {
            UpdateSoftStatus();
            return await base.SaveChangesAsync();
        }

        /// <summary>
        /// Overrides Tracking
        /// </summary>
        private void UpdateSoftStatus()
        {
            foreach (EntityEntry entity in ChangeTracker.Entries())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.CurrentValues["LastModified"] = DateTime.Now;
                        entity.State = EntityState.Added;
                        entity.CurrentValues["Deleted"] = false;
                        break;

                    case EntityState.Modified:
                        entity.CurrentValues["LastModified"] = DateTime.Now;
                        entity.State = EntityState.Modified;
                        entity.CurrentValues["Deleted"] = false;
                        break;

                    case EntityState.Deleted:
                        entity.CurrentValues["LastModified"] = DateTime.Now;
                        entity.State = EntityState.Modified;
                        entity.CurrentValues["Deleted"] = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Overrides Model Creation
        /// </summary>
        /// <param name="modelBuilder">Injected <see cref="ModelBuilder"/></param>
        protected override void OnModelCreating(ModelBuilder @modelBuilder)
        {
            base.OnModelCreating(@modelBuilder);

            @modelBuilder.AddCustomizedIdentities();

            @modelBuilder.AddCustomizedFilters();
        }
    }
}

