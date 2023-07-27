using Microsoft.AspNetCore.Mvc;
using WebApi.Requests;
using WebApi.Responses;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/mails")]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;
        private readonly IEmailService _emailService;

        public MailController(IMailService mailService, IEmailService emailService)
        {
            _mailService = mailService;
            _emailService = emailService;
        }

        /// <summary>
        /// ��������� Get �������
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MailResponse[]> Get()
        {
            return await _mailService.GetMailInformation();
        }

        /// <summary>
        /// ��������� Post �������
        /// </summary>
        /// <param name="request">��������, ���������� ���������, ��������� � �����������</param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(MailRequest request)
        {
            await _emailService.SendMessage(request);
        }
    }
}