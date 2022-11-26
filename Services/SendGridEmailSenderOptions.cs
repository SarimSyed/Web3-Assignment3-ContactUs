using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/*
* Course: 		Web Programming 3
* Assessment: 	Assignment XYZ
* Created by: 	Sarim Syed
* Date: 		9 Nov 2022
* Class Name: 	SendGridEmailSenderOptions.cs
* Description: Important sendgrid info is saved using this class
       */
namespace Web3_Assignment3_ContactUs.Services
{
    public class SendGridEmailSenderOptions
    {
        public string APIKey { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
    }
}
