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
        }

        public void AssignProject(SmartProject existingProject)
        {
            ManagedProjects.Add(existingProject);
        }

        // ================= ВЕРСІЯ 3 =================

        // Предикатна функція: перевіряє навантаження на менеджера
        public bool IsOverloaded()
        {
            // Якщо у менеджера більше 3 проєктів, він перевантажений
            return ManagedProjects.Count > 3;
        }

        // Метод звітності
        public void PrintDashboard()
        {
            Console.WriteLine($"\n--- ДАШБОРД МЕНЕДЖЕРА: {FullName} ---");
            Console.WriteLine($"Кількість активних проєктів: {ManagedProjects.Count}");
            Console.WriteLine($"Стан перевантаження: {(IsOverloaded() ? "ТАК (Потрібен асистент)" : "НІ (Робота в нормі)")}");
        }
    }
}