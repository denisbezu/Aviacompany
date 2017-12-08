using System.Web;
using System.Web.Mvc;
using Aviacompany.Library.Infrastrucutre;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Aviacompany.Controllers
{
    public class BaseController : Controller
    {
        protected AppRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>();
            }
        }
        protected AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
        protected IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}