namespace Vitality.Website.Areas.Presales.BaseTemplates
{
    using Glass.Mapper.Sc.Fields;

    public interface ITwitterPage
    {
        string TwitterSite { get; set; }
        string TwitterTitle { get; set; }
        string TwitterDescription { get; set; }
        Image TwitterImage { get; set; }
    }
}
