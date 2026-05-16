using System;
using System.Collections.Generic;
using System.IO; //  Підключаємо бібліотеку для роботи з файлами

namespace CourseProject_SmartManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Налаштування консолі для правильного відображення української мови
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("ПІБ студента: Гладун Серафим Сергійович");
            Console.WriteLine("Курс: 1, Група: ІПЗ-12");
            Console.WriteLine("Варіант завдання: 25 (Smart Manager)");
            Console.WriteLine("Версія 4: Перевантаження операторів та робота з файлами");
            Console.WriteLine("=====================================\n");

            // --- БАЗОВА ІНІЦІАЛІЗАЦІЯ ---
            Manager mainManager = new Manager("Олександр Іваненко");
            SmartProject webProject = new SmartProject("Впровадження електронних черг");
            mainManager.AssignProject(webProject);

            Console.WriteLine("\n--- ВЕРСІЯ 4: ЗЧИТУВАННЯ ДАНИХ З ФАЙЛУ ---");

            // Вказуємо назву нашого файлу
            string filePath = "tasks.txt.txt";

            // Перевіряємо, чи існує файл у папці з програмою
            if (File.Exists(filePath))
            {
                // Зчитуємо всі рядки з файлу в масив
                string[] fileLines = File.ReadAllLines(filePath);
                Console.WriteLine($"[Файлова система]: Знайдено файл '{filePath}'. Зчитано рядків: {fileLines.Length}\n");

                // Проходимося циклом по кожному зчитаному рядку
                foreach (string line in fileLines)
                {
                    // Розбиваємо рядок на частини за символом '|'
                    string[] parts = line.Split('|');

                    // Перевіряємо, чи правильно розбився рядок (має бути 2 частини: Назва і Пріоритет)
                    if (parts.Length == 2)
                    {
                        string taskTitle = parts[0];
                        string taskPriority = parts[1];

                        // Створюємо нове завдання з цих даних і додаємо в проєкт
                        Task loadedTask = new Task(taskTitle, taskPriority);
                        webProject.AddTask(loadedTask);
                    }
                }
            }
            else
            {
                // Якщо файл не знайдено (наприклад, забули поставити Copy if newer)
                Console.WriteLine($"[Помилка]: Файл '{filePath}' не знайдено! Перевірте налаштування Properties.");
            }

            Console.WriteLine("\n=====================================");
            Console.WriteLine("Фініш імітації");
            Console.ReadLine();
        }
    }
}