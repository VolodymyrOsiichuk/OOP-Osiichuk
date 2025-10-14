class Plane
{
    // Поля
    private string airline;
    private string model;

    // Властивість
    public int Capacity { get; set; }

    // Конструктор
    public Plane(string airline, string model, int capacity)
    {
        this.airline = airline;
        this.model = model;
        Capacity = capacity;
        Console.WriteLine($"Створено літак: {airline} {model}, місткість: {capacity}");
    }

    // Деструктор
    ~Plane()
    {
        Console.WriteLine($"Літак {airline} {model} видалено з пам'яті.");
    }

    // Метод Fly
    public void Fly()
    {
        Console.WriteLine($"{airline} {model} злітає з пасажирами ({Capacity} місць).");
    }
}
     class Program
    {
        static void Main(string[] args)
        {
            // Створюємо об'єкти
            Plane plane1 = new Plane("AirlineA", "Boeing 737", 180);
            Plane plane2 = new Plane("AirlineB", "Airbus A320", 150);
            Plane plane3 = new Plane("AirlineC", "Embraer 190", 100);

            // Викликаємо методи
            plane1.Fly();
            plane2.Fly();
            plane3.Fly();

            // Вивід властивостей
            Console.WriteLine($"{plane1.Capacity} місць на {plane1}");
        }
    }