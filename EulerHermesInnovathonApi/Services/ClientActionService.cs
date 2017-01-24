using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathonApi.Services
{
    public class ClientActionService
    {
        private static object __sync = new object();
        private static ClientActionService __Instance;

        public static ClientActionService Instance
        {
            get
            {
                if (__Instance == null)
                    lock(__sync)
                        if(__Instance == null)
                            __Instance = new ClientActionService();
                return __Instance;
            }
        }

        public void RegisterForSms(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public void RegisterForEmail(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public void RegisterForCallback(string callbackUri)
        {
            throw new NotImplementedException();
        }

        public void PerformClientActions()
        {
            throw new NotImplementedException();
        }
    }
}