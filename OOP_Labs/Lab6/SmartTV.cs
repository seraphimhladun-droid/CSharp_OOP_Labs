using System;

namespace Lab6
{
    // 1. ОГОЛОШЕННЯ ДЕЛЕГАТА (Пункт 5 завдання)
    // Це шаблон для методів, які будуть "слухати" події телевізора
    public delegate void SmartTVHandler(string message);

    public class SmartTV
    {
        // 2. КОМПОЗИЦІЯ (Внутрішні деталі)
        private Screen _screen;
        private Processor _cpu;

        // 3. АГРЕГАЦІЯ (Зовнішній пристрій)
        private Smartphone _linkedPhone;

        // 4. ПОДІЇ (Пункт 5 завдання)
        public event SmartTVHandler OnAppStarted;
        public event SmartTVHandler OnSystemError;

        private bool _isPoweredOn;
        private Random _random = new Random();

        // КОНСТРУКТОР (Пункт 1: Реалізація композиції)
        public SmartTV()
        {
            // Телевізор сам купує/створює свої компоненти
            _screen = new Screen("4K Ultra HD");
            _cpu = new Processor("Quad-Core Smart Engine");
            _isPoweredOn = false;
            Console.WriteLine("[SmartTV] Телевізор повністю зібрано та готово до роботи.");
        }

        // МЕТОД ДЛЯ АГРЕГАЦІЇ (Пункт 1: Підключення смартфона)
        public void SyncWithSmartphone(Smartphone phone)
        {
            _linkedPhone = phone;
            _linkedPhone.ConnectToTV();
            Console.WriteLine($"[SmartTV] Зв'язок зі смартфоном {phone.Brand} встановлено.");
        }

        // --- ФУНКЦІЇ SMART TV ---

        public virtual void TurnOn()
        {
            _isPoweredOn = true;
            _screen.TurnOn();
            Console.WriteLine("--- Smart TV: Завантаження системи WebOS... ---");
        }

        public void LaunchApp(string appName)
        {
            if (!_isPoweredOn)
            {
                Console.WriteLine("Помилка: Телевізор вимкнено!");
                return;
            }

            try
            {
                // Моделювання випадкового збою мережі (Пункт 4 завдання)
                if (_random.Next(1, 10) > 8)
                {
                    // Генеруємо нашу власну помилку
                    throw new NetworkLossException($"Втрачено зв'язок з сервером при запуску {appName}.");
                }

                Console.WriteLine($"\n[SmartTV] Запуск '{appName}'...");
                _cpu.ProcessTask(appName, 25);
                _screen.DisplayContent($"Інтерфейс додатку {appName}");

                // Викликаємо подію успішного запуску (Пункт 5 завдання)
                OnAppStarted?.Invoke($"Користувач почав перегляд у '{appName}'.");
            }
            catch (NetworkLossException ex)
            {
                // Викликаємо подію помилки
                OnSystemError?.Invoke(ex.Message);

                // Прокидаємо помилку далі, щоб її зловили в Program.cs
                throw;
            }
        }

        public void UseVoiceControl(string command)
        {
            Console.WriteLine($"[Голосове управління] Прийнято команду: {command}");
            if (command.Contains("вимкни")) _screen.TurnOff();
        }
    }
}