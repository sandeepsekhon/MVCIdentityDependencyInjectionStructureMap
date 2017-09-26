using MVCDependencyInjectionWithIdentity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDependencyInjectionWithIdentity.Providers
{
    public class MessageProvider : IMessageProvider
    {
        public string GetMessage()
        {
            return "Message from Ioc : I am from MessageProvider.";
        }
    }
}