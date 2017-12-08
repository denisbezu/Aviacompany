using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aviacompany.Library.Models;
using Microsoft.AspNet.Identity;

namespace Aviacompany.Controllers
{
    public class RegisterController : BaseController
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(CreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = viewModel.Name, Email = viewModel.Email };
                IdentityResult result =
                    await UserManager.CreateAsync(user, viewModel.Password);
                //var addToUsers = await UserManager.AddToRoleAsync(user.Id, "Users");
                if (result.Succeeded)
                {
                    return RedirectToAction("SeccessfullRegistration");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(viewModel);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public ActionResult SeccessfullRegistration()
        {
            return View();
        }
    }
}