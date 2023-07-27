using Microsoft.EntityFrameworkCore;
using WebApi.Data.DataContexts;
using WebApi.Data.DataEntities;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories.Implementations
{
    public class MailRecipientRepository : IRepository<MailRecipient>
    {
        private readonly ApplicationDbContext _db;

        public MailRecipientRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Создание элемента таблицы связей
        /// </summary>
        /// <param name="entity">Новый элемент в таблице связи</param>
        /// <returns></returns>
        public async Task Create(MailRecipient entity)
        {
            await _db.MailRecipients.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление элемента таблицы связей
        /// </summary>
        /// <param name="entity">Элемент, который нужно удалить</param>
        /// <returns></returns>
        public async Task Delete(MailRecipient entity)
        {
            _db.MailRecipients.Remove(entity);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Получение всех элементов таблицы связей
        /// </summary>
        /// <returns></returns>
        public IQueryable<MailRecipient> GetAll()
        {
            return _db.MailRecipients;
        }

        /// <summary>
        /// Обновление элемента таблицы связей
        /// </summary>
        /// <param name="entity">Элемент, который необходимо обновить</param>
        /// <returns></returns>
        public async Task Update(MailRecipient entity)
        {
            _db.MailRecipients.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
