﻿<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="log4net" %>
<%@ Import Namespace="Sitecore.Data.Engines" %>
<%@ Import Namespace="Sitecore.Data.Proxies" %>
<%@ Import Namespace="Sitecore.SecurityModel" %>
<%@ Import Namespace="Sitecore.Update" %>
<%@ Import Namespace="Sitecore.Update.Installer" %>
<%@ Import Namespace="Sitecore.Update.Installer.Exceptions" %>
<%@ Import Namespace="Sitecore.Update.Installer.Installer.Utils" %>
<%@ Import Namespace="Sitecore.Update.Installer.Utils" %>
<%@ Import Namespace="Sitecore.Update.Utils" %>

<%@  Language="C#" %>
<html>
<script runat="server" language="C#">
    public void Page_Load(object sender, EventArgs e)
    {
        var files = Directory.GetFiles(Server.MapPath("/sitecore/admin/Packages"), "*.update", SearchOption.AllDirectories);
        Sitecore.Context.SetActiveSite("shell");
        using (new SecurityDisabler())
        {
            using (new ProxyDisabler())
            {
                using (new SyncOperationContext())
                {
                    foreach (var file in files)
                    {
                        Install(file);
                        Response.Write("Installed Package: " + file + "<br>");
                    }
                }
            }
        }
    }
    protected static string Install(string package)
    {
        var log = LogManager.GetLogger("LogFileAppender");
        string result;
        using (new ShutdownGuard())
        {
            var installationInfo = new PackageInstallationInfo
            {
                Action = UpgradeAction.Upgrade,
                Mode = InstallMode.Install,
                Path = package
            };
            string text = null;
            List<ContingencyEntry> entries = null;
            try
            {
                entries = UpdateHelper.Install(installationInfo, log, out text);
            }
            catch (PostStepInstallerException ex)
            {
                entries = ex.Entries;
                text = ex.HistoryPath;
                throw;
            }
            finally
            {
                string path = Path.Combine(text, "messages.xml");

                FileUtil.EnsureFolder(path);

                using (FileStream fileStream = File.Create(path))
                {
                    new XmlEntrySerializer().Serialize(entries, fileStream);
                }
            }
            result = text;
        }
        return result;
    }

    protected String GetTime()
    {
        return DateTime.Now.ToString("t");
    }
</script>
<body>
    <form id="MyForm" runat="server">
        <div>This page installs packages from \sitecore\admin\Packages folder.</div>
        Current server time is <% =GetTime()%>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstallPackages.aspx.cs" Inherits="Vitality.Website._Tools.InstallPackages" %>

<%@ Import Namespace="Sitecore.IO" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
