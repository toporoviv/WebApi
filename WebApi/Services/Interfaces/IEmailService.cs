using WebApi.Requests;

namespace WebApi.Services.Interfaces
{
    /// <summary>
    /// Сервис для отправки сообщений на почту
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Отправка сообщений на почту
        /// </summary>
        /// <param name="request">Сущность, содержащая заголовок, сообщение и получателей</param>
        /// <returns></returns>
        Task SendMessage(MailRequest request);
    }
}
