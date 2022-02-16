using System.Threading.Tasks;

namespace Furever.EmailService
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
        Task SendMessageAsync(EmailDto emailDto);
    }
}
