using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduler.Utility
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailjetClient client = new MailjetClient("1fdaaeb17bf7eb1fe6b17c1f67ee2d02", "035ba6d937ac51dbc01e78c579f0a921")
            {
                
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
               .Property(Send.FromEmail, "delishkhadka@gmail.com")
               .Property(Send.FromName, "Apppointment scheduler")
               .Property(Send.Subject, subject)
               .Property(Send.HtmlPart, htmlMessage)
               .Property(Send.Recipients, new JArray {
                new JObject {
                 {"Email", email}
                 }
                   });
            MailjetResponse response = await client.PostAsync(request);

        }
    }
}
