using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovie.Services
{
    public class MessageService : IMessageService
    {
        public string GetWelcomeMessage()
        {
            return "Welcome to Ninject Welcome Message";
        }
    }
}