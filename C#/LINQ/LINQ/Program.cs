using System.Text;

namespace LINQ
{
    public class ProductComparer : IComparer<Product>
    {
        public int Compare(Product? x, Product? y)
        {
            if(x == null || y == null)
            {
                return 0;
            }

            if(x.Price < y.Price)
            {
                return -1;
            }
            else if(x.Price > y.Price)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name} - {Category}. Price: {Price}";
        }
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{ProductId}: {Price}";
        }
    }

    internal class Program
    {
        static void SetRandomValues(List<int> list, int count, int min = -100, int max = 100)
        {
            for (int i = 0; i < count; i++)
            {
                var randomNumber = new Random().Next(min, max);
                list.Add(randomNumber);
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var randNums = new List<int>();
            SetRandomValues(randNums, 25);;

            List<string> words = [
            "кіт", "сонце", "програмування", "код", "кава",
            "комп'ютер", "хмара", "база", "алгоритм", "функція",
            "змінна", "цикл", "масив", "рядок", "інтернет",
            "екран", "мишка", "клавіатура", "розробка", "тест"
            ];

            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Ноутбук Asus ZenBook", Category = "Електроніка", Price = 38500.00 },
                new Product { Id = 2, Name = "Смартфон Samsung Galaxy", Category = "Електроніка", Price = 25999.50 },
                new Product { Id = 3, Name = "Бездротові навушники Sony", Category = "Аудіо", Price = 7400.00 },
                new Product { Id = 4, Name = "Кавомашина DeLonghi", Category = "Побутова техніка", Price = 18200.00 },
                new Product { Id = 5, Name = "Електрочайник Tefal", Category = "Побутова техніка", Price = 1550.00 },
                new Product { Id = 6, Name = "Крісло ігрове Hator", Category = "Меблі", Price = 8900.00 },
                new Product { Id = 7, Name = "Стіл комп'ютерний", Category = "Меблі", Price = 4200.00 },
                new Product { Id = 8, Name = "Стіл комп'ютерний", Category = "Меблі", Price = 5600.00 },
                new Product { Id = 9, Name = "Спортивний рюкзак", Category = "Аксесуари", Price = 1850.00 },
                new Product { Id = 10, Name = "Смарт-годинник Apple Watch", Category = "Електроніка", Price = 14999.00 },
                new Product { Id = 11, Name = "Мишка бездротова Logitech", Category = "Комп'ютерна периферія", Price = 1850.00 }
            };


            // Aggregate - арифметичні операції зі всіма числами колеції
            // перший аргемент seed - початкове значення
            int[] nums = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -11];
            int res = nums.Aggregate(1, (seed, value) => seed * value);
            Console.WriteLine("Добуток: " + res);

            // All - повертає bool чи всі значення колекції відповідають умові
            bool isAll = nums.All((num) => num > 0);
            Console.WriteLine(isAll);

            isAll = products.All((p) => p.Price > 1000);
            Console.WriteLine(isAll);

            // Any - повертає bool чи хоча б один елемент відповідає умові
            bool isAny = nums.Any(i => i < 0);
            Console.WriteLine(isAny);

            isAny = products.Any(p => p.Category == "Меблі");
            Console.WriteLine(isAny);

            // Contains - повертає bool чи є такий елемент в колекції
            bool contains = nums.Contains(11);
            Console.WriteLine(contains);


            contains = words.Contains("інтернет");
            Console.WriteLine(contains);

            // CountBy - повертає скільки елементів відповідають умові а скільки ні
            var resCount = nums.CountBy((i) => i > 0);

            // First - повертає перший елемент що відповідає умові, якщо не знадйдено то генерується Exception
            Product samsung = products.First(p => p.Name == "Смартфон Samsung Galaxy");
            Console.WriteLine(samsung.Price);

            // Last - повертає останній елемент що відповідає умові, якщо не знадйдено то генерується Exception
            Product table1 = products.Last(p => p.Name == "Стіл комп'ютерний");
            Console.WriteLine(table1.Price);

            // FirstOrDefault - повертає перший елемент що відповідає умові, якщо не знадйдено то повертає default
            Product backpack = products.FirstOrDefault(p => p.Name == "Спортивний рюкзак t1000");
            if(backpack != null)
            {
                Console.WriteLine(backpack);
            }
            else
            {
                Console.WriteLine("Product not found");
            }

            // LastOrDefault - повертає останній елемент що відповідає умові, якщо не знадйдено то повертає default
            Product table3 = products.Last(p => p.Name == "Стіл комп'ютерний");
            if(table3 != null)
            {
                Console.WriteLine(table3.Price);
            }


            // Single - повертає останній елемент що відповідає умові, але це елемент повинен бути унікальним в колеції
            // Якщо елементу немає то буде Exception
            Product p1 = products.Single(p => p.Price == 8900);
            Console.WriteLine(p1);

            // Single - повертає останній елемент що відповідає умові, але це елемент повинен бути унікальним в колеції
            // Якщо елементу немає то буде повернуто default
            Product p2 = products.SingleOrDefault(p => p.Price == 200.00);
            Console.WriteLine(p1);

            // Max - повертає максимальне значення в колеції
            double maxPrice = products.Max(p => p.Price);
            Console.WriteLine(maxPrice);

            // Min - повертає максимальне значення в колеції
            int minNum = randNums.Min();
            Console.WriteLine(minNum);

            // MaxBy та MinBy - повертають елемент колеції а не саме значення
            Product maxPriceProduct = products.MinBy(p => p.Price);
            Console.WriteLine(maxPriceProduct);

            // OrderBy - сортування властивості по умові зростання
            // OrderByDescending - сортування властивості по умові спадання
            Console.WriteLine("\nВідстортовані товари");
            //var sortedCollection = products.OrderBy(p => p.Price);
            var sortedCollection = products.OrderByDescending(p => p.Price);
            sortedCollection.Print();

            // Order - сортування елементів по умові зростання
            // OrderDescending - сортування елементів по умові спадання
            Console.WriteLine("\nВідстортовані слова");
            var sortedWords = words.Order();
            sortedWords.Print();

            // Where - повртає нову колеції елементів що відповідають умові
            Console.WriteLine("\nТільки парні числа");
            IEnumerable<int> eventNums = randNums.Where(i => i % 2 == 0);
            eventNums.Print(false);

            Console.WriteLine("\nCлова на 4 символи");
            var fourLen = words.Where(s => s.Length == 4);
            fourLen.Print();

            Console.WriteLine("\nТовари дешевше 10тис");
            var productsWhere = products.Where(p => p.Price >= 5000 && p.Price <= 10000);
            productsWhere.Print();

            Console.WriteLine("\nТовари категорії Побутова техніка");
            var tech = products.Where(p => p.Category == "Побутова техніка");
            tech.Print();


            // Take - повертає вказану к-сть елементів
            Console.WriteLine("\nПерші 5 слів");
            var firstFive = words.Take(5);
            firstFive.Print(false);

            // Skip - пропускаємо вказану к-сть елементів
            Console.WriteLine("\nПропущено перші 10 елементів");
            var skipten = words.Skip(10);
            skipten.Print(false);


            // Приклад пагінації з використанням take skip
            Console.WriteLine("\nПагінація");
            int page = 4;
            int pageSize = 5;

            var paginationRes = words.Skip((page - 1) * pageSize).Take(pageSize);
            paginationRes.Print(false);



            // Select - перетворює колецію ондого типу в колецію іншого типу
            var changeSign = nums.Select(i => -i);
            changeSign.Print(false);
            IEnumerable<int> doubleNums = nums.Select(i => i * 2);
            doubleNums.Print(false);

            // Перетворення колеції int у колецію string
            IEnumerable<string> numsStr = nums.Select(i => i.ToString());
            string allNums = string.Join(", ", numsStr);
            Console.WriteLine(allNums);

            // Всі слова у верхньому регістрі
            var upperWords = words.Select(w => w.ToUpper());
            upperWords.Print();

            var firstSymbols = words.Select(w => w[0]);
            firstSymbols.Print(false);

            // Тільки назви товарів
            var productNames = products.Select(p => p.Name);
            productNames.Print(true);

            // Перетворення Products у CartItems
            IEnumerable<CartItem> cartItems = products.Select(p =>
            {
                return new CartItem { ProductId = p.Id, Price = p.Price };
            });

            cartItems.Print();






            // методи можна комбінувати
            Console.WriteLine("\n Назви відсортованих товарів до 10тис");
            var combineRes = products
                .Where(p => p.Price <= 10000)
                .OrderBy(p => p.Price)
                .Select(p => p.Name);

            combineRes.Print();
        }
    }
}
