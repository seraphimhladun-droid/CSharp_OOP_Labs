using System;

namespace CourseProject_SmartManager
{
    public class Document
    {
        public string Name { get; set; }
        public string Status { get; private set; }

        public Document()
        {
            Name = "Новий документ";
            Status = "Чорнетка";
        }

        public Document(string name)
        {
            Name = name;
            Status = "Чорнетка";
        }

        public Document(string name, string status) : this(name)
        {
            Status = status;
        }

        // ================= ВЕРСІЯ 3 =================

        // Метод дії (змінює стан об'єкта)
        public void ApproveDocument()
        {
            Status = "Затверджено";
            Console.WriteLine($"[Документ]: '{Name}' успішно підписано та затверджено.");
        }

        // Предикатна функція (повертає true/false)
        public bool IsApproved()
        {
            return Status == "Затверджено";
        }
    }
}