using System;

namespace CourseProject_SmartManager
{
    public class Task
    {
        
        private string _title;

        //  Властивість читання та запису 
        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    _title = "Безіменне завдання";
                else
                    _title = value;
            }
        }

        public string Priority { get; set; }

        //  Статичний конструктор
        static Task()
        {
            Console.WriteLine(">>> [СТАТИЧНИЙ КОНСТРУКТОР]: Систему завдань Smart Manager ініціалізовано. <<<");
        }

        // Конструктор ініціалізації
        public Task(string title, string priority)
        {
            Title = title; // Викликається set-аксесор
            Priority = priority;
            Console.WriteLine($"[Конструктор Task]: Створено завдання '{Title}' (Пріоритет: {Priority}).");
        }

        // Конструктор копій
        public Task(Task previousTask)
        {
            this.Title = previousTask.Title + " (Копія)";
            this.Priority = previousTask.Priority;
            Console.WriteLine($"[Конструктор Task]: Створено КОПІЮ завдання '{this.Title}'.");
        }
    }
}
