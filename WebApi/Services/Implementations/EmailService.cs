using System.Net.Mail;
using System.Net;
using WebApi.Data.DataEntities;
using WebApi.Repositories.Implementations;
using WebApi.Repositories.Interfaces;
using WebApi.Requests;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    /// <summary>
    /// Сервис по отправке сообщений на почту
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly IRepository<MailLog> _mailLogRepository;
        private readonly IRepository<Data.DataEntities.MailMessage> _mailMessageRepository;
        private readonly IRepository<Recipient> _recipientRepository;
        private readonly IRepository<MailRecipient> _mailRecipientRepository;

        public EmailService(
            IRepository<MailLog> mailLogRepository,
            IRepository<Data.DataEntities.MailMessage> mailMessageRepository,
            IRepository<MailRecipient> mailRecipientRepository,
            IRepository<Recipient> recipientRepository)
        {
            _mailLogRepository = mailLogRepository;
            _mailMessageRepository = mailMessageRepository;
            _mailRecipientRepository = mailRecipientRepository;
            _recipientRepository = recipientRepository;
        }

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <param name="request">Сущность, содержащая заголовок, сообщение и получателей</param>
        /// <returns></returns>
        public async Task SendMessage(MailRequest request)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var config = builder.Build();

            var user = config["Smtp:Username"];
            var mailLog = new MailLog();
            var message = new Data.DataEntities.MailMessage
            {
                Body = request.Body,
                Subject = request.Subject
            };

            mailLog = new MailLog
            {
                CreatedDate = DateTime.Now,
                FailedMessage = null,
                MailMessage = message,
                Result = Enums.StatusMessage.OK
            };

            for (int i = 0; i < request.Recipients.Length; i++)
            {
                try
                {
                    using (var smtpClient = new SmtpClient(config["Smtp:Host"], int.Parse(config["Smtp:Port"]))
                    {
                        Credentials = new NetworkCredential(user, config["Smtp:Password"]),
                        EnableSsl = true,
                        UseDefaultCredentials = false
                    })
                    {
                        smtpClient.Send(new System.Net.Mail.MailMessage(new MailAddress(user), new MailAddress(request.Recipients[i]))
                        {
                            Subject = request.Subject,
                            Body = request.Body
                        });
                    }
                }
                catch(Exception ex)
                {
                    mailLog.FailedMessage = ex.Message;
                    mailLog.Result = Enums.StatusMessage.Failed;
                }
                finally
                {
                    await _mailRecipientRepository.Create(new MailRecipient
                    {
                        MailMessage = message,
                        Recipient = _recipientRepository.GetAll().FirstOrDefault(x => x.Email == request.Recipients[i]),
                    });
                }
            }

            message.MailLog = mailLog;
            await _mailLogRepository.Create(mailLog);
        }
    }
}
