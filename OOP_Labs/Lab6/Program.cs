using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Налаштування кодування для коректного відображення української мови
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== ТЕСТУВАННЯ РОЗУМНОГО ТЕЛЕВІЗОРА (Лабораторна №6) ===\n");

            // 1. СТВОРЕННЯ ОБ'ЄКТІВ (Агрегація)
            Smartphone myIPhone = new Smartphone("iPhone 15", 85);

            // 2. СТВОРЕННЯ ГОЛОВНОГО ПРИСТРОЮ (Спадкування)
            SmartVisualAssistant jarvis = new SmartVisualAssistant("Джарвіс");

            // 3. ПІДПИСКА НА ПОДІЇ (Пункт 5 завдання)
            // Ми кажемо: "Коли станеться подія, виклич ці методи"
            jarvis.OnAppStarted += MessageSystem_Notification;
            jarvis.OnSystemError += ServiceCenter_Alert;

            // 4. ВЗАЄМОДІЯ (Агрегація)
            jarvis.SyncWithSmartphone(myIPhone);

            // 5. ОСНОВНИЙ БЛОК ОБРОБКИ (Пункт 4 завдання)
            try
            {
                jarvis.TurnOn(); // Поліморфізм у дії

                Console.WriteLine("\n--- Тестування функцій ---");
                jarvis.ProcessVoiceCommand("Увімкни фільм");
                myIPhone.SendCommandToTV("Збільшити гучність");

                Console.WriteLine("\n--- Тестування виняткових ситуацій (спробуйте кілька разів) ---");
                // Викликаємо метод, який може "викинути" NetworkLossException
                for (int i = 0; i < 3; i++)
                {
                    jarvis.LaunchApp("YouTube");
                }
            }
            // ЛОВИМО НАШУ ВЛАСНУ ПОМИЛКУ
            catch (NetworkLossException ex)
            {
                Console.WriteLine($"\n[CATCH блоку]: Спіймано специфічну помилку!");
                Console.WriteLine(ex.Message);
            }
            // ЛОВИМО БУДЬ-ЯКІ ІНШІ ПОМИЛКИ
            catch (Exception ex)
            {
                Console.WriteLine($"\n[CATCH блоку]: Виникла непередбачувана помилка: {ex.Message}");
            }
            // ВИКОНУЄТЬСЯ ЗАВЖДИ (Завершення роботи)
            finally
            {
                Console.WriteLine("\n[FINALLY блоку]: Завершення сеансу роботи пристрою. Очищення пам'яті...");
            }

            Console.WriteLine("\nНатисніть Enter, щоб вийти...");
            Console.ReadLine();
        }

        // --- МЕТОДИ-ОБРОБНИКИ ПОДІЙ ---

        static void MessageSystem_Notification(string msg)
        {
            Console.WriteLine($"\n>>> [СИСТЕМА ПОВІДОМЛЕНЬ]: {msg}");
        }

        static void ServiceCenter_Alert(string msg)
        {
            Console.WriteLine($"\n>>> [СЕРВІСНИЙ ЦЕНТР]: Отримано сигнал про збій! Текст: {msg}");
            Console.WriteLine(">>> [СЕРВІСНИЙ ЦЕНТР]: Відправка запиту на перезавантаження модуля зв'язку...");
        }
    }
}
