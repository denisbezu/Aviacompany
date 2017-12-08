using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Aviacompany.Library.Models;
using Microsoft.AspNet.Identity;

namespace Aviacompany.Controllers
{
   // [Authorize(Roles = "Administrators")]
    public class RoleAdminController : BaseController
    {

        public ActionResult Index()
        {
            var users = UserManager.Users.Include(u => u.Roles).ToList();//спросить
            return View(RoleManager.Roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Required]string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result
                    = await RoleManager.CreateAsync(new AppRole(name));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(name);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            AppRole role = await RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await RoleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("CustomError", result.Errors);
                }
            }
            else
            {
                return View("CustomError", new string[] { "Роль не найдена" });
            }
        }

        public async Task<ActionResult> Edit(string id)
        {
            var users = UserManager.Users.Include(u => u.Roles).ToList();//тоже
            AppRole role = await RoleManager.FindByIdAsync(id);
            
            string[] memberIDs = role.Users.Select(x => x.UserId).ToArray();

            IEnumerable<AppUser> members
                = UserManager.Users.Include(u => u.Roles).Where(x => memberIDs.Any(y => y == x.Id));

            IEnumerable<AppUser> nonMembers = UserManager.Users.Include(u => u.Roles).Except(members);

            return View(new RoleEditModel
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RoleModificationModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.IdsToAdd ?? new string[] { })
                {
                    result = await UserManager.AddToRoleAsync(userId, model.RoleName);

                    if (!result.Succeeded)
                    {
                        return View("CustomError", result.Errors);
                    }
                }
                foreach (string userId in model.IdsToDelete ?? new string[] { })
                {
                    result = await UserManager.RemoveFromRoleAsync(userId,
                        model.RoleName);

                    if (!result.Succeeded)
                    {
                        return View("", result.Errors);
                    }
                }
                return RedirectToAction("Index");

            }
            return View("CustomError", new string[] { "Роль не найдена" });
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}