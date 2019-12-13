﻿using System;
using System.Web.UI;

namespace DotNetNuke.Modules.DigitalAssets
{
    public static class ClientDialog
    {
        public static void CloseClientDialog(this Page page, bool refresh)
        {
            var script = "parent.window.dnnModule.digitalAssets.closeDialog(" + (refresh ? "true" : "false") + ");";
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "CloseDialogScript", script, true);
        }
    }
}
