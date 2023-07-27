using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using WebApi.Enums;

namespace WebApi.Data.DataEntities
{
    /// <summary>
    /// Класс, описывающий лог
    /// </summary>
    public class MailLog
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Статус отправки (OK или Failed)
        /// </summary>
        public StatusMessage Result { get; set; }

        /// <summary>
        /// Описание причины неудачной отправки
        /// </summary>
        [MaybeNull]
        public string FailedMessage { get; set; }

        /// <summary>
        /// Id отправленного сообщения
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// Привязка к сообщению
        /// </summary>
        [ForeignKey(nameof(MessageId))]
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public MailMessage MailMessage { get; set; }
    }
}
