class Temperature
    {
        // Приватне поле
        private double celsius;

        // Властивість для доступу до Цельсія
        public double Celsius
        {
            get { return celsius; }
            set { celsius = value; }
        }

        // Властивість для доступу до Фаренгейта
        public double Fahrenheit
        {
            get { return celsius * 9 / 5 + 32; }
            set { celsius = (value - 32) * 5 / 9; }
        }

        // Конструктор
        public Temperature(double celsius)
        {
            this.celsius = celsius;
        }

        // Індексатор (наприклад, 0 = Celsius, 1 = Fahrenheit)
        public double this[int index]
        {
            get
            {
                return index switch
                {
                    0 => Celsius,
                    1 => Fahrenheit,
                    _ => throw new IndexOutOfRangeException("Індекс має бути 0 (Celsius) або 1 (Fahrenheit)")
                };
            }
            set
            {
                switch (index)
                {
                    case 0:
                        Celsius = value;
                        break;
                    case 1:
                        Fahrenheit = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Індекс має бути 0 (Celsius) або 1 (Fahrenheit)");
                }
            }
        }

        // Перевантаження операторів
        public static bool operator >(Temperature t1, Temperature t2)
        {
            return t1.Celsius > t2.Celsius;
        }

        public static bool operator <(Temperature t1, Temperature t2)
        {
            return t1.Celsius < t2.Celsius;
        }

        public static bool operator ==(Temperature t1, Temperature t2)
        {
            return t1.Celsius == t2.Celsius;
        }

        public static bool operator !=(Temperature t1, Temperature t2)
        {
            return !(t1 == t2);
        }

        // Перевизначення Equals і GetHashCode
        public override bool Equals(object obj)
        {
            if (obj is Temperature t)
                return this == t;
            return false;
        }

        public override int GetHashCode()
        {
            return Celsius.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо об'єкти
            Temperature t1 = new Temperature(25);
            Temperature t2 = new Temperature(30);

            // Доступ через властивості
            Console.WriteLine($"t1: {t1.Celsius}°C / {t1.Fahrenheit}°F");
            Console.WriteLine($"t2: {t2.Celsius}°C / {t2.Fahrenheit}°F");

            // Використання індексатора
            Console.WriteLine($"t1 через індексатор: Celsius={t1[0]}, Fahrenheit={t1[1]}");

            // Використання індексатора для зміни значення
            t1[1] = 212; // задаємо Fahrenheit, змінює Celsius
            Console.WriteLine($"t1 після зміни через індексатор: {t1.Celsius}°C / {t1.Fahrenheit}°F");

            // Використання перевантажених операторів
            Console.WriteLine($"t1 > t2 ? {t1 > t2}");
            Console.WriteLine($"t1 < t2 ? {t1 < t2}");
            Console.WriteLine($"t1 == t2 ? {t1 == t2}");

            Console.ReadKey();
        }
    }