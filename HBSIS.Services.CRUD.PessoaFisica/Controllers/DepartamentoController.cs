using System;
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

        [HttpGet]
        [Route("Departamento")]
        public ActionResult GetDepartamento()
        {
            var result = new Model.Departamento()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Descricao = "Tecnologia"
            };
            return Ok(result);
        }

        //public static List<Model.PessoaFisica> minhaLista = new List<Model.PessoaFisica>();

    }
}
