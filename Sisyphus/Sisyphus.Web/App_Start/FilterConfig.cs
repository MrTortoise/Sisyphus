﻿namespace Sisyphus.Web
{
    using System.Web.Mvc;

#pragma warning disable 1591
    public class FilterConfig

    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

#pragma warning restore 1591