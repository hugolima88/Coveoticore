using System.Web;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;

namespace Coveoticore.Website.Models
{
    public class USPCModel : RenderingModel
    {
        public HtmlString SingleLineText => new HtmlString(FieldRenderer.Render(Item, "SingleLineText"));

        public HtmlString MultiLineText => new HtmlString(FieldRenderer.Render(Item, "MultiLineText"));

        public HtmlString DateTime => new HtmlString(FieldRenderer.Render(Item, "DateTime"));

        public HtmlString Number => new HtmlString(FieldRenderer.Render(Item, "Number"));

        public HtmlString Image => new HtmlString(FieldRenderer.Render(Item, "Image"));
    }
}