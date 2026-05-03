using System;

namespace Lab6
{
    public class Smartphone
    {
        // 1. ЗАКРИТІ ПОЛЯ
        private string _brand;
        private int _batteryLevel;
        private bool _isConnectedToTV;

        // 2. ВІДКРИТІ ВЛАСТИВОСТІ (Аксесори)
        public string Brand
        {
            get { return _brand; }
            private set { _brand = value; }
        }

        public int BatteryLevel
        {
            get { return _batteryLevel; }
            private set
            {
                if (value < 0) _batteryLevel = 0;
                else if (value > 100) _batteryLevel = 100;
                else _batteryLevel = value;
            }
        }

        public bool IsConnectedToTV
        {
            get { return _isConnectedToTV; }
        }

        // Конструктор
        public Smartphone(string brand, int initialBattery)
        {
            Brand = brand;
            BatteryLevel = initialBattery;
            _isConnectedToTV = false;
            Console.WriteLine($"[Магазин] Придбано смартфон {Brand}. Заряд: {BatteryLevel}%.");
        }

        // 3. ВІДКРИТІ МЕТОДИ (Поведінка смартфона)

        public void ConnectToTV()
        {
            if (BatteryLevel > 0)
            {
                _isConnectedToTV = true;
                Console.WriteLine($"[Смартфон {Brand}] Успішно підключено до Smart TV по Wi-Fi.");
            }
            else
            {
                Console.WriteLine($"[Смартфон {Brand}] Неможливо підключитися. Батарея розряджена!");
            }
        }

        public void Disconnect()
        {
            _isConnectedToTV = false;
            Console.WriteLine($"[Смартфон {Brand}] Відключено від Smart TV.");
        }

        // Метод керування телевізором (витрачає батарею)
        public void SendCommandToTV(string command)
        {
            if (!_isConnectedToTV)
            {
                Console.WriteLine($"[Смартфон {Brand}] Помилка: спочатку підключіться до телевізора!");
                return;
            }

            if (BatteryLevel <= 0)
            {
                Console.WriteLine($"[Смартфон {Brand}] Телефон вимкнувся (0%).");
                Disconnect();
                return;
            }

            // Кожна команда забирає 2% заряду
            BatteryLevel -= 2;
            Console.WriteLine($"[Смартфон {Brand}] Відправлено команду: '{command}'. Залишок заряду: {BatteryLevel}%");
        }
    }
}
