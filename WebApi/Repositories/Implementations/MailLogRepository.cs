using Microsoft.EntityFrameworkCore;
using WebApi.Data.DataContexts;
using WebApi.Data.DataEntities;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories.Implementations
{
    public class MailLogRepository : IRepository<MailLog>
    {
        private readonly ApplicationDbContext _db;

        public MailLogRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Добавление нового лога в БД
        /// </summary>
        /// <param name="entity">Лог, который нужно добавить</param>
        /// <returns></returns>
        public async Task Create(MailLog entity)
        {
            await _db.MailLogs.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление лога
        /// </summary>
        /// <param name="entity">Лог, который нужно удалить</param>
        /// <returns></returns>
        public async Task Delete(MailLog entity)
        {
            _db.MailLogs.Remove(entity);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Получение всех логов
        /// </summary>
        /// <returns></returns>
        public IQueryable<MailLog> GetAll()
        {
            return _db.MailLogs;
        }

        /// <summary>
        /// Обновление лога
        /// </summary>
        /// <param name="entity">Лог, который необходимо обновить</param>
        /// <returns></returns>
        public async Task Update(MailLog entity)
        {
            _db.MailLogs.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
