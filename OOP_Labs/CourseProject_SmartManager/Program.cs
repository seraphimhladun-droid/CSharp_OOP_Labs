using System;

namespace CourseProject_SmartManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("ПІБ студента: Гладун Серафим Сергійович");
            Console.WriteLine("Курс: 1, Група: ІПЗ-12");
            Console.WriteLine("Варіант завдання: 25 (Smart Manager)");
            Console.WriteLine("Версія 3: Робота методів та предикатні функції");
            Console.WriteLine("=====================================\n");

            // --- БАЗОВА ІНІЦІАЛІЗАЦІЯ ---
            Manager mainManager = new Manager("Олександр Іваненко");
            SmartProject webProject = new SmartProject("Впровадження електронних черг");
            mainManager.AssignProject(webProject);

            Console.WriteLine("\n--- ВЕРСІЯ 3: СЦЕНАРІЙ РОБОТИ ---");

            // 1. Створюємо елементи
            Task frontendTask = new Task("Зробити дизайн сайту", "Високий");
            Task backendTask = new Task("Написати API", "Критичний");
            Document tzDoc = new Document("Технічне завдання");

            // 2. Додаємо їх у проєкт
            webProject.AddTask(frontendTask);
            webProject.AddTask(backendTask);
            webProject.AddDocument(tzDoc);

            // 3. Використовуємо предикат для перевірки стану
            Console.WriteLine($"\n[Система]: Перевірка готовності проєкту...");
            Console.WriteLine($"Чи готовий проєкт до здачі? -> {webProject.IsReadyForRelease()}");

            // 4. Виконуємо роботу (викликаємо методи)
            Console.WriteLine("\n[Система]: Менеджер починає виконувати задачі...");
            frontendTask.CompleteTask();
            backendTask.CompleteTask();
            tzDoc.ApproveDocument();

            // 5. Знову перевіряємо предикат
            Console.WriteLine($"\n[Система]: Фінальна перевірка готовності...");
            Console.WriteLine($"Чи готовий проєкт до здачі? -> {webProject.IsReadyForRelease()}");
            if (webProject.IsReadyForRelease())
            {
                Console.WriteLine("Ура! Проєкт успішно завершено.");
            }

            // 6. Демонстрація методу і предиката Менеджера
            mainManager.PrintDashboard();

            Console.WriteLine("\n=====================================");
            Console.WriteLine("Фініш імітації");
            Console.ReadLine();
        }
    }
}