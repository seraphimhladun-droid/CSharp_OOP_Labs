using System;
using System.Collections.Generic;
using System.IO; // Підключаємо бібліотеку для роботи з файлами

namespace CourseProject_SmartManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Налаштування консолі для правильного відображення
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ОБОВ'ЯЗКОВО: Завантажуємо українську мову перед виводом будь-якого тексту!
            LocalizationManager.LoadLanguage("uk");

            // Виводимо шапку програми через наш менеджер
            Console.WriteLine(LocalizationManager.GetString("StudentInfo"));
            Console.WriteLine(LocalizationManager.GetString("LabHeader"));
            Console.WriteLine("=====================================\n");

            // --- БАЗОВА ІНІЦІАЛІЗАЦІЯ ---
            Manager mainManager = new Manager("Олександр Іваненко");
            SmartProject webProject = new SmartProject("Впровадження електронних черг");
            mainManager.AssignProject(webProject);

            // --- ЗЧИТУВАННЯ ДАНИХ З ФАЙЛУ ---
            string filePath = "tasks.txt.txt";

            if (File.Exists(filePath))
            {
                string[] fileLines = File.ReadAllLines(filePath);
                // Звертаємося до словника за текстом про знайдений файл
                Console.WriteLine($"{LocalizationManager.GetString("FileFound")} '{filePath}'. Зчитано рядків: {fileLines.Length}\n");

                foreach (string line in fileLines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        RoutineTask loadedTask = new RoutineTask(parts[0], parts[1], "За запитом");
                        webProject.AddTask(loadedTask);
                    }
                }
            }
            else
            {
                // Звертаємося до словника за помилкою
                Console.WriteLine(LocalizationManager.GetString("FileNotFound"));
            }

            // --- ТЕСТУВАННЯ БІНАРНИХ ОПЕРАТОРІВ ТА ПОРІВНЯННЯ ---
            Console.WriteLine($"\n{LocalizationManager.GetString("MathTestingHeader")}");

            Task taskA = new UrgentTask("Написати код", "Високий", DateTime.Now.AddDays(5));
            Task taskB = new RoutineTask("Протестувати код", "Середній", "Щодня");

            taskA = taskA + 5;
            taskB = taskB + 2;
            Console.WriteLine($"Завдання '{taskA.Title}': {taskA.EstimatedHours} год.");
            Console.WriteLine($"Завдання '{taskB.Title}': {taskB.EstimatedHours} год.");

            taskA = taskA * 2;
            taskB = -taskB;

            if (taskA > taskB)
            {
                Console.WriteLine($"Спрацював оператор > (taskA > taskB)");
            }

            webProject.AddTask(taskA);
            webProject.AddTask(taskB);

            // =====================================================================
            // ДЕМОНСТРАЦІЯ СПЕЦИФІЧНИХ МЕТОДІВ ТА ПОЛІМОРФІЗМУ
            // =====================================================================
            Console.WriteLine($"\n{LocalizationManager.GetString("PolymorphismHeader")}");

            // Викликаємо метод DaysLeft()
            int daysLeft = ((UrgentTask)taskA).DaysLeft();
            Console.WriteLine($"\n'{taskA.Title}' - {LocalizationManager.GetString("DaysLeftText")} {daysLeft}\n");

            // Поліморфний вивід через IPrintable
            foreach (Task t in webProject.ProjectTasks)
            {
                t.PrintInfo();
            }

            // =========================================================
            // ФІНАЛЬНА ЗУПИНКА ПРОГРАМИ 
            // =========================================================
            Console.WriteLine("\n=====================================");
            Console.WriteLine(LocalizationManager.GetString("MenuFinish"));
            Console.ReadLine();
        }
    }
}