using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace my_pizza.Infrastructure.Services
{
    public class EmailService : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}