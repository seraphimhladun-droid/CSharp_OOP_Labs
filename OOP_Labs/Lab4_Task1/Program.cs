using System;
using System.Collections.Generic;
using System.IO;

namespace OOP_Laboratory_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string filePath = "lab_results_v2.txt";
            File.WriteAllText(filePath, "========== РЕЗУЛЬТАТИ (ВЕРСІЯ 2: ІНТЕРФЕЙСИ) ==========\n\n");

            Console.WriteLine("\n========== ЗАПУСК ВЕРСІЇ 2 (Інтерфейси) ==========\n");

            // 1. Демонстрація доступу через посилання на інтерфейс
            IPublication magPublication = new Magazine("Forbes", "Українська", "Суспільно-політичне", 5, 2024, 120, 15000);
            IPublication bookPublication = new Book("Захар Беркут", "Українська", "Художнє", "Іван Франко", 2021, 300, 8000);

            // Виклик методів, що є в інтерфейсі (вартість)
            magPublication.CalculateCost(30m, 40m, 15m, filePath);
            bookPublication.CalculateCost(45m, 60m, 20m, filePath);

            // 2. Доступ до специфічних методів похідних класів (класичне приведення типів)
            // Ми перевіряємо, чи є об'єкт журналом, і якщо так - перетворюємо його
            if (magPublication is Magazine)
            {
                Magazine mag = (Magazine)magPublication;
                mag.CalculatePopularityRating(12000, filePath);
            }

            if (bookPublication is Book)
            {
                Book book = (Book)bookPublication;
                book.CalculatePopularityRating(7500, filePath);
            }

            // Робота зі списком інтерфейсів (Поліморфізм)
            List<IPublication> allPublications = new List<IPublication>();
            allPublications.Add(magPublication);
            allPublications.Add(bookPublication);

            foreach (IPublication pub in allPublications)
            {
                pub.PrintInfo();
            }

            Console.WriteLine("\n[INFO] Результати Версії 2 збережено у: {0}", filePath);
            Console.ReadLine(); // Зупинка консолі
        }
    }

    public interface IPublication
    {
        void PrintInfo();
        void CalculateCost(decimal paperCost, decimal printingCost, decimal taxes, string path);
    }

    // Базовий клас реалізує інтерфейс
    public class PrintedPublication : IPublication
    {
        // Класичні закриті поля
        private string _title;
        private decimal _cost;
        private string _language;
        private string _purpose;

        // Класичні властивості
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public decimal Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }
        public string Purpose
        {
            get { return _purpose; }
            set { _purpose = value; }
        }

        public PrintedPublication(string title, string language, string purpose)
        {
            _title = title;
            _language = language;
            _purpose = purpose;
            _cost = 0;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine("Назва: {0} | Вартість: {1} грн | Мова: {2}", Title, Cost, Language);
        }

        public void CalculateCost(decimal paperCost, decimal printingCost, decimal taxes, string path)
        {
            Cost = paperCost + printingCost + taxes;
            string logEntry = string.Format("[V2 COST] {0}: {1} грн\n", Title, Cost);
            File.AppendAllText(path, logEntry);
        }
    }

    // Похідний клас Журнал
    public class Magazine : PrintedPublication
    {
        private int _magazineNumber;
        private int _releaseYear;
        private int _pagesCount;
        private int _circulation;
        private double _popularityRating;

        public int MagazineNumber { get { return _magazineNumber; } set { _magazineNumber = value; } }
        public int ReleaseYear { get { return _releaseYear; } set { _releaseYear = value; } }
        public int PagesCount { get { return _pagesCount; } set { _pagesCount = value; } }
        public int Circulation { get { return _circulation; } set { _circulation = value; } }
        public double PopularityRating { get { return _popularityRating; } set { _popularityRating = value; } }

        public Magazine(string title, string language, string purpose, int magazineNumber, int releaseYear, int pagesCount, int circulation)
            : base(title, language, purpose)
        {
            _magazineNumber = magazineNumber;
            _releaseYear = releaseYear;
            _pagesCount = pagesCount;
            _circulation = circulation;
            _popularityRating = 0;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("   -> Журнал №{0} (Рік: {1}, Стор: {2}) | Рейтинг: {3}%\n",
                              MagazineNumber, ReleaseYear, PagesCount, PopularityRating);
        }

        public void CalculatePopularityRating(int totalSales, string path)
        {
            if (Circulation > 0)
            {
                PopularityRating = Math.Round((double)totalSales / Circulation * 100, 2);
                string logEntry = string.Format("[V2 POPULARITY] Журнал {0}: {1}%\n", Title, PopularityRating);
                File.AppendAllText(path, logEntry);
            }
        }
    }

    // Похідний клас Книга
    public class Book : PrintedPublication
    {
        private string _author;
        private int _releaseYear;
        private int _pagesCount;
        private int _circulation;
        private double _popularityRating;

        public string Author { get { return _author; } set { _author = value; } }
        public int ReleaseYear { get { return _releaseYear; } set { _releaseYear = value; } }
        public int PagesCount { get { return _pagesCount; } set { _pagesCount = value; } }
        public int Circulation { get { return _circulation; } set { _circulation = value; } }
        public double PopularityRating { get { return _popularityRating; } set { _popularityRating = value; } }

        public Book(string title, string language, string purpose, string author, int releaseYear, int pagesCount, int circulation)
            : base(title, language, purpose)
        {
            _author = author;
            _releaseYear = releaseYear;
            _pagesCount = pagesCount;
            _circulation = circulation;
            _popularityRating = 0;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("   -> Автор: {0} (Рік: {1}, Стор: {2}) | Рейтинг: {3}%\n",
                              Author, ReleaseYear, PagesCount, PopularityRating);
        }

        public void CalculatePopularityRating(int totalSales, string path)
        {
            if (Circulation > 0)
            {
                PopularityRating = Math.Round((double)totalSales / Circulation * 100, 2);
                string logEntry = string.Format("[V2 POPULARITY] Книга {0}: {1}%\n", Title, PopularityRating);
                File.AppendAllText(path, logEntry);
            }
        }
    }
}