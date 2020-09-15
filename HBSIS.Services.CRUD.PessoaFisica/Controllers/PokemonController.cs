using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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


        [HttpGet]
        [Route("PokemonP")]
        public ActionResult GetPokemon(string Nome)
        {
            var retorno = new Result<List<PokemonGO>>();

            var result = pokemonList.Where(s => s.Nome == Nome).ToList();

            if (result.Any())
            {
                retorno.Data = result;
                retorno.Status = HttpStatusCode.OK;

            }
            else
            {
                retorno.Status = HttpStatusCode.BadRequest;
                retorno.Error = true;
                retorno.Message = "Não tem ninguem aqui, pesquisa invalida";
            }
            return Ok(retorno);

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


    class Result<T>
    {
        public T Data { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Status { get; set; }

    }
}
