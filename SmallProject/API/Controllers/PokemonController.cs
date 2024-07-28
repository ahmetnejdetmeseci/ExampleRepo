﻿using API.Dtos;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController: Controller
    {
        private readonly IPokemonInterface _pokemonInterface;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonInterface pokemonInterface, IMapper mapper)
        {
            _pokemonInterface = pokemonInterface;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonInterface.GetPokemons());
        
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pokemons);

        }


        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type=typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId)
        {
            if (!_pokemonInterface.PokemonExists(pokeId))
            {
                return NotFound();
            }

            var pokemon = _mapper.Map<PokemonDto>(_pokemonInterface.GetPokemon(pokeId));

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pokemon);
        }


        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeId)
        {
            if (!_pokemonInterface.PokemonExists(pokeId))
            {
                return NotFound();
            }

            var rating = _pokemonInterface.GetPokemonRating(pokeId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }

            return Ok(rating);
        }


    }
}
