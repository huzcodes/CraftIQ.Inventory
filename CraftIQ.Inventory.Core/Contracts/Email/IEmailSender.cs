using CraftIQ.Inventory.Core.Domains.Email;

namespace CraftIQ.Inventory.Core.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage email);
}

