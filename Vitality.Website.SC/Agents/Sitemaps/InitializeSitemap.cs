namespace Vitality.Website.SC.Agents.Sitemaps
{
    using System;
    using System.Xml;

    using Sitecore.Configuration;
    using Sitecore.Jobs;
    using Sitecore.Pipelines;
    using Sitecore.Xml;

    public class InitializeSitemap
    {
        public void Process(PipelineArgs args)
        {
            foreach (XmlNode node in Factory.GetConfigNodes("scheduling/agent"))
            {
                object obj = Factory.CreateObject(node, true);
                string name = XmlUtil.GetAttribute("name", node);

                if (name == SitemapGenerator.Name)
                {
                    string method = XmlUtil.GetAttribute("method", node);

                    var options = new JobOptions(name, "", "scheduler", obj, method)
                    {
                        AtomicExecution = true,
                        InitialDelay = TimeSpan.FromMinutes(3)
                    };
                    JobManager.Start(options);

                    break;
                }
            }
        }
    }
}
