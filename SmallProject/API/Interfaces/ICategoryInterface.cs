using API.Models;

namespace API.Interfaces
{
    public interface ICategoryInterface
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonsByCategory(int id);
        bool CategoryExists(int id);
    }
}
