using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace OOP_Laboratory_V4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string filePath = "lab_results_v4.txt";
            File.WriteAllText(filePath, "========== РЕЗУЛЬТАТИ (ВЕРСІЯ 4: СТАНДАРТНІ ІНТЕРФЕЙСИ) ==========\n\n");

            Console.WriteLine("\n========== ЗАПУСК ВЕРСІЇ 4 (Сортування та Колекції) ==========\n");

            // 1. Створюємо масив журналів
            Magazine[] magazines = new Magazine[3];

            magazines[0] = new Magazine("Forbes", "Укр", "Бізнес", 120, 10000);
            magazines[0].Cost = 150m;
            magazines[0].CalculatePopularityRating(9500, filePath); // 9.5 -> 10 балів

            magazines[1] = new Magazine("Nature", "Англ", "Наука", 80, 5000);
            magazines[1].Cost = 90m;
            magazines[1].CalculatePopularityRating(2000, filePath); // 4.0 -> 4 бали

            magazines[2] = new Magazine("Vogue", "Укр", "Мода", 200, 20000);
            magazines[2].Cost = 250m;
            magazines[2].CalculatePopularityRating(12000, filePath); // 6.0 -> 6 балів

            // ТЕСТ 1: IComparable (Сортування за ціною за замовчуванням)
            Console.WriteLine("--- 1. Сортування за ЦІНОЮ (IComparable) ---");
            Array.Sort(magazines); // Викликає CompareTo всередині класу Magazine
            LogAndPrint(magazines, "Сортування за ціною", filePath);

            // ТЕСТ 2: IComparer (Сортування за сторінками через зовнішній клас)
            Console.WriteLine("\n--- 2. Сортування за СТОРІНКАМИ (IComparer) ---");
            Array.Sort(magazines, new MagazinePagesComparer());
            LogAndPrint(magazines, "Сортування за сторінками", filePath);

            // ТЕСТ 3: IEnumerable (Виведення списку за рейтингом)
            Console.WriteLine("\n--- 3. Виведення за РЕЙТИНГОМ (IEnumerable) ---");
            MagazineCollection catalog = new MagazineCollection(magazines);

            File.AppendAllText(filePath, "\n--- Список журналів за рейтингом (IEnumerable) ---\n");
            foreach (Magazine m in catalog)
            {
                m.PrintInfo();
                string log = string.Format("Журнал: {0} | Рейтинг: {1}/10\n", m.Title, m.SalesScore10);
                File.AppendAllText(filePath, log);
            }

            Console.WriteLine("\n[INFO] Результати збережено у: {0}", filePath);
            Console.ReadLine();
        }

        private static void LogAndPrint(Magazine[] mags, string header, string path)
        {
            File.AppendAllText(path, string.Format("\n--- {0} ---\n", header));
            foreach (Magazine m in mags)
            {
                m.PrintInfo();
                string log = string.Format("Назва: {0} | Ціна: {1} | Стор: {2}\n", m.Title, m.Cost, m.PagesCount);
                File.AppendAllText(path, log);
            }
        }
    }

    // БАЗОВИЙ КЛАС (Класичний стиль)
    public abstract class PrintedPublication
    {
        private string _title;
        private decimal _cost;
        private string _language;
        private string _purpose;

        public string Title { get { return _title; } set { _title = value; } }
        public decimal Cost { get { return _cost; } set { _cost = value; } }
        public string Language { get { return _language; } set { _language = value; } }
        public string Purpose { get { return _purpose; } set { _purpose = value; } }

        public PrintedPublication(string title, string language, string purpose)
        {
            _title = title;
            _language = language;
            _purpose = purpose;
        }

        public abstract void CalculatePopularityRating(int sales, string path);

        public virtual void PrintInfo()
        {
            Console.WriteLine("Назва: {0,-10} | Ціна: {1,6} грн", Title, Cost);
        }
    }

    // КЛАС ЖУРНАЛ (З реалізацією IComparable)
    public class Magazine : PrintedPublication, IComparable
    {
        private int _pagesCount;
        private int _circulation;
        private double _popularityRating;

        public int PagesCount { get { return _pagesCount; } set { _pagesCount = value; } }
        public int Circulation { get { return _circulation; } set { _circulation = value; } }
        public double PopularityRating { get { return _popularityRating; } set { _popularityRating = value; } }

        // ШКАЛА 10 БАЛІВ (Розрахунок: % відсотків ділимо на 10)
        public int SalesScore10
        {
            get { return (int)Math.Round(_popularityRating / 10.0); }
        }

        public Magazine(string t, string l, string p, int pages, int circ) : base(t, l, p)
        {
            _pagesCount = pages;
            _circulation = circ;
        }

        public override void CalculatePopularityRating(int sales, string path)
        {
            if (_circulation > 0)
            {
                _popularityRating = (double)sales / _circulation * 100;
                string log = string.Format("[V4] {0}: {1:F2}% ({2}/10 балів)\n", Title, _popularityRating, SalesScore10);
                File.AppendAllText(path, log);
            }
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Журнал: {0,-10} | Ціна: {1,6} | Стор: {2,4} | Рейтинг: {3}/10",
                               Title, Cost, PagesCount, SalesScore10);
        }

        // РЕАЛІЗАЦІЯ IComparable (Порівняння за ціною)
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Magazine other = obj as Magazine;
            if (other != null)
                return this.Cost.CompareTo(other.Cost);
            else
                throw new ArgumentException("Об'єкт не є Журналом");
        }
    }

    // IComparer №1: Сортування за кількістю сторінок
    public class MagazinePagesComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Magazine m1 = x as Magazine;
            Magazine m2 = y as Magazine;
            return m1.PagesCount.CompareTo(m2.PagesCount);
        }
    }

    // IComparer №2: Сортування за рейтингом (10 балів)
    public class MagazineRatingComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Magazine m1 = x as Magazine;
            Magazine m2 = y as Magazine;
            // Сортуємо від більшого до меншого
            return m2.SalesScore10.CompareTo(m1.SalesScore10);
        }
    }

    // РЕАЛІЗАЦІЯ IEnumerable (Колекція журналів)
    public class MagazineCollection : IEnumerable
    {
        private Magazine[] _items;

        public MagazineCollection(Magazine[] magazines)
        {
            // Робимо копію масиву та сортуємо її за рейтингом
            _items = (Magazine[])magazines.Clone();
            Array.Sort(_items, new MagazineRatingComparer());
        }

        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
