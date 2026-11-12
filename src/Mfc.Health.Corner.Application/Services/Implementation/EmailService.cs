using MailKit.Net.Smtp;
using Mfc.Health.Corner.Application.Services.Interfaces;
using MimeKit;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Mfc.Health.Corner.Common;
using System;
using Mfc.Health.Corner.Application.Common;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class EmailService : IEmailService
    {

        public EmailService()
        {
        }

        public async Task<OperationResult> SendEmailAsync(StandartEmailSettings standartSettings, string email, string subject, string message)
        {
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(standartSettings.SenderName, standartSettings.FromEmail));

                emailMessage.To.Add(new MailboxAddress("", email));

                emailMessage.Subject = subject;

                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(standartSettings.Host, standartSettings.Port, false);

                    await client.AuthenticateAsync(standartSettings.Login, standartSettings.Password);

                    var cancellationDelayTimeout = TimeSpan.FromSeconds(Convert.ToInt32(standartSettings.Timeout));
                    using (var cts = new System.Threading.CancellationTokenSource(cancellationDelayTimeout))
                    {
                        await client.SendAsync(emailMessage, cts.Token);
                        if (cts.IsCancellationRequested)
                        {
                            return OperationResult.Error("Error sending email: the time sent has expired", OperationCode.SendEmailError);
                        }
                    }
                    await client.DisconnectAsync(true);
                }
                return OperationResult.Ok();
            }
            catch (Exception e)
            {
                return OperationResult.Error(e.Message, OperationCode.SendEmailError);
            }
        }

        public async Task<OperationResult> CheckSmtpConnection(StandartEmailSettings standartSettings)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(standartSettings.Host, standartSettings.Port, false);

                    await client.AuthenticateAsync(standartSettings.Login, standartSettings.Password);
                }
                return  OperationResult.Ok();
            }
            catch (Exception ex)
            {
                return  OperationResult.Error("SMTP connaction Failed");
            }
        }


    }
}
