using System;
using System.IO;

namespace OOP_Laboratory_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string filePath = "lab5_results.txt";
            File.WriteAllText(filePath, "========== РЕЗУЛЬТАТИ ЛАБОРАТОРНОЇ №5 ==========\n\n");

            Console.WriteLine("========== ЗАПУСК ЛАБОРАТОРНОЇ №5 ==========\n");

            // 7. Демонстрація роботи з масивом та індексатором
            Archive myArchive = new Archive(3);

            // Використання конструкторів (Пункт 2)
            myArchive[0] = new Booklet("Проспект КНУ", "Українська", "Інформаційне", 2);
            myArchive[1] = new Booklet("Гайд для вступника", "Українська", "Навчальне", 3);

            // Конструктор копіювання
            Booklet original = (Booklet)myArchive[0];
            myArchive[2] = new Booklet(original);
            ((Booklet)myArchive[2]).Title = "Копія проспекту";

            // Демонстрація операторів (Пункт 5 та 6)
            Booklet b = (Booklet)myArchive[0];
            Console.WriteLine("Початкова ціна буклета: {0} грн", b.UnitPrice);

            b++; // Унарний оператор ++
            Console.WriteLine("Ціна після b++: {0} грн", b.UnitPrice);

            b = -b; // Унарний мінус (знижка)
            Console.WriteLine("Ціна після знижки (-b): {0} грн", b.UnitPrice);

            // Виведення через індексатор (Пункт 7)
            Console.WriteLine("\n--- Вміст архіву ---");
            for (int i = 0; i < 3; i++)
            {
                myArchive[i].PrintInfo();
            }

            Console.WriteLine("\n[INFO] Результати збережено у файл.");
            Console.ReadLine();
        }
    }

    // --- 1. БАЗОВИЙ КЛАС ---
    public class PrintedPublication
    {
        protected string _title;
        protected string _language;
        protected string _purpose;
        protected decimal _unitPrice; // Ціна за один примірник

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        // --- 2. ПЕРЕВАНТАЖЕННЯ КОНСТРУКТОРІВ ---
        public PrintedPublication() // За замовчуванням
        {
            _title = "Невідомо";
            _language = "Укр";
            _purpose = "Загальне";
            _unitPrice = 10.0m;
        }

        public PrintedPublication(string title, string language, string purpose) // З параметрами
        {
            _title = title;
            _language = language;
            _purpose = purpose;
            _unitPrice = 15.0m;
        }

        public PrintedPublication(PrintedPublication other) // Копіювання
        {
            _title = other._title;
            _language = other._language;
            _purpose = other._purpose;
            _unitPrice = other._unitPrice;
        }

        // --- 3. ВІРТУАЛЬНИЙ МЕТОД РОЗРАХУНКУ ВАРТОСТІ ---
        public virtual decimal CalculateTotalProductionCost(int quantity, int pages, decimal pagePrice, decimal coverCoeff, decimal formatCoeff, decimal colorCoeff)
        {
            return quantity * pages * pagePrice * coverCoeff * formatCoeff * colorCoeff;
        }

        // --- 4. ВІРТУАЛЬНИЙ МЕТОД РОЗРАХУНКУ КІЛЬКОСТІ ---
        public virtual int CalculateAvailableQuantity(decimal totalBudget)
        {
            if (_unitPrice > 0)
                return (int)(totalBudget / _unitPrice);
            return 0;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine("Назва: {0} | Мова: {1} | Ціна: {2} грн", _title, _language, _unitPrice);
        }
    }

    // --- 1. ПОХІДНИЙ КЛАС: БУКЛЕТ ---
    public class Booklet : PrintedPublication
    {
        private int _folds; // Специфічне поле (кількість згинів)

        public int Folds
        {
            get { return _folds; }
            set { _folds = value; }
        }

        // Конструктори для Буклету
        public Booklet() : base()
        {
            _folds = 1;
        }

        public Booklet(string title, string language, string purpose, int folds)
            : base(title, language, purpose)
        {
            _folds = folds;
        }

        public Booklet(Booklet other) : base(other)
        {
            _folds = other._folds;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("\n[БУКЛЕТ]");
            base.PrintInfo();
            Console.WriteLine("Кількість згинів: {0}", _folds);
        }

        // --- 5. БІНАРНІ ОПЕРАТОРИ ---
        public static bool operator >(Booklet a, Booklet b)
        {
            return a.UnitPrice > b.UnitPrice;
        }
        public static bool operator <(Booklet a, Booklet b)
        {
            return a.UnitPrice < b.UnitPrice;
        }
        public static bool operator ==(Booklet a, Booklet b)
        {
            return a.UnitPrice == b.UnitPrice;
        }
        public static bool operator !=(Booklet a, Booklet b)
        {
            return a.UnitPrice != b.UnitPrice;
        }

        // --- 6. УНАРНІ ОПЕРАТОРИ ---
        public static Booklet operator ++(Booklet b)
        {
            b.UnitPrice = b.UnitPrice + 2.0m;
            return b;
        }
        public static Booklet operator -(Booklet b) // Знижка 10%
        {
            b.UnitPrice = b.UnitPrice * 0.9m;
            return b;
        }
    }

    // --- 7. КЛАС ДЛЯ РОБОТИ З МАСИВОМ (Індексатор) ---
    public class Archive
    {
        private PrintedPublication[] _items;

        public Archive(int size)
        {
            _items = new PrintedPublication[size];
        }

        // КЛАСИЧНИЙ ІНДЕКСАТОР
        public PrintedPublication this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                _items[index] = value;
            }
        }
    }
}
