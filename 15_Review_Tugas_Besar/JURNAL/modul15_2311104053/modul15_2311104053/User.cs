using System;
using System.Linq;

namespace modul15_2311104053
{
    public class User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public User()
        {
        }

        public User(string username, string passwordHash)
        {
            Username = username;
            PasswordHash = passwordHash;
        }

        // Validasi username
        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;

            // Input Validation - Range dan Panjang data
            // Username harus 5-20 karakter, hanya huruf dan angka
            if (username.Length < 5 || username.Length > 20)
                return false;

            // Hanya boleh huruf alfabet ASCII dan angka
            foreach (char c in username)
            {
                if (!char.IsLetterOrDigit(c))
                    return false;
            }

            return true;
        }

        // Validasi password sesuai Password Rules
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            // Password Management - Password rules
            // Minimal 8 karakter, maksimal 30 karakter
            if (password.Length < 8 || password.Length > 30)
                return false;

            // Harus mengandung minimal 1 angka
            bool hasDigit = false;
            // Harus mengandung minimal 1 karakter unik
            bool hasSpecialChar = false;
            // Harus mengandung minimal 1 huruf
            bool hasLetter = false;

            string specialChars = "!@#$%^&*";

            foreach (char c in password)
            {
                if (char.IsDigit(c))
                    hasDigit = true;
                else if (char.IsLetter(c))
                    hasLetter = true;
                else if (specialChars.Contains(c))
                    hasSpecialChar = true;
            }

            return hasDigit && hasSpecialChar && hasLetter;
        }

        // Validasi password tidak mengandung username
        public static bool PasswordContainsUsername(string password, string username)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username))
                return false;

            return password.ToLower().Contains(username.ToLower());
        }
    }
}