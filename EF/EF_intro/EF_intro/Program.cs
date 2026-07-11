using EF_intro.Models;
using System.Text;

namespace EF_intro
{
    internal class Program
    {
        public static void AddProducts(AppDbContext context, params IEnumerable<Product> products)
        {
            // Сказали dbcontext заплавнувати додавання нових товарів
            context.Products.AddRange(products);

            // Кидаємо запит ня всіх заплановані задачі
            context.SaveChanges();
        }

        public static void DeleteProduct(AppDbContext context, Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public static Product? GetById(AppDbContext context, int id)
        {
            var product = context.Products.SingleOrDefault(p => p.Id == id);
            return product;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            using AppDbContext context = new AppDbContext();

            // Додавання товарів
            //List<Product> products = Data.products;
            //AddProducts(context, products);



            // Читання товарів
            //foreach (var item in context.Products)
            //{
            //    Console.WriteLine(item);
            //}

            var products5000 = context.Products
                .Where(p => p.Price <= 5000)
                .OrderBy(p => p.Name);

            foreach (var item in products5000)
            {
                Console.WriteLine(item);
            }



            // Видалення товару
            var product = GetById(context, 21);

            if(product == null)
            {
                Console.WriteLine("Product not found");
            }
            else
            {
                DeleteProduct(context, product);
            }
        }
    }
}
