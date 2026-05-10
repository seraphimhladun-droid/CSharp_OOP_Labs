using System;
using System.Collections.Generic;

namespace CourseProject_SmartManager
{
    public class SmartProject
    {
        public string ProjectName { get; set; }

        public List<Task> ProjectTasks { get; private set; }
        public List<Document> ProjectDocuments { get; private set; }

        // Закритий (private) конструктор.
        private SmartProject()
        {
            ProjectTasks = new List<Task>();
            ProjectDocuments = new List<Document>();

            // Взаємозв'язок КОМПОЗИЦІЯ: Проєкт під час створення одразу створює собі базове завдання
            ProjectTasks.Add(new Task("Організаційна зустріч по проєкту", "Високий"));
            Console.WriteLine("[Private Конструктор SmartProject]: Виділено пам'ять для списків та створено перше системне завдання (Композиція).");
        }

        // Публічний конструктор, який звертається до закритого через : this()
        public SmartProject(string name) : this()
        {
            ProjectName = name;
            Console.WriteLine($"[Конструктор SmartProject]: Проєкт '{ProjectName}' успішно ініціалізовано.");
        }
    }
}