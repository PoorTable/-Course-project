﻿using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
namespace kp2.Services
{
    public class EmailService
    {
            public async Task SendEmailAsync(string email, string subject, string message)
            {
                var emailMessage = new MimeMessage();
 
                emailMessage.From.Add(new MailboxAddress("Администрация сайта Курсового проекта kp2", "ReadMyLoginEqualsGay@yandex.by"));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };
             
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.yandex.ru", 25, false);
                    await client.AuthenticateAsync("ReadMyLoginEqualsGay@yandex.by", "ass123456789ass");
                    await client.SendAsync(emailMessage);
 
                    await client.DisconnectAsync(true);
                }
            }
    }
}
