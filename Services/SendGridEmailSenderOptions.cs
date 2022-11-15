using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web3_Assignment3_ContactUs.Services
{
    public class SendGridEmailSenderOptions
    {
        public string APIKey { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
    }
}
