﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace DoAnWeb.Models
{
    public class MailHelper
    {
        public void SendMail(string toEmailAddress, string subject, string content)
        {
            var AuthenUser = ConfigurationManager.AppSettings["AuthenUser"].ToString();
            var AuthenPassWord = ConfigurationManager.AppSettings["AuthenPassWord"].ToString();
            var portPT = ConfigurationManager.AppSettings["Port"].ToString();
            var hostPT = ConfigurationManager.AppSettings["Host"].ToString();


            bool EnabledSs1 = bool.Parse(ConfigurationManager.AppSettings["EnableSSL"].ToString());

            // MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAddress));

            MailMessage message = new MailMessage(new MailAddress(AuthenUser), new MailAddress(toEmailAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = content;

            var client = new SmtpClient();
            client.UseDefaultCredentials = false;

            client.Credentials = new NetworkCredential(AuthenUser, AuthenPassWord);
            client.Port = int.Parse(portPT);
            client.Host = hostPT;
            client.Send(message);

        }
    }
}