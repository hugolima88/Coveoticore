using System.Web.Mvc;
using Coveoticore.Website.Models;
using Sitecore.Mvc.Presentation;

namespace Coveoticore.Website.Controllers
{
    public class CoveoticoreController : Controller
    {
        public ActionResult USPC()
        {
            var model = new USPCModel();
            model.Initialize(RenderingContext.CurrentOrNull.Rendering);

            return View(model);
        }
    }
}
