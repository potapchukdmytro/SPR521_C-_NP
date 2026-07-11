using EF_intro.Models;

namespace EF_intro.Repositories
{
    public class ProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public List<Product> GetAllWhere(Func<Product, bool> pred)
        {
            var products = _context.Products
                .Where(pred)
                .ToList();
            return products;
        }

        public Product? GetById(int id)
        {
            return _context.Products.Single(p => p.Id == id);
        }

        public Product? GetByName(string name)
        {
            return _context.Products
                .FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        }

        public void Add(params IEnumerable<Product> products)
        {
            _context.Products.AddRange(products);
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
