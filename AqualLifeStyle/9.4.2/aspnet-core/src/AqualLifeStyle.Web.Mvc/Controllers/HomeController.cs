using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AqualLifeStyle.Controllers;

namespace AqualLifeStyle.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : AqualLifeStyleControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
