using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Enums;

namespace WebApi.Data.DataEntities
{
    /// <summary>
    /// Класс, описывающий сообщение
    /// </summary>
    public class MailMessage
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Заголовок сообщения
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Содержание сообщения
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Связка с логами
        /// </summary>
        public MailLog MailLog { get; set; }

        /// <summary>
        /// Привязка к таблице связей
        /// </summary>
        public List<MailRecipient> MailRecipients { get; set; } = new();
    }
}
