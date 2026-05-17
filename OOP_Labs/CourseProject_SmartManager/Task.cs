using System;

namespace CourseProject_SmartManager
{
    public class Task
    {
        public string Title { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; set; } 

        public Task(string title, string priority)
        {
            Title = title;
            Priority = priority;
            IsCompleted = false; // При створенні завдання завжди НЕ виконане
        }

        public void CompleteTask()
        {
            IsCompleted = true;
        }

        public bool IsDone() // Предикатна функція
        {
            return IsCompleted;
        }

        //  Перевантаження унарних операторів =================

        // 1. Оператор ++ (Інкремент) Працює як "штамп ВИКОНАНО"
        public static Task operator ++(Task t)
        {
            t.IsCompleted = true;
            return t; // Повертаємо оновлену картку завдання
        }

        // 2. Оператор -- (Декремент) Працює як "штамп СКАСОВАНО/ВЕРНУТИ В РОБОТУ"
        public static Task operator --(Task t)
        {
            t.IsCompleted = false;
            return t;
        }

        // 3. Оператор ! (Логічне НІ) 
        // Якщо завдання виконане (true), поверне false. І навпаки.
        public static bool operator !(Task t)
        {
            return !t.IsCompleted;
        }

        public static bool operator true(Task t)
        {
            return t.IsCompleted == true;
        }

        public static bool operator false(Task t)
        {
            return t.IsCompleted == false;
        }
    }
}