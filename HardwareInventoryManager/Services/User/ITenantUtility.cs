﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryManager.Helpers.User
{
    public interface ITenantUtility
    {
        int GetTenantIdFromEmail(string emailAddress);
        int GetTenantIdFromUserId(string userId);
    }
}
