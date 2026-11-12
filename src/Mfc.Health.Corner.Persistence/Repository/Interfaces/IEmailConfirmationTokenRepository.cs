using System;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Interfaces
{
    public interface IEmailConfirmationTokenRepository
    {
        Task<Guid> GenerateEmailConfirmationTokenAsync(string userId);

        Task<string> GetUserIdByTokenAsync(Guid? token);

        Task DeleteEmailConfirmationTokenAsync(Guid? token);
    }
}
