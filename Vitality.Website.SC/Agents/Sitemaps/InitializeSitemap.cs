namespace Vitality.Website.SC.Agents.Sitemaps
{
    using Sitecore.Configuration;
    using Sitecore.Jobs;
    using Sitecore.Pipelines;
    using Sitecore.Xml;
    using System;
    using System.Collections.ObjectModel;
    using System.Xml;

    public class InitializeSitemap
    {
        public ReadOnlyCollection<string> Names =
            new ReadOnlyCollection<string>(new []
            {
                "advisersitemapgenerator",
                "presalessitemapgenerator"
            });

        public void Process(PipelineArgs args)
        {
            foreach (XmlNode node in Factory.GetConfigNodes("scheduling/agent"))
            {
                var obj = Factory.CreateObject(node, true);
                var name = XmlUtil.GetAttribute("name", node);

                if (Names.Contains(name.ToLower()))
                {
                    var method = XmlUtil.GetAttribute("method", node);

                    var options = new JobOptions(name, string.Empty, "scheduler", obj, method)
                    {
                        AtomicExecution = true,
                        InitialDelay = TimeSpan.FromSeconds(30)
                    };

                    JobManager.Start(options);
                }
            }
        }
    }
}
