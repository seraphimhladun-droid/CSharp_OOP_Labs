using System;

namespace CourseProject_SmartManager
{
    public interface IPrintable
    {
        void PrintInfo(); // Контракт: будь-який клас, що підпишеться на нас, зобов'язаний мати цей метод
    }
    public interface ICompletable
    {
        void CompleteTask();
        bool IsDone();
    }
    public class Task : IPrintable, ICompletable
    {
        public string Title { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; set; }
        public int EstimatedHours { get; set; } = 0; // Час на виконання (в годинах)

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
        public void PrintInfo()
        {
            // Використовуємо тернарний оператор , щоб красиво показати статус
            string status = IsCompleted ? "[Виконано]" : "[В процесі]";
            Console.WriteLine($"{status} Завдання: '{Title}' | Пріоритет: {Priority} | Годин: {EstimatedHours}");
        }

        // ================= Перевантаження унарних операторів =================

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

        // 4. Унарні плюс (+) та мінус (-) [Додано за вимогами]
        public static Task operator +(Task t)
        {
            // Унарний плюс зазвичай нічого не змінює, просто повертає об'єкт
            return t;
        }

        public static Task operator -(Task t)
        {
            // Нехай унарний мінус "обнуляє" час виконання завдання
            t.EstimatedHours = 0;
            return t;
        }


        // ================= ВЕРСІЯ 4: Бінарні оператори та Порівняння =================

        // 1. Бінарні оператори (+, -, *, /)
        // Дозволяють додавати або віднімати години роботи для завдання
        public static Task operator +(Task t, int hours)
        {
            t.EstimatedHours += hours;
            return t; // Повертаємо оновлене завдання
        }

        public static Task operator -(Task t, int hours)
        {
            t.EstimatedHours -= hours;
            if (t.EstimatedHours < 0) t.EstimatedHours = 0; // Захист: час не може бути від'ємним
            return t;
        }

        // Бінарне множення (*) 
        public static Task operator *(Task t, int multiplier)
        {
            t.EstimatedHours *= multiplier;
            return t;
        }

        // Бінарне ділення (/) 
        public static Task operator /(Task t, int divider)
        {
            if (divider != 0)
            {
                t.EstimatedHours /= divider;
            }
            return t;
        }


        // 2. Оператори порівняння розміру (>, <, >=, <=)
        // Порівнюємо завдання за тим, скільки годин вони займають
        public static bool operator >(Task t1, Task t2)
        {
            return t1.EstimatedHours > t2.EstimatedHours;
        }

        public static bool operator <(Task t1, Task t2)
        {
            return t1.EstimatedHours < t2.EstimatedHours;
        }

        public static bool operator >=(Task t1, Task t2)
        {
            return t1.EstimatedHours >= t2.EstimatedHours;
        }

        public static bool operator <=(Task t1, Task t2)
        {
            return t1.EstimatedHours <= t2.EstimatedHours;
        }


        // 3. Оператори рівності (== та !=)
        // Вважаємо завдання однаковими, якщо в них збігаються назва та пріоритет
        public static bool operator ==(Task t1, Task t2)
        {
            // Технічна перевірка, щоб програма не зламалася, якщо одне із завдань порожнє (null)
            if (ReferenceEquals(t1, t2)) return true;
            if (t1 is null || t2 is null) return false;

            return t1.Title == t2.Title && t1.Priority == t2.Priority;
        }

        public static bool operator !=(Task t1, Task t2)
        {
            return !(t1 == t2);
        }

        public override bool Equals(object obj)
        {
            return obj is Task task && this == task;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Priority);
        }
    }
}