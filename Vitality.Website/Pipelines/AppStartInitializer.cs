using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Pipelines;
using Vitality.Website.App_Start;

namespace Vitality.Website.Pipelines
{
    /// <summary>
    /// Sitecore 8.2 changed App_Start to internal method which stops Overriding using Global.asax App_Start method.
    /// So Global.asax App_Start never fires. It is a b-ug (#126372) but recomonded way is to use Pipelines to inilize
    /// https://sitecore.stackexchange.com/questions/2305/global-asax-application-start-not-hit-after-upgrade-to-sitecore-8-2
    /// </summary>
    public class AppStartInitializer : Sitecore.Mvc.Pipelines.Loader.InitializeRoutes
    {
        public override void Process(PipelineArgs args)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MvcHandler.DisableMvcResponseHeader = true;
            MapperConfig.Init();
        }
    }
}
