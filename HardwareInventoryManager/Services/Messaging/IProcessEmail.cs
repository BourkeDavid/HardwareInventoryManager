﻿using HardwareInventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardwareInventoryManager.Helpers.Messaging
{
    public interface IProcessEmail
    {
        void SendPasswordResetEmail(ApplicationUser recipientUser, string callbackUrl);
        void SendEmailConfirmationEmail(ApplicationUser recipientUser, string callbackUrl);
        void SendNewAccountSetupEmail(ApplicationUser recipientUser);
        void SendEmail(string senderEmailAddress, string[] recipientsEmailAddresses, string subject, string body);
    }
}