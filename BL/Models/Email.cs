using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace BL.Models
{
    public static class Email
    {
        //internal const string MessegesFilePath = @"D:\strauss&porush\מעודכן 16.07.19\ServerSide\BLL\BLL\MessegesXML.xml";
        public static void SendEmail(string contactAddress, string subject, string body)
        {
            var linkedResource = new LinkedResource(@"C:\Users\admin-c\Desktop\MDB-Angular-Free\src\assets\logo1-removebg-preview.png", MediaTypeNames.Image.Jpeg);
            string FromMail = "twonav11@gmail.com";
            var htmlBody = $"{body}<img src=\"cid:{linkedResource.ContentId}\"/>";
            var alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(linkedResource);
            string emailTo = contactAddress;
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(FromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            mail.AlternateViews.Add(alternateView);
            //mail.AlternateViews.Add(GetEmbeddedImage(@"C:\Users\admin-c\Downloads\06012021133752A.png"));
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("twonav11@gmail.com", "323900092");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);

        }

        private static AlternateView GetEmbeddedImage(String filePath)
        {
            LinkedResource res = new LinkedResource(filePath);
            res.ContentId = Guid.NewGuid().ToString();
            string htmlBody = @"<img src='cid:" + res.ContentId + @"'/>";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }

    }
}
