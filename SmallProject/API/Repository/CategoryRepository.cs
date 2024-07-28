using API.Data;
using API.Interfaces;
using API.Models;

namespace API.Repository
{
    public class CategoryRepository : ICategoryInterface
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.Name).ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonsByCategory(int id)
        {
            return _context.PokemonCategories.Where(e => e.CategoryId == id).Select(c => c.Pokemon).ToList();
        }
    }
}
