using EduHome.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EduHome.Areas.Admin.ViewModels
{
    public class UserViewModel
    {
        public List<User> Users { get; set; }

        public List<IdentityRole> Roles { get; set; }

        public List<IdentityUserRole<string>> UserRoles { get; set; }

    }
}
