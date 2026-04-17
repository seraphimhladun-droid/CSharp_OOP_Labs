using System;
using System.IO;

namespace OOP_Laboratory_V1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string filePath = "lab_results.txt";
            File.WriteAllText(filePath, "========== РЕЗУЛЬТАТИ РОЗРАХУНКІВ (ВЕРСІЯ 1) ==========\n\n");

            Console.WriteLine("\n========== ЗАПУСК ВЕРСІЇ 1 ==========\n");

            // Створення об'єкта Журнал
            Magazine myMagazine = new Magazine("National Geographic", "Українська", "Науково-популярне", 12, 2024, 80, 5000);
            myMagazine.CalculateCost(25.50m, 30.00m, 10.50m, filePath);
            myMagazine.CalculatePopularityRating(4500, filePath);
            myMagazine.PrintInfo();

            // Створення об'єкта Книга
            Book myBook = new Book("Кобзар", "Українська", "Художнє", "Тарас Шевченко", 2023, 450, 10000);
            myBook.CalculateCost(50.00m, 65.50m, 20.00m, filePath);
            myBook.CalculatePopularityRating(9800, filePath);
            myBook.PrintInfo();

            Console.WriteLine("\n[INFO] Усі розрахунки записано у файл: {0}", filePath);
            Console.ReadLine(); // Зупиняємо консоль, щоб вона не закрилась
        }
    }

    // 1. Базовий клас Друкарське_Видання
    public class PrintedPublication
    {
        // Завдання 1: Закриті поля
        private string _title;
        private decimal _cost;
        private string _language;
        private string _purpose;

        // Властивості (аксесори) - класичний запис
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

        // Конструктор з параметрами
        public PrintedPublication(string title, string language, string purpose)
        {
            _title = title;
            _language = language;
            _purpose = purpose;
            _cost = 0;
        }

        // Метод виведення
        public virtual void PrintInfo()
        {
            Console.WriteLine("Назва: {0}", Title);
            Console.WriteLine("Мова: {0}", Language);
            Console.WriteLine("Призначення: {0}", Purpose);
            Console.WriteLine("Вартість: {0} грн", Cost);
        }

        // Метод розрахунку вартості + запис у файл
        public void CalculateCost(decimal paperCost, decimal printingCost, decimal taxes, string path)
        {
            Cost = paperCost + printingCost + taxes;
            string logEntry = string.Format("[COST] Видання: {0}, Повна вартість: {1} грн (Дата: {2})\n", Title, Cost, DateTime.Now);
            File.AppendAllText(path, logEntry);
        }
    }

    // Похідний клас Журнал
    public class Magazine : PrintedPublication
    {
        // Специфічні закриті поля
        private int _magazineNumber;
        private int _releaseYear;
        private int _pagesCount;
        private int _circulation;
        private double _popularityRating;

        // Властивості
        public int MagazineNumber
        {
            get { return _magazineNumber; }
            set { _magazineNumber = value; }
        }
        public int ReleaseYear
        {
            get { return _releaseYear; }
            set { _releaseYear = value; }
        }
        public int PagesCount
        {
            get { return _pagesCount; }
            set { _pagesCount = value; }
        }
        public int Circulation
        {
            get { return _circulation; }
            set { _circulation = value; }
        }
        public double PopularityRating
        {
            get { return _popularityRating; }
            set { _popularityRating = value; }
        }

        // Конструктор з параметрами
        public Magazine(string title, string language, string purpose, int magazineNumber, int releaseYear, int pagesCount, int circulation)
            : base(title, language, purpose)
        {
            _magazineNumber = magazineNumber;
            _releaseYear = releaseYear;
            _pagesCount = pagesCount;
            _circulation = circulation;
            _popularityRating = 0;
        }

        // Методи виведення значень на консоль
        public override void PrintInfo()
        {
            Console.WriteLine("\n--- ЖУРНАЛ ---");
            base.PrintInfo();
            Console.WriteLine("Номер: {0}, Рік: {1}, Сторінок: {2}, Наклад: {3}, Рейтинг: {4}%",
                              MagazineNumber, ReleaseYear, PagesCount, Circulation, PopularityRating);
        }

        // Розрахунок популярності + запис у файл
        public void CalculatePopularityRating(int totalSales, string path)
        {
            if (Circulation > 0)
            {
                PopularityRating = Math.Round((double)totalSales / Circulation * 100, 2);
                string logEntry = string.Format("[POPULARITY] Журнал: {0}, Рейтинг: {1}% (Продано: {2} шт.)\n", Title, PopularityRating, totalSales);
                File.AppendAllText(path, logEntry);
            }
        }
    }

    // 3. Похідний клас Книга
    public class Book : PrintedPublication
    {
        // Специфічні закриті поля
        private string _author;
        private int _releaseYear;
        private int _pagesCount;
        private int _circulation;
        private double _popularityRating;

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        public int ReleaseYear
        {
            get { return _releaseYear; }
            set { _releaseYear = value; }
        }
        public int PagesCount
        {
            get { return _pagesCount; }
            set { _pagesCount = value; }
        }
        public int Circulation
        {
            get { return _circulation; }
            set { _circulation = value; }
        }
        public double PopularityRating
        {
            get { return _popularityRating; }
            set { _popularityRating = value; }
        }

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
            Console.WriteLine("\n--- КНИГА ---");
            base.PrintInfo();
            Console.WriteLine("Автор: {0}, Рік: {1}, Сторінок: {2}, Наклад: {3}, Рейтинг: {4}%",
                              Author, ReleaseYear, PagesCount, Circulation, PopularityRating);
        }

        public void CalculatePopularityRating(int totalSales, string path)
        {
            if (Circulation > 0)
            {
                PopularityRating = Math.Round((double)totalSales / Circulation * 100, 2);
                string logEntry = string.Format("[POPULARITY] Книга: {0}, Рейтинг: {1}% (Продано: {2} шт.)\n", Title, PopularityRating, totalSales);
                File.AppendAllText(path, logEntry);
            }
        }
    }
}