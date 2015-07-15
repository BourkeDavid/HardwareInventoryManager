﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardwareInventoryManager.Services
{
    /// <summary>
    /// Application Wide Enums
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Enum for Lookup Types or Lookup categories
        /// </summary>
        public enum LookupTypes
        {
            Make,
            Category,
            WarrantyPeriod
        }

        /// <summary>
        /// Enum for Toastr alert options
        /// </summary>
        public enum Alerts
        {
            Success,
            Warning,
            Info,
            Error
        }

        /// <summary>
        /// Enum for application roles
        /// </summary>
        public enum Roles
        {
            Admin,
            Author,
            Viewer
        }
    }
}