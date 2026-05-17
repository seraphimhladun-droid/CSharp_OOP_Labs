using System;
using System.Collections.Generic;
using System.IO; // Підключаємо бібліотеку для роботи з файлами

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
            Console.WriteLine("Версія 5: Спадкування, інтерфейси та поліморфізм (Повна версія)");
            Console.WriteLine("=====================================\n");

            // --- БАЗОВА ІНІЦІАЛІЗАЦІЯ ---
            Manager mainManager = new Manager("Олександр Іваненко");
            SmartProject webProject = new SmartProject("Впровадження електронних черг");
            mainManager.AssignProject(webProject);

            Console.WriteLine("\n--- ВЕРСІЯ 5: ЗЧИТУВАННЯ ДАНИХ З ФАЙЛУ ---");

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

                        // Модифікація В5: Оскільки просто Task створити не можна, робимо зчитані завдання рутинними
                        RoutineTask loadedTask = new RoutineTask(taskTitle, taskPriority, "За запитом");
                        webProject.AddTask(loadedTask);
                    }
                }
            }
            else
            {
                // Якщо файл не знайдено 
                Console.WriteLine($"[Помилка]: Файл '{filePath}' не знайдено! Перевірте налаштування Properties.");
            }

            // --- ТЕСТУВАННЯ БІНАРНИХ ОПЕРАТОРІВ ТА ПОРІВНЯННЯ (ЗБЕРЕЖЕНО З ВЕРСІЇ 4) ---
            Console.WriteLine("\n--- ТЕСТУВАННЯ БІНАРНИХ ОПЕРАТОРІВ (+, -) ---");

            // Модифікація В5: Оголошуємо змінні як Task, але ініціалізуємо як UrgentTask та RoutineTask
            Task taskA = new UrgentTask("Написати код", "Високий", DateTime.Now.AddDays(5));
            Task taskB = new RoutineTask("Протестувати код", "Середній", "Щодня");

            // Твій оригінальний код тестування працює ідеально!
            taskA = taskA + 5; // Виділяємо 5 годин
            taskB = taskB + 2; // Виділяємо 2 години
            Console.WriteLine($"Завдання '{taskA.Title}' займе {taskA.EstimatedHours} годин.");
            Console.WriteLine($"Завдання '{taskB.Title}' займе {taskB.EstimatedHours} годин.");

            // --- ДОДАТКОВА ПЕРЕВІРКА (Множення, Ділення, Унарні +/-) ---
            Console.WriteLine("\n--- ТЕСТУВАННЯ ДОДАТКОВИХ ОПЕРАТОРІВ (*, /, унарний -) ---");
            taskA = taskA * 2; // Множення (збільшили час удвічі)
            Console.WriteLine($"Після множення (*2) завдання '{taskA.Title}' займе {taskA.EstimatedHours} годин.");

            taskA = taskA / 2; // Ділення (повернули як було)
            Console.WriteLine($"Після ділення (/2) час повернувся до {taskA.EstimatedHours} годин.");

            taskB = -taskB; // Унарний мінус (повне обнулення часу за нашою логікою)
            Console.WriteLine($"Після унарного мінуса (-taskB) час завдання '{taskB.Title}' дорівнює {taskB.EstimatedHours} годин.");


            Console.WriteLine("\n--- ТЕСТУВАННЯ ОПЕРАТОРІВ ПОРІВНЯННЯ (>, ==) ---");

            if (taskA > taskB)
            {
                Console.WriteLine($"Завдання '{taskA.Title}' займає БІЛЬШЕ часу, ніж '{taskB.Title}'. (Спрацював оператор >)");
            }

            // Перевіряємо рівність
            Task taskC = new UrgentTask("Написати код", "Високий", DateTime.Now.AddDays(5));
            if (taskA == taskC)
            {
                Console.WriteLine($"Завдання taskA та taskC ІДЕНТИЧНІ за назвою і пріоритетом. (Спрацював оператор ==)");
            }

            // Додаємо ці створені завдання до нашого списку в проєкті, щоб вони теж там були
            webProject.AddTask(taskA);
            webProject.AddTask(taskB);


            // =====================================================================
            // ДЕМОНСТРАЦІЯ СПЕЦИФІЧНИХ МЕТОДІВ ТА ПОЛІМОРФІЗМУ
            // =====================================================================
            Console.WriteLine("\n--- НОВИЙ БЛОК ВЕРСІЇ 5: СПЕЦИФІЧНІ МЕТОДИ (Product Owner) ---");

            // Викликаємо метод DaysLeft(). Оскільки taskA лежить у змінній типу Task, 
            // ми явно кажемо компілятору, що це насправді UrgentTask (робимо приведення типів)
            int daysLeft = ((UrgentTask)taskA).DaysLeft();
            Console.WriteLine($"[Специфічний метод]: До дедлайну завдання '{taskA.Title}' залишилось днів: {daysLeft}");


            Console.WriteLine("\n--- НОВИЙ БЛОК ВЕРСІЇ 5: ПОЛІМОРФІЗМ ТА ІНТЕРФЕЙС IPrintable ---");
            Console.WriteLine("Виводимо повний список усіх завдань проєкту через поліморфний метод PrintInfo():\n");

            foreach (Task t in webProject.ProjectTasks)
            {
                t.PrintInfo(); // Кожен об'єкт сам знає, як себе надрукувати!
            }


            // =========================================================
            // ФІНАЛЬНА ЗУПИНКА ПРОГРАМИ 
            // =========================================================
            Console.WriteLine("\n=====================================");
            Console.WriteLine("Фініш імітації");
            Console.ReadLine();
        }
    }
}