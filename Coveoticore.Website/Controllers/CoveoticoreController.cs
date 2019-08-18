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
                SingleLineText = renderingItem[nameof(USPCModel.SingleLineText)],
                MultiLineText = renderingItem[nameof(USPCModel.MultiLineText)],
                DateTime = renderingItem[nameof(USPCModel.DateTime)],
                Number = long.Parse(renderingItem[nameof(USPCModel.Number)]),
                Image = renderingItem[nameof(USPCModel.Image)],
            };

            return View(model);
        }
    }
}
