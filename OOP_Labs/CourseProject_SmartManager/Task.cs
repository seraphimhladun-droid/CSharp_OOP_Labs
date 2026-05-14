using System;

namespace CourseProject_SmartManager
{
    public class Task
    {
        private string _title;

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
        public bool IsCompleted { get; private set; } // Нова властивість для статусу

        static Task() { }

        public Task(string title, string priority)
        {
            Title = title;
            Priority = priority;
            IsCompleted = false; // За замовчуванням нове завдання не виконане
        }

        public Task(Task previousTask)
        {
            this.Title = previousTask.Title + " (Копія)";
            this.Priority = previousTask.Priority;
            this.IsCompleted = false;
        }

        // ================= ВЕРСІЯ 3 =================

        // Метод дії
        public void CompleteTask()
        {
            IsCompleted = true;
            Console.WriteLine($"[Завдання]: Роботу над '{Title}' завершено!");
        }

        // Предикатна функція
        public bool IsDone()
        {
            return IsCompleted;
        }
    }
}