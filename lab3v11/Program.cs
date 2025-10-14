class Instrument
    {
        // Поля для тривалості концерту і кількості композицій
        protected double concertDuration; // в хвилинах
        protected int numberOfPieces;

        // Конструктор базового класу
        public Instrument(double duration, int pieces)
        {
            concertDuration = duration;
            numberOfPieces = pieces;
        }

        // Віртуальний метод Play
        public virtual void Play()
        {
            Console.WriteLine($"Інструмент грає {numberOfPieces} композицій протягом {concertDuration} хвилин.");
        }

        // Метод для отримання тривалості концерту
        public double GetConcertDuration() => concertDuration;
    }

    // =====================
    // Похідний клас Guitar
    // =====================
    class Guitar : Instrument
    {
        public string Type { get; set; } // тип гітари (акустична/електро)

        // Конструктор похідного класу з викликом базового конструктора
        public Guitar(string type, double duration, int pieces)
            : base(duration, pieces)
        {
            Type = type;
        }

        // Перевизначення методу Play
        public override void Play()
        {
            Console.WriteLine($"Гітара ({Type}) грає {numberOfPieces} композицій протягом {concertDuration} хвилин.");
        }
    }

    // =====================
    // Похідний клас Piano
    // =====================
    class Piano : Instrument
    {
        public string Brand { get; set; } // марка піаніно

        // Конструктор похідного класу з викликом базового конструктора
        public Piano(string brand, double duration, int pieces)
            : base(duration, pieces)
        {
            Brand = brand;
        }

        // Перевизначення методу Play
        public override void Play()
        {
            Console.WriteLine($"Піаніно ({Brand}) грає {numberOfPieces} композицій протягом {concertDuration} хвилин.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо колекцію інструментів
            List<Instrument> instruments = new List<Instrument>();

            // Додаємо різні інструменти (поліморфізм)
            instruments.Add(new Guitar("Акустична", 60, 10));
            instruments.Add(new Piano("Yamaha", 45, 8));
            instruments.Add(new Guitar("Електро", 75, 12));

            // Демонструємо поліморфізм: викликаємо Play() для кожного об'єкта
            foreach (var instrument in instruments)
            {
                instrument.Play();
            }

            // Підрахунок загальної тривалості концерту
            double totalDuration = 0;
            foreach (var instrument in instruments)
            {
                totalDuration += instrument.GetConcertDuration();
            }
            Console.WriteLine($"\nЗагальна тривалість концерту: {totalDuration} хвилин");
        }
    }