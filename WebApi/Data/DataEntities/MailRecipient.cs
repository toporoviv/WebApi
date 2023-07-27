using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.DataEntities
{
    /// <summary>
    /// Класс, описывающий строку в таблице связей
    /// </summary>
    public class MailRecipient
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Id сообщения
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// Привязка к сообщению
        /// </summary>
        [ForeignKey(nameof(MessageId))]
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public MailMessage MailMessage { get; set; }

        /// <summary>
        /// Id получателя
        /// </summary>
        public int RecipientId { get; set; }

        /// <summary>
        /// Получатель
        /// </summary>
        [ForeignKey(nameof(RecipientId))]
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public Recipient Recipient { get; set; } = new();
    }
}
