using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.Classes
{
    static partial class AzureService
    {
        private static MobileServiceClient s_AzureService;
        private static bool s_IsConnected;

        public static void Connect()
        {
            s_AzureService = new MobileServiceClient(kLogin, kPassword);
            s_IsConnected = true;
        }

        public static void Disconnect()
        {
            s_AzureService.Logout();
            s_AzureService.Dispose();
            s_AzureService = null;

            s_IsConnected = false;
        }

        public static MobileServiceClient Get()
        {
            if (!s_IsConnected)
            {
                throw new InvalidOperationException("You are not connected to the service!");
            }

            return s_AzureService;
        }
    }
}
