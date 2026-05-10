using System;
using System.Collections.Generic;

namespace CourseProject_SmartManager
{
    public class Manager
    {
        public string FullName { get; set; }
        public List<SmartProject> ManagedProjects { get; private set; }

        public Manager(string fullName)
        {
            FullName = fullName;
            ManagedProjects = new List<SmartProject>();
            Console.WriteLine($"[Конструктор Manager]: Прийнято на роботу менеджера: {FullName}.");
        }

        // Взаємозв'язок АГРЕГАЦІЯ: Менеджер отримує готовий проєкт ззовні
        public void AssignProject(SmartProject existingProject)
        {
            ManagedProjects.Add(existingProject);
            Console.WriteLine($"[Агрегація]: Менеджеру {FullName} доручено керувати проєктом '{existingProject.ProjectName}'.");
        }
    }
}