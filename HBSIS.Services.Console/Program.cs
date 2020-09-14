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

            Console.WriteLine(resultRead.Result);

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
