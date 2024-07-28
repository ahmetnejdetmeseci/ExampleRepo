using API.Data;
using API.Interfaces;
using API.Models;

namespace API.Repository
{
    public class PokemonRepository : IPokemonInterface
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext dataContext) 
        {
            _context = dataContext;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int id)
        {
            var review = _context.Reviews.Where(r => r.Pokemon.Id == id);

            if(review.Count() <= 0) 
            {
                return 0;
            }
            
            return (decimal)review.Sum(r => r.Rating) / review.Count();

        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int id)
        {
            return _context.Pokemons.Any(p => p.Id == id);
        }

        
    }
}
