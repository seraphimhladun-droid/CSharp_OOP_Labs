using System;
using System.IO;

namespace CourseProject_SmartManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("ПІБ студента:Гладун Серафим Сергійович");
            Console.WriteLine("Курс: 1, Група:ІПЗ-12");
            Console.WriteLine("Варіант завдання: 25 (Smart Manager)");
            Console.WriteLine("Версія 1");
            Console.WriteLine("Старт імітації");
            Console.WriteLine("=====================================\n");

            // 2. Створення об'єктів (перевірка, що класи працюють)
            Manager mainManager = new Manager();
            mainManager.FullName = "Олександр Іваненко";
            mainManager.Department = "IT Відділ";

            SmartProject newProject = new SmartProject();
            newProject.ProjectName = "Впровадження електронних черг";

            Task task1 = new Task();
            task1.Title = "Написати ТЗ для серверної частини";

            Document doc1 = new Document();
            doc1.Name = "Договір з підрядником";

            // 3. Імітація роботи
            Console.WriteLine($"[Система]: Створено менеджера - {mainManager.FullName}");
            Console.WriteLine($"[Система]: Створено новий проєкт - '{newProject.ProjectName}'");
            Console.WriteLine($"[Система]: Додано завдання '{task1.Title}'");
            Console.WriteLine($"[Система]: Завантажено документ '{doc1.Name}'");

            // Фініш
            Console.WriteLine("\n=====================================");
            Console.WriteLine("Фініш імітації");

            Console.ReadLine(); // Щоб консоль не закривалась
        }
    }
}