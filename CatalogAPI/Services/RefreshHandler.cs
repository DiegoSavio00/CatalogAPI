using CatalogAPI.Context;
using CatalogAPI.Domain.Entities;
using CatalogAPI.Services.InterfaceService;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace CatalogAPI.Services
{
    public class RefreshHandler : IRefreshHandler
    {
        private readonly AppDbContext _context;

        public RefreshHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateToken(string username)
        {
            var randon = new byte[32];
            using (var randonNumberGenerator = RandomNumberGenerator.Create())
            {
                randonNumberGenerator.GetBytes(randon);
                var refreshToken = Convert.ToBase64String(randon);
                var existsToken = _context.RefreshTokens.FirstOrDefaultAsync(item => item.Userid == username).Result;
                if (existsToken != null)
                {
                    existsToken.Refreshtoken = refreshToken;
                }
                else
                {
                    await _context.RefreshTokens.AddAsync(new RefreshToken
                    {
                        Userid = username,
                        Tokenid = new Random().Next().ToString(),
                        Refreshtoken = refreshToken
                    });
                }
                await _context.SaveChangesAsync();
                return refreshToken;
            }
        }
    }
}
