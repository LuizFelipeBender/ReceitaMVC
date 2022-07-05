using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using SiteMVC.Settings;
using MimeKit;
using MailKit.Net.Smtp;
using System;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace SiteMVC.Services
{
    public class GMailService : IEmailSender
    {
        private readonly GMailSettings _emailSettings;

        public GMailService(IOptions<GMailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var mensagem = new MimeMessage();
            mensagem.From.Add(new MailboxAddress(_emailSettings.NomeRemetente, _emailSettings.EmailRemetente));
            mensagem.To.Add(MailboxAddress.Parse(toEmail));
            mensagem.Subject = subject;
            var builder = new BodyBuilder {  HtmlBody = message };
            mensagem.Body = builder.ToMessageBody();
            try
            {                
                var smtpClient = new SmtpClient();
                smtpClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await smtpClient.ConnectAsync(_emailSettings.EnderecoServidor, _emailSettings.PortaServidor).ConfigureAwait(false);
                await smtpClient.AuthenticateAsync(_emailSettings.EmailRemetente, _emailSettings.Senha).ConfigureAwait(false);
                await smtpClient.SendAsync(mensagem).ConfigureAwait(false);
                await smtpClient.DisconnectAsync(true).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        
    }
}