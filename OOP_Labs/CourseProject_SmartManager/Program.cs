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
            Console.WriteLine("Версія 2: Конструктори та аксесори класів");
            Console.WriteLine("=====================================\n");

            Console.WriteLine("--- ПРОТОКОЛ РОБОТИ КОНСТРУКТОРІВ ТА ЗВ'ЯЗКІВ ---\n");

            // 1. Створюємо менеджера 
            Manager mainManager = new Manager("Олександр Іваненко");

            // 2. Демонстрація статичного конструктора та ініціалізації Task
            Task task1 = new Task("Налаштувати сервери", "Високий");

            // 3. Демонстрація КОНСТРУКТОРА КОПІЙ
            Task task2_duplicate = new Task(task1);

            // 4. Створюємо проєкт (тут спрацює private конструктор + композиція)
            Console.WriteLine();
            SmartProject webProject = new SmartProject("Впровадження електронних черг");

            // 5. АГРЕГАЦІЯ: Передаємо проєкт менеджеру
            mainManager.AssignProject(webProject);

            // 6. Демонстрація конструкторів Document
            Console.WriteLine();
            Document doc1 = new Document(); // без параметрів
            Document doc2 = new Document("Договір NDA", "Затверджено"); // :this(name)

            // 7. Перевірка властивостей (аксесорів)
            Console.WriteLine("\n--- ПЕРЕВІРКА ВЛАСТИВОСТЕЙ (АКСЕСОРІВ) ---");
            Task badTask = new Task("", "Низький"); // Передаємо порожній рядок
            Console.WriteLine($"Спроба створити завдання без назви. Результат роботи set-аксесора: '{badTask.Title}'");

            Console.WriteLine("\n=====================================");
            Console.WriteLine("Фініш імітації");
            Console.ReadLine();
        }
    }
}