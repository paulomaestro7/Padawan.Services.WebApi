using System;
using System.Collections.Generic;
using System.Linq;
using HBSIS.Services.CRUD.PessoaFisica;
using Microsoft.AspNetCore.Mvc;

namespace HBSIS.Services.CRUD.Controllers
{
    [ApiController]
    [Route("DepartamentoAPI")]
    public class DepartamentoController : ControllerBase
    {
        public DepartamentoController()
        {
        }

        static List<Model.Departamento> Minhalista = new List<Model.Departamento>();

        [HttpPost]
        [Route("Departamento")]
        public ActionResult PostDepartamento(Model.Departamento Departamento)
        {
            Minhalista.Add(Departamento);

            return Ok(Minhalista);
        }

        [HttpDelete]
        [Route("Departamento")]
        public ActionResult DeleteDepartamento(Guid Guid)
        {
            var result = new Result<List<Model.Departamento>>();

            if (Minhalista.Where(s => s.Id == Guid).Any())
            {
                Minhalista.RemoveAll(s => s.Id == Guid);
                result.Data = Minhalista;
            }
            else
            {
                result.Error = true;
                result.Status = System.Net.HttpStatusCode.BadRequest;
                result.Message = "Registro não localizado!";
            }

            return Ok(result);
        }

        //public static List<Model.PessoaFisica> minhaLista = new List<Model.PessoaFisica>();

    }
}
