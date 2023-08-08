using Kanini_Tourism_API.Models;
using Kanini_Tourism_API.Models.DTO;
using Kanini_Tourism_API.Repository.Interfaces;
using Kanini_Tourism_API.Repository.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static Kanini_Tourism_API.Models.User;

namespace Kanini_Tourism_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userRepository;
        private readonly string _jwtSecret = "JVr87UcOj69Kqw5R2Nmf4FWs03HdxSjhuyg57UVHnsdufhiw9687Hh";

        public UserController(IUser userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(User user)
        {
            if (_userRepository == null)
            {
                return Problem("User repository is null.");
            }

            // Encrypt the password before storing it
            user.Password = Encrypt(user.Password);

            var createdUser = await _userRepository.AddUser(user);

            // Generate JWT token with user details
            var token = GenerateJwtToken(createdUser);

            // Return the token as part of the response
            return Ok(token);
        }


        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] User loginModel)
        {
            if (_userRepository == null)
            {
                return Problem("User repository is null.");
            }
            // Find the user by their email
            var existingUser = await _userRepository.GetUserByEmail(loginModel.EmailId);


            if (existingUser == null)
            {
                return Unauthorized("Invalid credential");
            }


            // Decrypt the stored password and compare it with the provided password
            var decryptedPassword = Decrypt(existingUser.Password);
            if (loginModel.Password != decryptedPassword)
            {
                return Unauthorized("Invalid credentials");
            }

            if(existingUser.UserStatus != 0)
            {
                return Ok("your not a exisiting user");
            }
            // Passwords match, generate JWT token with user details
            var Token = GenerateJwtToken(existingUser);
           
            // Return the token as part of the response
            return Ok(Token);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userRepository.GetUserById(id);

                if (user == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching the user: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            try
            {
                var existingUser = await _userRepository.GetUserById(id);

                if (existingUser == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                // Update the user data
                //existingUser.Username = updatedUser.Username;
                //existingUser.EmailId = updatedUser.EmailId;
                //existingUser.UserRole = updatedUser.UserRole;
                existingUser.UserStatus = updatedUser.UserStatus;
                // You can update other properties as needed

               

                // Call the UpdateUser method from the UserService to persist the changes
                await _userRepository.UpdateUser(id, existingUser);

                return Ok(existingUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the user: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var existingUser = await _userRepository.GetUserById(id);

                if (existingUser == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                await _userRepository.DeleteUser(id); // Add this method in your IUser service

                return Ok(existingUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the user: {ex.Message}");
            }
        }
        /* [HttpPut("Status/{id}")]
         public async Task<IActionResult> UpdateUserstatus (int id, UserStatusDTO updatedUser)
         {
             try
             {
                 var existingUser = await _userRepository.GetUserById(id);

                 if (existingUser == null)
                 {
                     return NotFound($"User with ID {id} not found.");
                 }

                 // Update the user data

                 // You can update other properties as needed



                 // Call the UpdateUser method from the UserService to persist the changes
                 await _userRepository.UpdateUserstatus(id, updatedUser);

                 return Ok(existingUser);
             }
             catch (Exception ex)
             {
                 return StatusCode(500, $"An error occurred while updating the user: {ex.Message}");
             }
         }*/


        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Surname, user.Username),
                new Claim(ClaimTypes.Role, user.UserRole.ToString() ),
                new Claim(ClaimTypes.Email, user.EmailId),
             }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string Encrypt(string password)
        {
            // Example key and IV generation using hashing
            string passphrase = "your-passphrase";

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(passphrase));
                byte[] iv = sha256.ComputeHash(Encoding.UTF8.GetBytes(passphrase)).Take(16).ToArray();

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter writer = new StreamWriter(cryptoStream))
                            {
                                writer.Write(password);
                            }
                        }

                        byte[] encryptedData = memoryStream.ToArray();
                        return Convert.ToBase64String(encryptedData);
                    }
                }
            }
        }
        private string Decrypt(string encryptedPassword)
        {
            // Example key and IV generation using hashing
            string passphrase = "your-passphrase";

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(passphrase));
                byte[] iv = sha256.ComputeHash(Encoding.UTF8.GetBytes(passphrase)).Take(16).ToArray();

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    byte[] encryptedData = Convert.FromBase64String(encryptedPassword);

                    using (MemoryStream memoryStream = new MemoryStream(encryptedData))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader reader = new StreamReader(cryptoStream))
                            {
                                return reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
    }
}
