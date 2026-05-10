using System;

namespace CourseProject_SmartManager
{
    public class Document
    {
        public string Name { get; set; }

        public string Status { get; private set; }

        //  Конструктор без параметрів
        public Document()
        {
            Name = "Новий документ";
            Status = "Чорнетка";
            Console.WriteLine($"[Конструктор Document]: Створено порожній документ '{Name}'.");
        }

        // Конструктор з параметрами
        public Document(string name)
        {
            Name = name;
            Status = "Чорнетка";
            Console.WriteLine($"[Конструктор Document]: Створено документ з назвою '{Name}'.");
        }

        //  Конструктор, що викликає інші конструктори 
        public Document(string name, string status) : this(name)
        {
            Status = status; // Перезаписуємо статус після того, як відпрацював попередній конструктор
            Console.WriteLine($"[Конструктор Document]: Статус документа '{Name}' змінено на '{Status}'.");
        }
    }
}
