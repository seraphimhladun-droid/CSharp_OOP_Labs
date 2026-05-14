using System;
using System.Collections.Generic;
using System.Linq; // Потрібно для зручної роботи зі списками

namespace CourseProject_SmartManager
{
    public class SmartProject
    {
        public string ProjectName { get; set; }

        public List<Task> ProjectTasks { get; private set; }
        public List<Document> ProjectDocuments { get; private set; }

        private SmartProject()
        {
            ProjectTasks = new List<Task>();
            ProjectDocuments = new List<Document>();
        }

        public SmartProject(string name) : this()
        {
            ProjectName = name;
        }

        // ================= ВЕРСІЯ 3 =================

        // Методи додавання (заповнення контейнерів)
        public void AddTask(Task newTask)
        {
            ProjectTasks.Add(newTask);
            Console.WriteLine($"[Проєкт '{ProjectName}']: Додано нове завдання '{newTask.Title}'.");
        }

        public void AddDocument(Document newDoc)
        {
            ProjectDocuments.Add(newDoc);
            Console.WriteLine($"[Проєкт '{ProjectName}']: Прикріплено документ '{newDoc.Name}'.");
        }

        // Предикатна функція: перевіряє, чи можна здавати проєкт
        public bool IsReadyForRelease()
        {
            // Перевіряємо, чи є хоча б одне невиконане завдання
            bool hasUnfinishedTasks = ProjectTasks.Any(t => !t.IsDone());

            // Перевіряємо, чи є хоча б один незатверджений документ
            bool hasUnapprovedDocs = ProjectDocuments.Any(d => !d.IsApproved());

            // Проєкт готовий (true), якщо немає невиконаних завдань і немає незатверджених документів
            return !hasUnfinishedTasks && !hasUnapprovedDocs;
        }
    }
}