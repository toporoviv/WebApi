using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.DataEntities
{
    /// <summary>
    /// Получатель сообщений
    /// </summary>
    public class Recipient
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Email адрес получателя
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Привязка к таблице связей
        /// </summary>
        public List<MailRecipient> MailRecipients { get; set; } = new();
    }
}
