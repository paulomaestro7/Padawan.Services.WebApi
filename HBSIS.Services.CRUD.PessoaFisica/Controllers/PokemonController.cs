using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace HBSIS.Services.CRUD.Controllers
{

    /// <summary>
    /// http://localhost:21725/PokemonAPI/Pokemon
    /// </summary>

    [ApiController]
    [Route("PokemonAPI")]
    public class PokemonController : ControllerBase
    {
        public PokemonController()
        {
            PokemonGO();
        }

        [HttpGet]
        [Route("Pokemon")]
        public ActionResult GetPokemon()
        {
            return Ok(pokemonList);
        }

        [HttpDelete]
        [Route("Pokemon")]
        public ActionResult DelPokemon(string Nome)
        {
            var result = pokemonList.Where(s => s.Nome.Contains(Nome)).ToList();

            result.ForEach(s => {
                pokemonList.Remove(s);
            });
                
            return Ok(pokemonList);
        }


        private static List<PokemonGO> pokemonList = new List<PokemonGO>();
        private void PokemonGO()
        {
            pokemonList.Add(new PokemonGO()
            {
                Nome = "Pikachu",
                Tipo = "Eletrico",
                Forca = 50
            });
        }
    }




    class PokemonGO
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int Forca { get; set; }
    }
}
