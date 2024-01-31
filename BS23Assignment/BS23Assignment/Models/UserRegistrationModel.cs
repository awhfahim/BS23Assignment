using BS23Assignment.Data;
using BS23Assignment.DTOs;
using BS23Assignment.Services;
using Mapster;
using MapsterMapper;
using System.ComponentModel.DataAnnotations;

namespace BS23Assignment.Models
{
    public class UserRegistrationModel
    {
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName Must Be Unique"), Length(5, 12)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }

        private readonly AccountManagementService _accountManagementService;
        public UserRegistrationModel()
        {
            _accountManagementService = new AccountManagementService();
        }
        internal async Task OnPostAsync()
        {
            string passwordHash
              = BCrypt.Net.BCrypt.HashPassword(Password);
            Password = passwordHash;
            var dto = this.Adapt<UserRegistrationDto>();
            await _accountManagementService.RegisterUserAsync(dto);
        }
    }
}
