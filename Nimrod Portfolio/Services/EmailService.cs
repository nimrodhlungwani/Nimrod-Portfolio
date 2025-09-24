using Nimrod_Portfolio.Models;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace DAASWeb.Services
{
    public interface IEmailService
    {
        void SendEmail(Mail model);
    }

    public class EmailService : IEmailService
    {
        private void SendMail(string toEmail, string toDisplay, string fromEmail, string fromDisplay, string subject, string htmlBody, string textBody)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail, fromDisplay),
                Subject = subject
            };

            var avHtml = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            var avText = AlternateView.CreateAlternateViewFromString(textBody, null, MediaTypeNames.Text.Plain);

            mailMessage.AlternateViews.Add(avHtml);
            if (!string.IsNullOrWhiteSpace(textBody))
                mailMessage.AlternateViews.Add(avText);

            // Handle multiple recipients
            var toEmails = toEmail.Split(';');
            var toDisplays = toDisplay.Split(';');
            for (int i = 0; i < toEmails.Length; i++)
            {
                var email = toEmails[i].Trim();
                var display = (i < toDisplays.Length ? toDisplays[i] : "").Trim();
                mailMessage.To.Add(new MailAddress(email, display));
            }

            var smtpClient = new SmtpClient("172.20.7.19");
            smtpClient.Send(mailMessage);
        }

        private void AddRow(StringBuilder emailBody, string label, string value)
        {
            emailBody.AppendLine("<tr>");
            emailBody.AppendLine($"<td style=\"background-color:#e0e0de; border-color:#044b89; border-style:solid; border-width:1px; color:#044b89; font-family:Arial, sans-serif; font-size:14px; font-weight:bold; padding:5px 5px; white-space: nowrap;\">{label}:</td>");
            emailBody.AppendLine($"<td style=\"background-color:#e0e0de; border-color:#044b89; border-style:solid; border-width:1px; color:#044b89; font-family:Arial, sans-serif; font-size:14px; padding:5px 5px; text-align:left; word-break:normal;\">{value}</td>");
            emailBody.AppendLine("</tr>");
        }

        public void SendEmail(Mail model)
        {
            var emailBody = new StringBuilder();
            var textBody = new StringBuilder();

            emailBody.AppendLine("<html><body>");
            emailBody.AppendLine("<p style=\"color:#044b89; font-family:Arial, sans-serif; font-size:14px; font-weight:bold; padding:5px 5px; word-break:normal;\">Free Assessment Form Submission Details :</p>");
            emailBody.AppendLine("<table style=\"border-collapse:collapse; border-color:#9ABAD9; border-spacing:0;\">");
            emailBody.AppendLine("<tbody>");
            AddRow(emailBody, "Name & Surname", WebUtility.HtmlEncode(model.Name));
            AddRow(emailBody, "Email", WebUtility.HtmlEncode(model.Email)); 
            AddRow(emailBody, "Contact", WebUtility.HtmlEncode(model.Contact));
            AddRow(emailBody, "Message", WebUtility.HtmlEncode(model.Message));
            emailBody.AppendLine("</tbody>");
            emailBody.AppendLine("</table>");
            emailBody.AppendLine("</body></html>");

            textBody.AppendLine("Free Assessment form submission details:");
            textBody.AppendLine($"Name & Surname: \t{model.Name}");
            textBody.AppendLine($"Email: \t\t\t{model.Email}");
            textBody.AppendLine($"Contact: \t\t{model.Contact}");
            textBody.AppendLine($"Message: \t\t{model.Message}");

            SendMail("hlungwaninimrod@gmail.com", "Nimrod Hlungwani", "hlungwaninimrod@gmail.com", model.Name, model.Subject, emailBody.ToString(), textBody.ToString());
        }
    }
}
