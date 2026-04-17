using System;
using System.Collections.Generic;
using System.IO;

namespace OOP_Laboratory_V3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string filePath = "lab_results_v3.txt";
            File.WriteAllText(filePath, "========== РЕЗУЛЬТАТИ (ВЕРСІЯ 3: АБСТРАКТНИЙ КЛАС) ==========\n\n");

            Console.WriteLine("\n========== ЗАПУСК ВЕРСІЇ 3 (Абстрактні класи) ==========\n");

            PrintedPublication mag = new Magazine("National Geographic", "Українська", "Наука", 12, 2024, 80, 5000);
            PrintedPublication book = new Book("Тіні забутих предків", "Українська", "Художнє", "М. Коцюбинський", 2021, 300, 10000);

            // Виклик звичайного методу, який реалізований в абстрактному класі
            mag.CalculateCost(20.50m, 30.00m, 10.00m, filePath);
            book.CalculateCost(40.00m, 50.00m, 15.00m, filePath);


            // Спільний список для виводу
            List<PrintedPublication> pubs = new List<PrintedPublication>();
            pubs.Add(mag);
            pubs.Add(book);

            foreach (PrintedPublication p in pubs)
            {
                p.PrintInfo();
            }

            Console.WriteLine("\n[INFO] Результати Версії 3 збережено у: {0}", filePath);
            Console.ReadLine();
        }
    }
    // АБСТРАКТНИЙ БАЗОВИЙ КЛАС
    public abstract class PrintedPublication
    {
        private string _title;
        private decimal _cost;
        private string _language;
        private string _purpose;
        private double _rating;

        public string Title { get { return _title; } set { _title = value; } }
        public decimal Cost { get { return _cost; } set { _cost = value; } }
        public string Language { get { return _language; } set { _language = value; } }
        public string Purpose { get { return _purpose; } set { _purpose = value; } }
        public double Rating { get { return _rating; } set { _rating = value; } }

        public PrintedPublication(string title, string language, string purpose)
        {
            _title = title;
            _language = language;
            _purpose = purpose;
            _cost = 0;
            _rating = 0;
        }

        // Звичайний метод
        public void CalculateCost(decimal paper, decimal print, decimal tax, string path)
        {
            Cost = paper + print + tax;
            string log = string.Format("[V3 COST] {0}: {1} грн\n", Title, Cost);
            File.AppendAllText(path, log);
        }

        // Віртуальний метод
        public virtual void PrintInfo()
        {
            Console.WriteLine("Видання: {0} | Мова: {1} | Ціна: {2} грн", Title, Language, Cost);
        }

        // АБСТРАКТНИЙ МЕТОД: не має тіла. 
        public abstract void CalculatePopularityRating(int sales, string path);
    }


    // Похідний клас: Журнал
    public class Magazine : PrintedPublication
    {
        private int _magazineNumber;
        private int _releaseYear;
        private int _pagesCount;
        private int _circulation;

        public Magazine(string t, string l, string p, int num, int year, int pages, int circ)
            : base(t, l, p)
        {
            _magazineNumber = num;
            _releaseYear = year;
            _pagesCount = pages;
            _circulation = circ;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("   -> ЖУРНАЛ №{0} | Наклад: {1} | Рейтинг: {2}%\n",
                              _magazineNumber, _circulation, Rating);
        }

        // Реалізація абстрактного методу для журналу
        public override void CalculatePopularityRating(int sales, string path)
        {
            if (_circulation > 0)
            {
                Rating = Math.Round((double)sales / _circulation * 100, 2);
                string log = string.Format("[V3 POPULARITY] Журнал {0}: {1}%\n", Title, Rating);
                File.AppendAllText(path, log);
            }
        }
    }


    // ПОХІДНИЙ КЛАС: КНИГА
    public class Book : PrintedPublication
    {
        private string _author;
        private int _releaseYear;
        private int _pagesCount;
        private int _circulation;

        public Book(string t, string l, string p, string a, int year, int pages, int circ)
            : base(t, l, p)
        {
            _author = a;
            _releaseYear = year;
            _pagesCount = pages;
            _circulation = circ;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("   -> КНИГА. Автор: {0} | Рік: {1} | Рейтинг: {2}%\n", _author, _releaseYear, Rating);
        }

        // Реалізація абстрактного методу для книги
        public override void CalculatePopularityRating(int sales, string path)
        {
            if (_circulation > 0)
            {
                Rating = Math.Round((double)sales / _circulation * 100, 2);
                string log = string.Format("[V3 POPULARITY] Книга {0}: {1}%\n", Title, Rating);
                File.AppendAllText(path, log);
            }
        }
    }
}