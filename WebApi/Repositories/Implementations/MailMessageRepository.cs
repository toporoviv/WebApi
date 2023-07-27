using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using WebApi.Data.DataContexts;
using WebApi.Data.DataEntities;
using WebApi.Repositories.Interfaces;
using MailMessage = WebApi.Data.DataEntities.MailMessage;

namespace WebApi.Repositories.Implementations
{
    public class MailMessageRepository : IRepository<MailMessage>
    {
        private readonly ApplicationDbContext _db;

        public MailMessageRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Добавление сообщения в БД
        /// </summary>
        /// <param name="entity">Сообщение, которое нужно добавить в БД</param>
        /// <returns></returns>
        public async Task Create(MailMessage entity)
        {
            await _db.MailMessages.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление сообщения
        /// </summary>
        /// <param name="entity">Сообщение, которое нужно удалить</param>
        /// <returns></returns>
        public async Task Delete(MailMessage entity)
        {
            _db.MailMessages.Remove(entity);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Получение всех сообщений
        /// </summary>
        /// <returns></returns>
        public IQueryable<MailMessage> GetAll()
        {
            return _db.MailMessages;
        }

        /// <summary>
        /// Обновление сообщения
        /// </summary>
        /// <param name="entity">Сообщение, которое нужно обновить</param>
        /// <returns></returns>
        public async Task Update(MailMessage entity)
        {
            _db.MailMessages.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
