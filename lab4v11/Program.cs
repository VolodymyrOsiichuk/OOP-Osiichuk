// =====================
    // Інтерфейс IProduct
    // =====================
    interface IProduct
    {
        string Name { get; set; }
        double Price { get; set; }
        void DisplayInfo(); // Метод для виводу інформації про продукт
    }

    // =====================
    // Абстрактний клас ProductBase
    // =====================
    abstract class ProductBase : IProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public ProductBase(string name, double price)
        {
            Name = name;
            Price = price;
        }

        // Абстрактний метод для додаткової специфіки продукту
        public abstract void DisplayInfo();
    }

    // =====================
    // Реалізація: Food
    // =====================
    class Food : ProductBase
    {
        public DateTime ExpirationDate { get; set; } // дата закінчення терміну придатності

        public Food(string name, double price, DateTime expirationDate)
            : base(name, price)
        {
            ExpirationDate = expirationDate;
        }

        // Перевизначення методу DisplayInfo
        public override void DisplayInfo()
        {
            Console.WriteLine($"Їжа: {Name}, Ціна: {Price} грн, Термін придатності: {ExpirationDate:dd.MM.yyyy}");
        }
    }

    // =====================
    // Реалізація: Clothes
    // =====================
    class Clothes : ProductBase
    {
        public string Size { get; set; } // розмір одягу

        public Clothes(string name, double price, string size)
            : base(name, price)
        {
            Size = size;
        }

        // Перевизначення методу DisplayInfo
        public override void DisplayInfo()
        {
            Console.WriteLine($"Одяг: {Name}, Ціна: {Price} грн, Розмір: {Size}");
        }
    }

    // =====================
    // Клас корзини (ShoppingCart) з композицією
    // =====================
    class ShoppingCart
    {
        private List<IProduct> products = new List<IProduct>();

        // Додавання продукту в кошик
        public void AddProduct(IProduct product)
        {
            products.Add(product);
        }

        // Вивід інформації про всі продукти
        public void DisplayCart()
        {
            Console.WriteLine("Вміст кошика:");
            foreach (var product in products)
            {
                product.DisplayInfo();
            }
        }

        // Обчислення загальної суми замовлення
        public double CalculateTotal()
        {
            return products.Sum(p => p.Price);
        }

        // Обчислення середньої ціни за одиницю
        public double CalculateAveragePrice()
        {
            return products.Count > 0 ? products.Average(p => p.Price) : 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо продукти
            Food apple = new Food("Яблуко", 15, DateTime.Now.AddDays(7));
            Food bread = new Food("Хліб", 25, DateTime.Now.AddDays(3));
            Clothes tshirt = new Clothes("Футболка", 200, "M");
            Clothes jeans = new Clothes("Джинси", 800, "L");

            // Створюємо кошик
            ShoppingCart cart = new ShoppingCart();

            // Додаємо продукти (композиція)
            cart.AddProduct(apple);
            cart.AddProduct(bread);
            cart.AddProduct(tshirt);
            cart.AddProduct(jeans);

            // Виводимо інформацію про кошик
            cart.DisplayCart();

            // Виводимо загальну суму та середню ціну
            Console.WriteLine($"\nЗагальна сума замовлення: {cart.CalculateTotal()} грн");
            Console.WriteLine($"Середня ціна за одиницю: {cart.CalculateAveragePrice():F2} грн");
        }
    }