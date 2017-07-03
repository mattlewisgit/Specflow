namespace Vitality.Website.Areas.Presales.BaseTemplates
{
    using Glass.Mapper.Sc.Fields;

    public interface IOpenGraphPage
    {
        string OpenGraphTitle { get; set; }
        string OpenGraphType { get; set; }
        string OpenGraphUrl { get; set; }
        Image OpenGraphImage { get; set; }
        string OpenGraphSiteName { get; set; }
        string OpenGraphDescription { get; set; }
    }
}
