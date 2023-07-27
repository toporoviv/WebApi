using Microsoft.EntityFrameworkCore;
using WebApi.Data.DataContexts;
using WebApi.Data.DataEntities;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories.Implementations
{
    public class RecipientRepository : IRepository<Recipient>
    {
        private readonly ApplicationDbContext _db;

        public RecipientRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Добавление получателя в БД
        /// </summary>
        /// <param name="entity">Получатель сообщений</param>
        /// <returns></returns>
        public async Task Create(Recipient entity)
        {
            await _db.Recipients.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление получателя
        /// </summary>
        /// <param name="entity">Получатель, которого необходимо удалить</param>
        /// <returns></returns>
        public async Task Delete(Recipient entity)
        {
            _db.Recipients.Remove(entity);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Получение всех получателей
        /// </summary>
        /// <returns></returns>
        public IQueryable<Recipient> GetAll()
        {
            return _db.Recipients;
        }

        /// <summary>
        /// Обновление получателя
        /// </summary>
        /// <param name="entity">Получатель, которого необходимо обновить</param>
        /// <returns></returns>
        public async Task Update(Recipient entity)
        {
            _db.Recipients.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
