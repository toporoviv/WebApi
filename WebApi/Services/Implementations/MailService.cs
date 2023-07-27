using Microsoft.EntityFrameworkCore;
using WebApi.Data.DataEntities;
using WebApi.Repositories.Interfaces;
using WebApi.Responses;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    /// <summary>
    /// Сервис для работы с сообщениями
    /// </summary>
    public class MailService : IMailService
    {
        private readonly IRepository<MailLog> _mailLogRepository;
        private readonly IRepository<MailMessage> _mailMessageRepository;
        private readonly IRepository<MailRecipient> _mailRecipientRepository;
        private readonly IRepository<Recipient> _recipientRepository;

        public MailService(
            IRepository<MailLog> mailLogRepository,
            IRepository<MailMessage> mailMessageRepository,
            IRepository<MailRecipient> mailRecipientRepository,
            IRepository<Recipient> recipientRepository)
        {
            _mailLogRepository = mailLogRepository;
            _mailMessageRepository = mailMessageRepository;
            _mailRecipientRepository = mailRecipientRepository;
            _recipientRepository = recipientRepository;
        }

        /// <summary>
        /// Получение информации для Get запроса
        /// </summary>
        /// <returns></returns>
        public async Task<MailResponse[]> GetMailInformation()
        {
            return await _mailMessageRepository
                .GetAll()
                .Join(_mailLogRepository.GetAll(), x => x.Id, y => y.MessageId, (message, log) => new { message, log })
                .Select(x => new MailResponse
                {
                    Body = x.message.Body,
                    Subject = x.message.Subject,
                    CreatedDate = x.log.CreatedDate,
                    Result = x.log.Result,
                    FailedMessage = x.log.FailedMessage,
                    Recipients = _recipientRepository
                        .GetAll()
                        .Join(_mailRecipientRepository.GetAll(), q => q.Id, t => t.RecipientId, (q, t) => new { q, t })
                        .Where(qt => qt.t.MessageId == x.message.Id)
                        .Select(qt => qt.q.Email)
                        .ToArray()
                })
                .ToArrayAsync();
        }
    }
}
