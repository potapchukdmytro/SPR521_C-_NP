using EF_intro.Models;

namespace EF_intro.Repositories
{
    public class CategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Category? GetById(int id)
        {
            return _context.Categories.SingleOrDefault(c => c.Id == id);
        }

        public Category? GetByName(string name)
        {
            return _context.Categories.FirstOrDefault(c => c.Name == name);
        }

        public bool Exists(string name)
        {
            return _context.Categories
                .Any(c => c.Name.ToLower() == name.ToLower());
        }

        public void Add(Category category)
        {
            if (!Exists(category.Name))
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Категорія '{category.Name}' вже існує");
            }
        }

        public void Update(Category category)
        {
            if(!Exists(category.Name))
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Категорія '{category.Name}' вже існує");
            }
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void Delete(string name)
        {
            var category = GetByName(name);
            if(category != null)
            {
                Delete(category);
            }
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
            {
                Delete(category);
            }
        }
    }
}
