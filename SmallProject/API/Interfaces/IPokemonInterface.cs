using API.Models;

namespace API.Interfaces
{
    public interface IPokemonInterface
    {
        ICollection<Pokemon> GetPokemons();

        Pokemon GetPokemon(int id);

        Pokemon GetPokemon(string name);

        decimal GetPokemonRating(int id);

        bool PokemonExists(int id);
    }
}
