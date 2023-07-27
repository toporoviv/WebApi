namespace WebApi.Requests
{
    /// <summary>
    /// Сущность, представляющая Post запрос
    /// </summary>
    public class MailRequest
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
        /// Получатели
        /// </summary>
        public string[] Recipients { get; set; }
    }
}
