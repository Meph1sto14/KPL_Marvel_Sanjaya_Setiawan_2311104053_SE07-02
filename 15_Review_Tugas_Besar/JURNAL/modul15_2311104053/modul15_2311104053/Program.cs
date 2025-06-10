using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace modul15_2311104053
{
    class Program
    {
        private static readonly string UsersFilePath = "users.json";
        private static List<User> users = new List<User>();

        static void Main(string[] args)
        {
            Console.WriteLine("=== APLIKASI REGISTRASI & LOGIN SECURE ===");
            Console.WriteLine("Modul 15 - Secure Coding Practices");
            Console.WriteLine("NIM: 2311104053\n");

            // Load existing users dari file JSON
            LoadUsersFromFile();

            while (true)
            {
                ShowMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterUser();
                        break;
                    case "2":
                        LoginUser();
                        break;
                    case "3":
                        ShowAllUsers();
                        break;
                    case "4":
                        Console.WriteLine("Terima kasih! Aplikasi selesai.");
                        return;
                    default:
                        Console.WriteLine("Pilihan tidak valid! Silakan coba lagi.\n");
                        break;
                }
            }
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("=== MENU UTAMA ===");
            Console.WriteLine("1. Registrasi User");
            Console.WriteLine("2. Login User");
            Console.WriteLine("3. Lihat Semua User");
            Console.WriteLine("4. Keluar");
            Console.Write("Pilih menu (1-4): ");
        }

        static void RegisterUser()
        {
            Console.WriteLine("\n=== REGISTRASI USER ===");

            string username = "";
            string password = "";

            // Input dan validasi username
            while (true)
            {
                Console.Write("Masukkan Username (5-20 karakter, huruf dan angka saja): ");
                username = Console.ReadLine();

                // Input Validation - Handling data invalid
                if (!User.IsValidUsername(username))
                {
                    Console.WriteLine("ERROR: Username tidak valid!");
                    Console.WriteLine("- Harus 5-20 karakter");
                    Console.WriteLine("- Hanya boleh huruf alfabet ASCII dan angka");
                    Console.WriteLine("Silakan coba lagi.\n");
                    continue;
                }

                // Cek apakah username sudah ada
                if (users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("ERROR: Username sudah terdaftar! Silakan gunakan username lain.\n");
                    continue;
                }

                break;
            }

            // Input dan validasi password
            while (true)
            {
                Console.Write("Masukkan Password (8-30 karakter, harus ada huruf, angka, dan !@#$%^&*): ");
                password = ReadPassword();

                // Input Validation - Handling data invalid
                if (!User.IsValidPassword(password))
                {
                    Console.WriteLine("\nERROR: Password tidak valid!");
                    Console.WriteLine("- Minimal 8 karakter, maksimal 30 karakter");
                    Console.WriteLine("- Harus mengandung minimal 1 huruf");
                    Console.WriteLine("- Harus mengandung minimal 1 angka");
                    Console.WriteLine("- Harus mengandung minimal 1 karakter khusus (!@#$%^&*)");
                    Console.WriteLine("Silakan coba lagi.\n");
                    continue;
                }

                // Password Management - Password rules
                if (User.PasswordContainsUsername(password, username))
                {
                    Console.WriteLine("\nERROR: Password tidak boleh mengandung username!");
                    Console.WriteLine("Silakan coba lagi.\n");
                    continue;
                }

                break;
            }

            // Password Management - Password hashing
            string hashedPassword = HashPassword(password);

            // Simpan user baru
            User newUser = new User(username, hashedPassword);
            users.Add(newUser);

            // Simpan ke file JSON
            SaveUsersToFile();

            Console.WriteLine($"\nSUKSES: User '{username}' berhasil didaftarkan!\n");
        }

        static void LoginUser()
        {
            Console.WriteLine("\n=== LOGIN USER ===");

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = ReadPassword();

            // Cari user berdasarkan username
            User user = users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (user == null)
            {
                Console.WriteLine("\nERROR: Username tidak ditemukan!\n");
                return;
            }

            // Verifikasi password dengan hash
            string hashedInputPassword = HashPassword(password);
            if (user.PasswordHash != hashedInputPassword)
            {
                Console.WriteLine("\nERROR: Password salah!\n");
                return;
            }

            Console.WriteLine($"\nSUKSES: Login berhasil!");
            Console.WriteLine($"Selamat datang, {user.Username}!");

            // Menu setelah login berhasil
            ShowUserMenu(user.Username);
        }

        static void ShowAllUsers()
        {
            Console.WriteLine("\n=== DAFTAR SEMUA USER ===");

            if (users.Count == 0)
            {
                Console.WriteLine("Belum ada user yang terdaftar.\n");
                return;
            }

            Console.WriteLine($"Total user terdaftar: {users.Count}");
            Console.WriteLine("Username");
            Console.WriteLine("--------");

            foreach (var user in users.OrderBy(u => u.Username))
            {
                Console.WriteLine($"{user.Username}");
            }
            Console.WriteLine();
        }

        // Menu setelah user berhasil login
        static void ShowUserMenu(string username)
        {
            while (true)
            {
                Console.WriteLine($"\n=== MENU USER: {username} ===");
                Console.WriteLine("1. Cek Kode Buah");
                Console.WriteLine("2. Game Posisi Karakter");
                Console.WriteLine("3. Logout");
                Console.Write("Pilih menu (1-3): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        MenuKodeBuah();
                        break;
                    case "2":
                        MenuGamePosisiKarakter();
                        break;
                    case "3":
                        Console.WriteLine("Logout berhasil!\n");
                        return;
                    default:
                        Console.WriteLine("Pilihan tidak valid! Silakan coba lagi.\n");
                        break;
                }
            }
        }

        // Menu untuk fitur Kode Buah
        static void MenuKodeBuah()
        {
            Console.WriteLine("\n=== CEK KODE BUAH ===");
            Console.WriteLine("Daftar buah yang tersedia:");
            Console.WriteLine("Apel, Aprikot, Alpukat, Pisang, Paprika, Blackberry,");
            Console.WriteLine("Ceri, Kelapa, Jagung, Kurma, Durian, Anggur, Melon, Semangka");

            while (true)
            {
                Console.Write("\nMasukkan nama buah (atau 'exit' untuk kembali): ");
                string namaBuah = Console.ReadLine();

                if (namaBuah.ToLower() == "exit")
                    break;

                if (string.IsNullOrEmpty(namaBuah))
                {
                    Console.WriteLine("Nama buah tidak boleh kosong!");
                    continue;
                }

                string kode = KodeBuah.GetKodeBuah(namaBuah);
                Console.WriteLine($"Kode untuk '{namaBuah}': {kode}");
            }
        }

        // Menu untuk Game Posisi Karakter
        static void MenuGamePosisiKarakter()
        {
            Console.WriteLine("\n=== GAME POSISI KARAKTER ===");
            Console.WriteLine("NIM: 2311104053");

            PosisiKarakterGame game = new PosisiKarakterGame(2311104053);

            Console.WriteLine("Kontrol Game:");
            Console.WriteLine("S = Arah Bawah");
            Console.WriteLine("W = Arah Atas");
            Console.WriteLine("X = Terbang");
            Console.WriteLine("J = Turun/Landing");
            Console.WriteLine("'exit' = Keluar dari game");

            game.PrintState();

            while (true)
            {
                Console.Write("\nTekan tombol (S/W/X/J) atau 'exit' untuk keluar: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                if (string.IsNullOrEmpty(input) || input.Length != 1)
                {
                    Console.WriteLine("Input harus 1 karakter (S/W/X/J)!");
                    continue;
                }

                char tombol = char.ToUpper(input[0]);
                game.TekanTombol(tombol);
                game.PrintState();
            }
        }

        // Password Management - Password hashing dengan SHA256
        static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Tambahkan salt untuk keamanan ekstra
                string saltedPassword = password + "SecureSalt2024!";
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Utility untuk membaca password dengan hidden input
        static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);

            return password;
        }

        // Load users dari file JSON (manual parsing)
        static void LoadUsersFromFile()
        {
            try
            {
                if (File.Exists(UsersFilePath))
                {
                    string json = File.ReadAllText(UsersFilePath);
                    if (!string.IsNullOrEmpty(json))
                    {
                        users = ParseUsersFromJson(json);
                        Console.WriteLine($"Berhasil memuat {users.Count} user dari file.\n");
                    }
                }
                else
                {
                    Console.WriteLine("File users.json tidak ditemukan. Membuat file baru.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading users: {ex.Message}");
                users = new List<User>();
            }
        }

        // Simpan users ke file JSON (manual serialization)
        static void SaveUsersToFile()
        {
            try
            {
                string json = SerializeUsersToJson(users);
                File.WriteAllText(UsersFilePath, json);
                Console.WriteLine("Data user berhasil disimpan ke users.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving users: {ex.Message}");
            }
        }

        // Manual JSON parsing untuk User list
        static List<User> ParseUsersFromJson(string json)
        {
            List<User> userList = new List<User>();

            try
            {
                // Hapus whitespace dan bracket
                json = json.Trim().Trim('[', ']');

                if (string.IsNullOrEmpty(json))
                    return userList;

                // Split berdasarkan object separator
                string[] userObjects = json.Split(new string[] { "},{" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string userObj in userObjects)
                {
                    // Clean up object brackets
                    string cleanObj = userObj.Trim().Trim('{', '}');

                    string username = "";
                    string passwordHash = "";

                    // Parse properties
                    string[] properties = cleanObj.Split(',');
                    foreach (string prop in properties)
                    {
                        string[] keyValue = prop.Split(':');
                        if (keyValue.Length == 2)
                        {
                            string key = keyValue[0].Trim().Trim('"');
                            string value = keyValue[1].Trim().Trim('"');

                            if (key == "Username")
                                username = value;
                            else if (key == "PasswordHash")
                                passwordHash = value;
                        }
                    }

                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(passwordHash))
                    {
                        userList.Add(new User(username, passwordHash));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
            }

            return userList;
        }

        // Manual JSON serialization untuk User list
        static string SerializeUsersToJson(List<User> userList)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[");

            for (int i = 0; i < userList.Count; i++)
            {
                sb.AppendLine("  {");
                sb.AppendLine($"    \"Username\": \"{userList[i].Username}\",");
                sb.AppendLine($"    \"PasswordHash\": \"{userList[i].PasswordHash}\"");

                if (i < userList.Count - 1)
                    sb.AppendLine("  },");
                else
                    sb.AppendLine("  }");
            }

            sb.AppendLine("]");
            return sb.ToString();
        }
    }
}