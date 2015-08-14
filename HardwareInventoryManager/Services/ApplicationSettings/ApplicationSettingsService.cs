﻿using HardwareInventoryManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardwareInventoryManager.Services.ApplicationSettings
{
    /// <summary>
    /// Application Settings Service
    /// TODO: Replace methods here with connection to the database, currently this is
    /// only a stub.
    /// </summary>
    public class ApplicationSettingsService : IApplicationSettingsService
    {

        string IApplicationSettingsService.GetEmailServiceUsername()
        {
            return string.Empty;
        }

        string IApplicationSettingsService.GetEmailServiceKeyCode()
        {
            return string.Empty;
        }

        string IApplicationSettingsService.GetEmailServiceSenderEmailAddress()
        {
            return string.Empty;
        }

        EnumHelper.EmailServiceTypes IApplicationSettingsService.GetEmailServiceOnlineType()
        {
            return EnumHelper.EmailServiceTypes.Offline;
        }
    }
}