﻿using HardwareInventoryManager.Models;
using HardwareInventoryManager.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HardwareInventoryManager.Filters
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            
            bool isAuthor = HttpContext.Current.User.IsInRole(EnumHelper.Roles.Author.ToString());
            bool isAdmin = HttpContext.Current.User.IsInRole(EnumHelper.Roles.Admin.ToString());
            bool isViewer = HttpContext.Current.User.IsInRole(EnumHelper.Roles.Viewer.ToString());

            string action = filterContext.Controller.ControllerContext.RouteData.Values["action"].ToString();
            string controller = filterContext.Controller.ControllerContext.RouteData.Values["controller"].ToString();

            if (!HttpContext.Current.User.IsInRole(EnumHelper.Roles.Author.ToString())
           && !HttpContext.Current.User.IsInRole(EnumHelper.Roles.Admin.ToString()))
            {
                if (filterContext.Controller.ControllerContext.RouteData.Values["action"].ToString() ==
                    "Edit"

                    ||
                    filterContext.Controller.ControllerContext.RouteData.Values["action"].ToString() ==
                   "Delete")
                {
                    HandleUnauthorizedRequest(filterContext);
                }
            }

        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext);
        }
    }
}