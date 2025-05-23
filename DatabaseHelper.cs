using System;
using System.IO;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Windows;

namespace Technika
{
    public static class DatabaseHelper
    {
        private static string dbFile = "users.db";
        private static string connectionString = $"Data Source={dbFile};Version=3;";

        public static void InitializeDatabase()
        {
            try
            {
                // Если файла нет — создаём его
                if (!File.Exists(dbFile))
                {
                    SQLiteConnection.CreateFile(dbFile);
                }

                // Всегда открываем соединение и создаём таблицу, если её нет
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL
                );
            ";
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при инициализации базы данных: {ex.Message}");
            }
        }

        public static bool RegisterUser(string username, string password)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Проверяем, существует ли пользователь
                    var checkCommand = connection.CreateCommand();
                    checkCommand.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @username";
                    checkCommand.Parameters.AddWithValue("@username", username);
                    long count = (long)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        return false; // Пользователь уже существует
                    }

                    // Добавляем нового пользователя
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        INSERT INTO Users (Username, Password)
                        VALUES (@username, @password);";
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}");
                return false;
            }
        }

        public static bool CheckUser(string username, string password)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText =
                        "SELECT 1 FROM Users WHERE Username = @username AND Password = @password LIMIT 1;";
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read(); // true, если есть хотя бы одна строка
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке пользователя: {ex.Message}");
                return false;
            }
        }

        // Метод для проверки существования таблицы
        public static bool TableExists(string tableName)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name=@tableName;";
                    command.Parameters.AddWithValue("@tableName", tableName);
                    return command.ExecuteScalar() != null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке таблицы: {ex.Message}");
                return false;
            }
        }
    }
}