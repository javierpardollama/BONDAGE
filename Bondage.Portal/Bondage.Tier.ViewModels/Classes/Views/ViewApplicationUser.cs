using System;
using System.Collections.Generic;
using System.Linq;

using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    public class ViewApplicationUser : IViewKey, IViewBase
    {
        public ViewApplicationUser()
        {
        }

        public int Id { get; set; }

        public DateTime LastModified { get; set; }

        public string Email { get; set; }

        public string Initial => Email.Substring(0, 1).ToUpper();

        public virtual ICollection<ViewApplicationUserRole> ApplicationUserRoles { get; set; }

        public virtual ICollection<ViewApplicationRole> ApplicationRoles => ApplicationUserRoles?.AsQueryable().Select(x => x.ApplicationRole).ToList();

        public virtual ICollection<ViewApplicationUserToken> ApplicationUserTokens { get; set; }

        public virtual ViewApplicationUserToken ApplicationUserToken => ApplicationUserTokens?.AsQueryable().LastOrDefault();
    }
}
