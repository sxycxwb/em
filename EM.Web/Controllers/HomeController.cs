using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace EM.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : EMControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}