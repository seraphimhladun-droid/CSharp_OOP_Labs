using System;

namespace Lab6
{
    public class Screen
    {
        private string _resolution;
        private bool _isTurnedOn;

        public string Resolution
        {
            get { return _resolution; }
            private set { _resolution = value; }
        }

        public bool IsTurnedOn
        {
            get { return _isTurnedOn; }
        }

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