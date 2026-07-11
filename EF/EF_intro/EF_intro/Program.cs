using EF_intro.Models;
using EF_intro.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public static void Update(AppDbContext context)
        {
            var oldProduct = GetByName(context, "Вебкамера Logitech C920");
            if (oldProduct != null)
            {
                oldProduct.Price = 3300;
                context.Update(oldProduct);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Product not found");
            }
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

        public static Product? GetByName(AppDbContext context, string name)
        {
            var product = context.Products.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
            return product;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            using AppDbContext context = new AppDbContext();
            ProductRepository productRepository = new ProductRepository(context);
            CategoryRepository categoryRepository = new CategoryRepository(context);

            var products = productRepository.GetAllWhere(p => p.Price >= 5000);

            foreach (var item in products)
            {
                Console.WriteLine(item);
            }

            //Product newProduct = new Product
            //{
            //    Name = "Відеокарта ASUS PCI-Ex GeForce RTX 5060 Dual OC Edition 8GB GDDR7",
            //    Amount = 5,
            //    Price = 18199,
            //    Description = "Подвійні вентилятори, ідеальна сумісність\r\nASUS Dual GeForce RTX 5060 поєднує потужну систему охолодження з широкою сумісністю. Удосконалені технології охолодження, запозичені з флагманських моделей відеокарт, включають два вентилятори Axial-tech, які оптимізують повітряний потік до радіатора. Завдяки компактному форм-фактору у 2.5 слота, відеокарта забезпечує більше потужності в меншому просторі. Ці переваги роблять ASUS Dual ідеальним вибором для геймерів, яким потрібна максимальна продуктивність у компактному корпусі."
            //};

            //productRepository.Add(newProduct);

            //var product = productRepository.GetById(23);
            //if(product != null)
            //{
            //    productRepository.Delete(product);
            //}



            // Add category
            //Category category = new Category
            //{
            //    Name = "Ноутбуки"
            //};

            //categoryRepository.Add(category);

            // Update Category
            //var category = categoryRepository.GetById(2);
            //if(category != null)
            //{
            //    category.Name = "Монітори";
            //    categoryRepository.Update(category);
            //}


            // Delete category
            // categoryRepository.Delete("blablabla");
        }
    }
}
