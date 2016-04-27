<%@ WebService Language="C#" Class="PackageInstaller" %>
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Services;
using System.Xml;

using log4net;
using log4net.Config;

using Sitecore.IO;
using Sitecore.SecurityModel;
using Sitecore.Update;
using Sitecore.Update.Installer;
using Sitecore.Update.Installer.Utils;
using Sitecore.Update.Utils;

/// <summary>
/// Summary description for PackageInstaller
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class PackageInstaller : WebService
{
    [WebMethod]
    public void InstallUpdatePackage(string packageName)
    {
        var log = LogManager.GetLogger("root");
        XmlConfigurator.Configure((XmlElement)ConfigurationManager.GetSection("log4net"));

        var packagePath = HttpContext.Current.Server.MapPath(Path.Combine("/upload/" + packageName));
        var file = new FileInfo(packagePath);
        if (!file.Exists)
        {
            throw new HttpException(404, string.Format("Could not find Sitecore package '{0}'", packageName));
        }

        using (new SecurityDisabler())
        {
            string historyPath = null;
            List<ContingencyEntry> entries = null;

            try
            {
                var installer = new DiffInstaller(UpgradeAction.Upgrade);
                var view = UpdateHelper.LoadMetadata(packagePath);

                //Get the package entries
                bool hasPostAction;
                entries = installer.InstallPackage(
                    packagePath,
                    InstallMode.Install,
                    log,
                    out hasPostAction,
                    out historyPath);

                installer.ExecutePostInstallationInstructions(
                    packagePath,
                    historyPath,
                    InstallMode.Install,
                    view,
                    log,
                    ref entries);

                HttpContext.Current.Response.Write(string.Format("Successfully installed package '{0}'", packageName));
            }
            catch (Exception ex)
            {
                throw new HttpException(500, string.Format("Failed to install package '{0}'", packageName), ex);
            }
            finally
            {
                string path = Path.Combine(historyPath, "messages.xml");

                FileUtil.EnsureFolder(path);

                using (FileStream fileStream = File.Create(path))
                {
                    new XmlEntrySerializer().Serialize(entries, fileStream);
                }    
            }
        }
    }
}