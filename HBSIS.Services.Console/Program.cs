using HBSIS.Services.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace HBSIS.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            var URL = "http://localhost:5000/DepartamentoAPI/Departamento"; 
            var httpClient = new HttpClient();
            var result = httpClient.GetAsync(URL);
            result.Wait();

            var resultRead = result.Result.Content.ReadAsStringAsync();
            resultRead.Wait();

            Departamento MeuDepartamento = JsonConvert.DeserializeObject<Departamento>(resultRead.Result);

            Console.WriteLine(MeuDepartamento.Id);
            Console.WriteLine(MeuDepartamento.Descricao);
            Console.WriteLine(MeuDepartamento.Ativo);


            var lite = new LiteDB.LiteDatabase("");
            lite.GetCollection<Departamento>().Insert(MeuDepartamento);

            Console.WriteLine(resultRead.Result);



            var testedoido = new Curso()
            {

                nome = "Matematica",
                materia = new System.Collections.Generic.List<Materia>() {
                    new Materia(){
                        Descricao = 1
                    },
                    new Materia(){ 
                        Descricao = 2
                    }
                }

            };





            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
