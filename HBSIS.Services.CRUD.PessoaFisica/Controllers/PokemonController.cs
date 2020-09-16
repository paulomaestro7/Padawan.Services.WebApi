using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using HBSIS.Services.Model;
using HBSIS.Services.Validation;
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

            var result = pokemonList.Where(s => s.Nome.Contains(Nome)).ToList();

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



        [HttpPut]
        [Route("Pokemon")]
        public ActionResult putPokemon(string Nome, string NovoNome)
        {
            var result = pokemonList.Where(s => s.Nome.Contains(Nome)).ToList();

            result.ForEach(s => {
                pokemonList.Remove(s);
            });

            return Ok(pokemonList);
        }

        [HttpPost]
        [Route("Pokemon")]
        public ActionResult PostPokemon(PokemonGO Pokemon)
        {
            var resulPost = new Result<List<PokemonGO>>();

            var validacao = new PokemonValidation();
            var teste = validacao.Validate(Pokemon);

            if (!teste.IsValid)
            {
                resulPost.Error = true;
                resulPost.Message = teste.Errors.Select(s => s.ErrorMessage).ToArray().FirstOrDefault();
                resulPost.Status = HttpStatusCode.BadRequest;
                return Ok(resulPost);
            }

            resulPost.Data = pokemonList;

            return Ok(resulPost);
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







    class Result<T>
    {
        public T Data { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Status { get; set; }

    }
}
