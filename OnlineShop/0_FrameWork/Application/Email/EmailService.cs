using MimeKit;
using MailKit.Net.Smtp;

namespace _0_FrameWork.Application.Email
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string title, string messageBody, string destination)
        {
            var message = new MimeMessage();

            var from = new MailboxAddress("GhiasMarket", "sajjadgh1995@hotmail.com");
            message.From.Add(from);

            var to = new MailboxAddress("User", destination);
            message.To.Add(to);

            message.Subject = title;
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $"<h1>{messageBody}</h1>",
            };

            message.Body = bodyBuilder.ToMessageBody();

            var client = new SmtpClient();
            client.Connect("185.88.152.251", 25, false);
            client.Authenticate("sajjadgh1995@hotmail.com", "Sajjad8910");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}