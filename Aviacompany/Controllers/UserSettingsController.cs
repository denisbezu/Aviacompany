using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Aviacompany.Library.Models;
using Microsoft.AspNet.Identity;

namespace Aviacompany.Controllers
{
    public class UserSettingsController : BaseController
    {
        [Authorize]
        public async Task<ActionResult> EditUser()
        {
            AppUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            ViewBag.RoleManager = RoleManager.Roles;
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> EditUser(string id, string email, string phoneNumber, string password)
        {
            AppUser user = await UserManager.FindByIdAsync(id);
            ViewBag.RoleManager = RoleManager.Roles;
            if (user != null)
            {
                user.Email = email;

                IdentityResult validEmail
                    = await UserManager.UserValidator.ValidateAsync(user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                bool validPhone = true;
                if (Regex.IsMatch(phoneNumber, @"(^\+?[0-9]+$)|(^$)"))
                    user.PhoneNumber = phoneNumber;
                else
                {
                    validPhone = false;
                    ModelState.AddModelError("", "Неверный номер телефона");
                }
                IdentityResult validPass = null;
                if (password != string.Empty)
                {
                    validPass
                        = await UserManager.PasswordValidator.ValidateAsync(password);

                    if (validPass.Succeeded)
                    {
                        user.PasswordHash =
                            UserManager.PasswordHasher.HashPassword(password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }

                if ((validEmail.Succeeded && validPass == null && validPhone) ||
                    (validEmail.Succeeded && password != string.Empty && validPass.Succeeded && validPhone))
                {
                    IdentityResult result = await UserManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }
            return View(user);
        }

        public ActionResult Error()
        {
            return View();
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