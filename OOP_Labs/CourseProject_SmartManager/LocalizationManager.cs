using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json; // Вбудована бібліотека для роботи з JSON

namespace CourseProject_SmartManager
{
    public static class LocalizationManager
    {
        private static Dictionary<string, string> _translations = new Dictionary<string, string>();

        public static void LoadLanguage(string languageCode)
        {
            string filePath = $"{languageCode}.json";

            if (File.Exists(filePath))
            {
                // Зчитуємо весь текст з файлу
                string jsonString = File.ReadAllText(filePath);

                // Перетворюємо текст на словник
                _translations = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);
            }
            else
            {
                Console.WriteLine($"[Системна помилка]: Файл локалізації {filePath} не знайдено.");
            }
        }

        // Цей метод будемо викликати замість тексту
        public static string GetString(string key)
        {
            // Якщо ключ знайдено — повертаємо переклад
            if (_translations.ContainsKey(key))
            {
                return _translations[key];
            }

            // Якщо забули додати переклад — виведемо сам ключ, щоб побачити помилку
            return $"[{key}]";
        }
    }
}