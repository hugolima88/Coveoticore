using System.Web.Mvc;
using Coveoticore.Website.Models;
using Sitecore.Mvc.Presentation;

namespace Coveoticore.Website.Controllers
{
    public class CoveoticoreController : Controller
    {

        public ActionResult USPC()
        {
            var renderingItem = RenderingContext.CurrentOrNull.Rendering.Item;

            var model = new USPCModel
            {
                Field1 = renderingItem[nameof(USPCModel.Field1)]
            };

            return View(model);
        }
    }
}
