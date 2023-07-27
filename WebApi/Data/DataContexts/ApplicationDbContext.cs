using Microsoft.EntityFrameworkCore;
using WebApi.Data.DataEntities;

namespace WebApi.Data.DataContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Таблица логов
        /// </summary>
        public DbSet<MailLog> MailLogs { get; set; }

        /// <summary>
        /// Таблица сообщений
        /// </summary>
        public DbSet<MailMessage> MailMessages { get; set; }

        /// <summary>
        /// Таблица связей
        /// </summary>
        public DbSet<MailRecipient> MailRecipients { get; set; }

        /// <summary>
        /// Таблица получателей сообщений
        /// </summary>
        public DbSet<Recipient> Recipients { get; set; }
    }
}
