using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TaskPlanner.Models;

namespace TaskPlanner.Services
{
    public class AuthService
    {
        private List<User> _users = new List<User>();
        private int _nextUserId = 1;

        public AuthResponse MakeAuthRequest(string username, string password, bool isLogin)
        {
            if (isLogin)
            {
                return Login(username, password);
            }
            else
            {
                return Register(username, "user@email.com", password);
            }
        }

        private AuthResponse Register(string username, string email, string password)
        {
            if (_users.Any(u => u.Username == username))
            {
                return new AuthResponse { Success = false, Message = "Пользователь уже существует" };
            }

            var user = new User
            {
                Id = _nextUserId++,
                Username = username,
                Email = email,
                PasswordHash = HashPassword(password),
                CreatedAt = DateTime.Now
            };

            _users.Add(user);

            // ВРЕМЕННО: упрощенная логика без токенов
            return new AuthResponse
            {
                Success = true,
                Message = "Регистрация успешна",
                Token = "valid_token", // Простой токен
                User = user
            };
        }

        private AuthResponse Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            if (user == null || user.PasswordHash != HashPassword(password))
            {
                return new AuthResponse { Success = false, Message = "Неверные данные" };
            }

            return new AuthResponse
            {
                Success = true,
                Message = "Вход выполнен",
                Token = "valid_token", // Простой токен
                User = user
            };
        }

        // ВРЕМЕННО: всегда возвращаем true
        public bool ValidateToken(string token)
        {
            return token == "valid_token"; // Простая проверка
        }

        public User GetUserFromToken(string token)
        {
            // Для тестирования возвращаем первого пользователя
            return _users.FirstOrDefault();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public List<User> GetUsers()
        {
            return _users.ToList();
        }
    }
}