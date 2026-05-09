using System;
using System.Collections.Generic;

namespace CourseProject_SmartManager
{
    public class Manager
    {
        public string FullName;
        public string Department;

        // ЗВ'ЯЗОК: Агрегація. Менеджер керує кількома проєктами.
        public List<SmartProject> ManagedProjects = new List<SmartProject>();

        // Заглушка методу
        public void StartProject(SmartProject project) { }
    }
}