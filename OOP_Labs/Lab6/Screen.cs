using System;

namespace Lab6
{
    public class Screen
    {
        // 1. ЗАКРИТІ ПОЛЯ (Інкапсуляція)
        // Ніхто ззовні не може випадково зламати екран або змінити його стан напряму
        private string _resolution;
        private bool _isTurnedOn;

        // 2. ВІДКРИТІ ВЛАСТИВОСТІ (Аксесори)
        public string Resolution
        {
            get { return _resolution; }
            // private set означає, що роздільну здатність можна задати лише при створенні екрану
            private set { _resolution = value; }
        }

        public bool IsTurnedOn
        {
            get { return _isTurnedOn; }
        }

        // Конструктор (викликається, коли на заводі створюють цей екран)
        public Screen(string resolution)
        {
            Resolution = resolution;
            _isTurnedOn = false;
            Console.WriteLine($"[Завод] Виготовлено матрицю екрану ({Resolution}).");
        }

        // 3. ВІДКРИТІ МЕТОДИ (Поведінка екрану)
        public void TurnOn()
        {
            _isTurnedOn = true;
            Console.WriteLine($"[Екран] Підсвітку увімкнено. Роздільна здатність: {Resolution}.");
        }

        public void TurnOff()
        {
            _isTurnedOn = false;
            Console.WriteLine("[Екран] Екран погас.");
        }

        public void DisplayContent(string content)
        {
            // Перевіряємо стан перед тим, як щось показувати
            if (_isTurnedOn)
            {
                Console.WriteLine($"[Екран] Відображається яскрава картинка: {content}");
            }
            else
            {
                Console.WriteLine("[Екран помилка] Неможливо показати зображення, екран вимкнено!");
            }
        }
    }
}