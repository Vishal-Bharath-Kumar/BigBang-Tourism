using Kanini_Tourism_API.Models;
using Kanini_Tourism_API.Models.Data;
using Kanini_Tourism_API.Models.DTO;
using Kanini_Tourism_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using static Kanini_Tourism_API.Models.User;

namespace Kanini_Tourism_API.Repository.Services
{
    public class UserService:IUser
    {

            private readonly AppDbContext _context;

            public UserService(AppDbContext context)
            {
                _context = context;
            }

            public async Task<User> AddUser(User user)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return user;
            }

            public async Task<IEnumerable<User>> GetAllUsers()
            {
            var users = await _context.Users.ToListAsync();
                return users;
            }
        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User> GetUserByEmail(string email)
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.EmailId == email);
            }

        public async Task<User> UpdateUser(int userId, User updatedUser)
        {
            var existingUser = await _context.Users.FindAsync(userId);

            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }

            // Update the properties of the existing user with the new data
            existingUser.Username = updatedUser.Username;
            existingUser.EmailId = updatedUser.EmailId;
            existingUser.UserRole = updatedUser.UserRole;
            existingUser.UserStatus = updatedUser.UserStatus;
            // You can update other properties as needed

            // If the password is provided in the updatedUser, encrypt it and store it
            if (!string.IsNullOrEmpty(updatedUser.Password))
            {
                existingUser.Password = Encrypt(updatedUser.Password);
            }

            // Save the changes to the database
            await _context.SaveChangesAsync();

            return existingUser;
        }

        public async Task DeleteUser(int id)
        {
            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser != null)
            {
                _context.Users.Remove(existingUser);
                await _context.SaveChangesAsync();
            }
        }

        /*    public async Task<UserStatusDTO> UpdateUserstatus(int userId, UserStatusDTO updatedUser)
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);

                if (existingUser == null)
                {
                    throw new KeyNotFoundException($"User with ID {userId} not found.");
                }
                existingUser.UserStatus = (Status)updatedUser.UserStatus;


                await _context.SaveChangesAsync();

                return updatedUser;
            }*/
        private string Encrypt(string password)
            {
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
