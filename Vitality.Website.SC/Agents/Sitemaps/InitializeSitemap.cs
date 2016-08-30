using System.Collections.Generic;
using System.Linq;

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
        public List<string> Names = new List<string>() { "advisersitemapgenerator", "presalessitemapgenerator" };

        public void Process(PipelineArgs args)
        {
            foreach (XmlNode node in Factory.GetConfigNodes("scheduling/agent"))
            {
                object obj = Factory.CreateObject(node, true);
                string name = XmlUtil.GetAttribute("name", node);
                
                if (Names.Contains(name.ToLower()))
                {
                    string method = XmlUtil.GetAttribute("method", node);

                    var options = new JobOptions(name, "", "scheduler", obj, method)
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
