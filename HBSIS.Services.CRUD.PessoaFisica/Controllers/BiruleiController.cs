using System;
using System.Collections.Generic;
using System.Linq;
using HBSIS.Services.Util;
using Microsoft.AspNetCore.Mvc;

namespace HBSIS.Services.CRUD.Controllers
{
    [ApiController]
    [Route("BiruleiApi")]
    public class BiruleiController : ControllerBase
    {
        public BiruleiController()
        {
        }

        [HttpGet]
        [Route("BiruleiReinaldo")]
        public ActionResult GetPessoaFisica()
        {
            var result = new Model.PessoaFisica()
            {
                Cpf = "044.555.554-45",
                Ativo = true,
                Nome = "Paulo Maestro",
                Sexo = "Masculino"
            };
            return Ok(result);
        }

        public static List<Model.PessoaFisica> minhaLista = new List<Model.PessoaFisica>();

        [HttpPost]
        [Route("postBiruleiReinaldo")]
        public ActionResult PostPessoaFisica(Model.PessoaFisica PessoaFisica)
        {
            minhaLista.Add(PessoaFisica);

            return Ok(minhaLista);
        }

        [HttpPost]
        [Route("GetGetBiruleiReinaldo")]
        public ActionResult PostGetPessoaFisica(string NomePessoa)
        {
            return Ok(minhaLista);
        }

        [HttpGet]
        [Route("GetBiruleiReinaldo")]
        public ActionResult GetPessoaFisica(string PessoaFisica)
        {
            var result = new Result<List<Model.PessoaFisica>>();
            try
            {

                result.Data = minhaLista.Where(x => x.Nome.Contains(PessoaFisica)).ToList();


                if (result.Data.Count == 0)
                {
                    result.Error = true;
                    result.Message[0] = Message.NoSuccess;
                    result.Status = System.Net.HttpStatusCode.InternalServerError;

                    return BadRequest(result);
                }
                else
                {
                    result.Error = false;
                    result.Message[0] = Message.Success;
                    result.Status = System.Net.HttpStatusCode.InternalServerError;

                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Message[0] = Message.NoSuccess + ex.Message;
                result.Status = System.Net.HttpStatusCode.InternalServerError;

                return NotFound(result);
            }
        }

        [HttpDelete]
        [Route("DeleteBiruleiReinaldo")]
        public ActionResult DeletePessoaFisica(string PessoaFisica)
        {
            try
            {
                var result = minhaLista.RemoveAll(x => x.Nome == PessoaFisica);

                if (result == 0)
                    return BadRequest(Message.NoSuccess);
                else
                    return Ok(Message.Success);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("PutBiruleiReinaldo")]
        public ActionResult PutPessoaFisica(string PessoaFisica, string NovaPessoaFisica)
        {
            var result = new Result<List<Model.PessoaFisica>>();
            try
            {
                result.Data = minhaLista.Where(x => x.Nome == PessoaFisica).ToList();

                result.Data.Select(s =>
                {
                    s.Nome = NovaPessoaFisica;
                    return s;
                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Message[0] = ex.Message;
                return BadRequest(result);
            }

        }


    }
}
