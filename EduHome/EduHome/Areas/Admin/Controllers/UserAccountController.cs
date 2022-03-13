using EduHome.Areas.Admin.ViewModels;
using EduHome.DataAccessLayer;
using EduHome.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class UserAccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _dbContext;

        public UserAccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager = null, AppDbContext dbContext = null)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int take = 10;
            ViewBag.currentpage = page;
            var users = await _userManager.Users.Skip((page - 1) * take).Take(take).ToListAsync();
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _dbContext.UserRoles.ToListAsync();
            if (users == null && roles == null && userRoles == null)
            {
                return NotFound();
            }
  
            return View(users);
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            if (id == null)
                return BadRequest();

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string id, ChangePasswordViewModel changePasswordViewModel)
        {
            if (id == null)
                return NotFound();

            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("", "Try again");

            //    return View();
            //}

            var user = await _userManager.FindByNameAsync(changePasswordViewModel.Username);
            if (user == null)
            {
                return BadRequest();
            }

            var result = await _userManager.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();
            }

            return RedirectToAction(nameof(Index), "Dashboard");
        }

        public async Task<IActionResult> ChageUserStatus(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await this._userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ChageUserStatus")]
        public async Task<IActionResult> ChangeUserActivityStatus(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await this._userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            if (user.IsDeleted)
            {
                user.IsDeleted = false;
            }
            else if (!user.IsDeleted)
            {
                user.IsDeleted = true;

            }

            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> ChangeRol(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            string role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            if (role == null)
            {
                return BadRequest();
            }
            ViewBag.CurrentRole = role;

            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ChangeRol(string id, string NewRole)
        {
            if (id == null && NewRole == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            string exRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            if (exRole == null)
            {
                return NotFound();
            }
            if (exRole != NewRole)
            {
                var result = await _userManager.AddToRoleAsync(user, NewRole);
                if (!result.Succeeded)
                {

                    ModelState.AddModelError("", "This is Problem");

                }
                var RemoveRole = await _userManager.RemoveFromRoleAsync(user, exRole);
                if (RemoveRole.Succeeded)
                {
                    ModelState.AddModelError("", "This is problem");
                }
                await _userManager.UpdateAsync(user);

            }

            return RedirectToAction(nameof(Index));

        }

    }
}
