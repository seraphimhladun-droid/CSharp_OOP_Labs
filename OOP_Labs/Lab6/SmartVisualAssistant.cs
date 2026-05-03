using System;

namespace Lab6
{
    // Спадкування: Візуальний помічник Є різновидом SmartTV (відношення IS-A)
    public class SmartVisualAssistant : SmartTV
    {
        // 1. УНІКАЛЬНІ ЗАКРИТІ ПОЛЯ (Інкапсуляція власних даних)
        private string _assistantName;
        private bool _isHologramActive;

        // 2. КОНСТРУКТОР
        // Ключове слово base() автоматично викликає конструктор базового класу SmartTV.
        // Тобто: спочатку "збирається" звичайний ТВ (екран + процесор), а потім додаються фішки помічника.
        public SmartVisualAssistant(string assistantName) : base()
        {
            _assistantName = assistantName;
            _isHologramActive = false;
            Console.WriteLine($"[Система] ШІ-ядро ініціалізовано. Ім'я помічника: {_assistantName}.");
        }

        // 3. ПОЛІМОРФІЗМ (Перевизначення віртуального методу)
        // Ми беремо стандартний метод TurnOn() з SmartTV і робимо його крутішим
        public override void TurnOn()
        {
            base.TurnOn(); // Спочатку відпрацьовує стандартне ввімкнення екрану

            // А потім додаємо нашу унікальну поведінку
            Console.WriteLine($"[{_assistantName}] Вітаю! Я ваш персональний голографічний помічник. Готовий до роботи!");
        }

        // 4. УНІКАЛЬНІ ВІДКРИТІ МЕТОДИ (Новий функціонал, якого немає у звичайного ТВ)
        public void ProcessVoiceCommand(string command)
        {
            Console.WriteLine($"\n[{_assistantName}] Розпізнано мікрофоном: '{command}'");

            string lowerCommand = command.ToLower();

            if (lowerCommand.Contains("голограм"))
            {
                ActivateHologram();
            }
            else if (lowerCommand.Contains("фільм") || lowerCommand.Contains("відео"))
            {
                Console.WriteLine($"[{_assistantName}] Зрозумів. Запускаю додаток...");
                // Зверни увагу: ми викликаємо LaunchApp, хоча не писали його в цьому файлі!
                // Він дістався нам у спадок від SmartTV.
                LaunchApp("Netflix");
            }
            else
            {
                Console.WriteLine($"[{_assistantName}] Команда не розпізнана. Шукаю інформацію в мережі...");
            }
        }

        // 5. УНІКАЛЬНИЙ ЗАКРИТИЙ МЕТОД (Прихована логіка)
        private void ActivateHologram()
        {
            _isHologramActive = true;
            Console.WriteLine($"[{_assistantName}] УВАГА: Проектую об'ємну 3D-голограму посеред кімнати! 🌐");
        }
    }
}