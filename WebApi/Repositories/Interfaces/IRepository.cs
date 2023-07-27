namespace WebApi.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Добавление сущности
        /// </summary>
        /// <param name="entity">Сущность, которую нужно добавить</param>
        /// <returns></returns>
        Task Create(T entity);

        /// <summary>
        /// Получение всех сущностей
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Удаление сущности
        /// </summary>
        /// <param name="entity">Сущность, которую нужно удалить</param>
        /// <returns></returns>
        Task Delete(T entity);

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="entity">Сущность, которую нужно обновить</param>
        /// <returns></returns>
        Task Update(T entity);
    }
}
