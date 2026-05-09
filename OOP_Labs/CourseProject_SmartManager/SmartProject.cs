using System;
using System.Collections.Generic; // Потрібно для роботи зі списками

namespace CourseProject_SmartManager
{
    public class SmartProject
    {
        public string ProjectName;
        public string ClientName;

        // ЗВ'ЯЗОК: Агрегація/Композиція. 
        // Проєкт містить у собі списки завдань та документів.
        public List<Task> ProjectTasks = new List<Task>();
        public List<Document> ProjectDocuments = new List<Document>();

        // Заглушки методів
        public void AddTask(Task newTask) { }
        public void AddDocument(Document newDoc) { }
    }
}