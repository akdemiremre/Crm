using Crm.Common;
using Crm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crm.WebApp.Init
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            if (HttpContext.Current.Session["login"] != null)
            {
                User user = HttpContext.Current.Session["Login"] as User;
                return user.Username;
            }
            // return null;
            return "system";
        }
    }
}