using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ZuydRPG_EF.HelperClasses
{
    public static class Utils
    {
        public static void ShowMessage(Page page,string message)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + message + "')", true);
        }
    }
}