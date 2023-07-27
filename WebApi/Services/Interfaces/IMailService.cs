using WebApi.Responses;

namespace WebApi.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с сообщениями
    /// </summary>
    public interface IMailService
    {
        /// <summary>
        /// Получение информации для Get запроса
        /// </summary>
        /// <returns></returns>
        public Task<MailResponse[]> GetMailInformation();
    }
}
