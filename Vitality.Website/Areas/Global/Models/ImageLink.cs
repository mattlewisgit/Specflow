namespace Vitality.Website.Areas.Global.Models
{
    using Glass.Mapper.Sc.Fields;

    public class ImageLink : SitecoreItem
    {
        public Link Link { get; set; }
        public Image Image { get; set; }
    }
}