
using BS23Assignment.Services;

namespace BS23Assignment.Models
{
    public class UserLoginModel
    {
        private readonly AccountManagementService _accountManagementService;
        public required string Username { get; set; }
        public required string Password { get; set; }
        public UserLoginModel()
        {
            _accountManagementService = new AccountManagementService();
        }
        internal async Task<bool> LoginAsync()
        {
            return await _accountManagementService.isLoggedInAsync(Username, Password);
        }
    }
}
