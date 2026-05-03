using System;

namespace Lab6
{
    // 1. СПАДКУВАННЯ: Робимо клас повноцінною помилкою
    public class NetworkLossException : ApplicationException
    {
        // Поле для зберігання деталей збою
        private string _errorLocation;

        // 2. КОНСТРУКТОР: Приймає повідомлення та передає його в базовий клас Exception через :base
        public NetworkLossException(string message) : base(message)
        {
            _errorLocation = "Модуль Smart-зв'язку";
        }

        // 3. ПОЛІМОРФІЗМ: Перевизначаємо Message, щоб додати специфічний текст
        public override string Message
        {
            get
            {
                // Додаємо фірмовий префікс до будь-якого повідомлення
                return $"[КРИТИЧНА ПОМИЛКА ТВ]: {base.Message} (Джерело: {_errorLocation})";
            }
        }
    }
}