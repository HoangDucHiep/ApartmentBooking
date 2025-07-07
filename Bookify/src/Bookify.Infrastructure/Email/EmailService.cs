using Bookify.Application.Abstractions.Email;

namespace Bookify.Infrastructure.Email;

public sealed class EmailService : IEmailService
{
    public Task SendAsync(Domain.Users.Email recipient, string subject, string body)
    {
        return Task.CompletedTask; // Placeholder for actual email sending logic 
    }
}