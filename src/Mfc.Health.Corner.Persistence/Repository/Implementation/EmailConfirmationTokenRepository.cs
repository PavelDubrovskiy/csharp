using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Data;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Implementation
{
    public class EmailConfirmationTokenRepository : IEmailConfirmationTokenRepository
    {
        private readonly DbContext _context = null;

        public EmailConfirmationTokenRepository(IOptions<MongoDBConfig> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task DeleteEmailConfirmationTokenAsync(Guid? token)
        {
            var emailConfirmationToken = await _context.EmailConfirmationTokens.Find(x => x.Token == token).FirstOrDefaultAsync();

            await _context.EmailConfirmationTokens.DeleteOneAsync(x => x.UserId == emailConfirmationToken.UserId);
        }

        public async Task<Guid> GenerateEmailConfirmationTokenAsync(string userId)
        {
            var token = Guid.NewGuid();

            EmailConfirmationToken emailConfirmationToken = new EmailConfirmationToken() { UserId = userId, Token = token };

            await _context.EmailConfirmationTokens.InsertOneAsync(emailConfirmationToken);

            return token;
        }

        public async Task<string> GetUserIdByTokenAsync(Guid? token)
        {
            var confirmationToken = await _context.EmailConfirmationTokens.Find(x => x.Token == token).FirstOrDefaultAsync();

            return confirmationToken?.UserId;
        }
    }
}
