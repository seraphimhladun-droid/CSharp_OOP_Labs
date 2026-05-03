using System;

namespace Lab6
{
    public class Processor
    {
        private string _modelName;
        private int _loadPercentage;

        public string ModelName
        {
            get { return _modelName; }
            private set { _modelName = value; }
        }

        // Розумна властивість: захищає процесор від "перегорання" (більше 100%)
        public int LoadPercentage
        {
            get { return _loadPercentage; }
            private set
            {
                if (value > 100)
                {
                    _loadPercentage = 100;
                }
                else if (value < 0)
                {
                    _loadPercentage = 0;
                }
                else
                {
                    _loadPercentage = value;
                }
            }
        }

       
        public Processor(string model)
        {
            ModelName = model;
            LoadPercentage = 0; // При створенні процесор не навантажений
            Console.WriteLine($"[Завод] Встановлено процесор: {ModelName}");
        }

        // Метод для виконання завдань (наприклад, запуск гри)
        public void ProcessTask(string taskName, int requiredLoad)
        {
            Console.WriteLine($"[Процесор {ModelName}] Отримано завдання: {taskName}...");

            // Збільшуємо навантаження
            LoadPercentage += requiredLoad;

            if (LoadPercentage == 100)
            {
                Console.WriteLine($"[УВАГА] Процесор завантажений на 100%! Можливі затримки.");
            }
            else
            {
                Console.WriteLine($"[Процесор] Завдання обробляється. Поточне навантаження: {LoadPercentage}%");
            }
        }

        // Метод для охолодження (зменшення навантаження після закриття додатку)
        public void FreeResources(int releasedLoad)
        {
            LoadPercentage -= releasedLoad;
            Console.WriteLine($"[Процесор] Ресурси звільнено. Навантаження впало до: {LoadPercentage}%");
        }
    }
}