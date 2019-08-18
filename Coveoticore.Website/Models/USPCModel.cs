using Coveoticore.Website.Sitecore;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Coveoticore.Website.Models
{
    //[SitecoreType(TemplateId = Templates.USPC, AutoMap = true)]
    public class USPCModel
    {
        public virtual string ID { get; set; }

        public virtual string Field1 { get; set; }

        public virtual string Field2 { get; set; }

        public virtual string Field3 { get; set; }

        public virtual int Field4 { get; set; }

        public virtual string Field5 { get; set; }

    }
}
