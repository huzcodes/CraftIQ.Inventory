using CraftIQ.Inventory.Core.Domains.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using CraftIQ.Inventory.Core.Contracts.Identity;

namespace CraftIQ.Inventory.Services.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _contextAccessor;

    public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
    {
        _userManager = userManager;
        _contextAccessor = contextAccessor;
    }

    public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

    public async Task<ApplicationUser> GetUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return new ApplicationUser
        {
            Email = user.Email,
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }

    public async Task<List<ApplicationUser>> GetUsers()
    {
        var user = await _userManager.GetUsersInRoleAsync("Employee");
        return user.Select(q => new ApplicationUser
        {
            Id = q.Id,
            Email = q.Email,
            FirstName = q.FirstName,
            LastName = q.LastName
        }).ToList();
    }


}
