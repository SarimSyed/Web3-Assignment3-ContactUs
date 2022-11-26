using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.UI.Services;

/*
* Course: 		Web Programming 3
* Assessment: 	Assignment XYZ
* Created by: 	Sarim Syed
* Date: 		9 Nov 2022
* Class Name: 	SendGridEmailSender.cs
* Description: Handles emails being sent so that they can be sent properly 
       */


namespace Web3_Assignment3_ContactUs.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        public SendGridEmailSender(
            IOptions<SendGridEmailSenderOptions> options
            )
        {
            this.Options = options.Value;
        }
        public SendGridEmailSenderOptions Options { get; set; }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await Execute(Options.APIKey, subject, htmlMessage, email);
        }

        public async Task SendGmailAsync(string email, string subject, string htmlMessage)
        {
            
            await Execute(Options.APIKey, subject, htmlMessage, email);
        }



        private async Task<Response> Execute(
            string apiKey,
            string subject,
            string message,
            string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(Options.SenderEmail, Options.SenderName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            //Temporarily hardcoding email
            var from = new EmailAddress("a.sarimsyed@gmail.com", "The Company");
            List<EmailAddress> emailAddresses = new List<EmailAddress>();
            emailAddresses.Add(from);
            
            msg.AddCcs(emailAddresses);
            msg.AddTo(new EmailAddress(email));

            //Disable tracking settings

            msg.SetClickTracking(false, false);
            msg.SetOpenTracking(false);
            msg.SetGoogleAnalytics(false);
            msg.SetSubscriptionTracking(false);

            return await client.SendEmailAsync(msg);
        }


    }
}
