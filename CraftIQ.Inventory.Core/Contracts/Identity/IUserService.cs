using CraftIQ.Inventory.Core.Domains.Identity;

namespace CraftIQ.Inventory.Core.Contracts.Identity;

public interface IUserService
{
    Task<List<ApplicationUser>> GetUsers();
    Task<ApplicationUser> GetUser(string userId);
    public string UserId { get; }
}

