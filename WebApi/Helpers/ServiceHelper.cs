using WebApi.Data.DataEntities;
using WebApi.Repositories.Implementations;
using WebApi.Repositories.Interfaces;
using WebApi.Services.Implementations;
using WebApi.Services.Interfaces;

namespace WebApi.Helpers
{
    /// <summary>
    /// Статический класс, содержащий вспомогательные функции
    /// </summary>
    public static class ServiceHelper
    {
        /// <summary>
        /// Регистрация репозиториев в DI-контейнере
        /// </summary>
        /// <param name="services"></param>
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<MailLog>, MailLogRepository>();
            services.AddScoped<IRepository<MailMessage>, MailMessageRepository>();
            services.AddScoped<IRepository<MailRecipient>, MailRecipientRepository>();
            services.AddScoped<IRepository<Recipient>, RecipientRepository>();
        }

        /// <summary>
        /// Регистрация сервисов в DI-контейнере
        /// </summary>
        /// <param name="services"></param>
        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
