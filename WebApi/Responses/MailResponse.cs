using WebApi.Data.DataEntities;
using WebApi.Enums;

namespace WebApi.Responses
{
    /// <summary>
    /// Сущность, представляющая ответ на Get запрос
    /// </summary>
    public class MailResponse
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Время отправки
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Статус отправки
        /// </summary>
        public StatusMessage Result { get; set; }

        /// <summary>
        /// Сообщение ошибки
        /// </summary>
        public string? FailedMessage { get; set; }

        /// <summary>
        /// Электронные Получатели
        /// </summary>
        public string[] Recipients { get; set; }
    }
}
