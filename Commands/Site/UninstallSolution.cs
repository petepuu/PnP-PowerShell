﻿using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Site
{
    [Cmdlet(VerbsLifecycle.Uninstall, "PnPSolution")]
    [CmdletAlias("Uninstall-SPOSolution")]
    [CmdletHelp("Uninstalls a sandboxed solution from a site collection",
        Category = CmdletHelpCategory.Sites)]
    public class UninstallSolution : SPOCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage="ID of the solution, from the solution manifest")]
        public GuidPipeBind PackageId;

        [Parameter(Mandatory = true, HelpMessage="Filename of the WSP file to uninstall")]
        public string PackageName;

        [Parameter(Mandatory = false, HelpMessage = "Optional major version of the solution, defaults to 1")]
        public int MajorVersion = 1;

        [Parameter(Mandatory = false, HelpMessage = "Optional minor version of the solution, defaults to 0")]
        public int MinorVersion = 0;

        protected override void ExecuteCmdlet()
        {
            ClientContext.Site.UninstallSolution(PackageId.Id, PackageName, MajorVersion, MinorVersion);
        }
    }
}
