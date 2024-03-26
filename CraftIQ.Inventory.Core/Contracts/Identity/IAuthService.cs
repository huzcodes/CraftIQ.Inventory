using CraftIQ.Inventory.Core.Domains.Identity;

namespace CraftIQ.Inventory.Core.Contracts.Identity; 

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);

}

