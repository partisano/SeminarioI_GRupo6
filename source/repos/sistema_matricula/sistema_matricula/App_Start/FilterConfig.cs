﻿using System.Web;
using System.Web.Mvc;

namespace sistema_matricula
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
