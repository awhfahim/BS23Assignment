using Azure.Core;
using BS23Assignment.Data;
using BS23Assignment.DTOs;

namespace BS23Assignment.Services
{
    public class AccountManagementService
    {
        private ApplicationDbContext _context;
        public AccountManagementService() 
        {
            _context = new ApplicationDbContext();
        }
        public async Task RegisterUserAsync(UserRegistrationDto dto)
        {
            if(dto is not null)
            {
                await _context.Register.AddAsync(dto);
                await _context.SaveChangesAsync();
            }
        }

        internal async Task<bool> isLoggedInAsync(string username, string password)
        {
            var res = _context.Register.Where(x => x.UserName == username).Select(x => new { x.UserName, x.Password }).First();

            if(BCrypt.Net.BCrypt.Verify(password, res.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
