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

            //GET
            //http://localhost:21725/PokemonAPI/Pokemon
            var URL = "http://localhost:5000/PokemonAPI/Pokemon";

            var httpClient = new HttpClient();
            var resultRequest = httpClient.GetAsync(URL);
            resultRequest.Wait();

            var result = resultRequest.Result.Content.ReadAsStringAsync();
            result.Wait();

            Console.WriteLine(result.Result);


            //DELETE
            //GET
            //http://localhost:21725/PokemonAPI/Pokemon

            Console.WriteLine("Digita algo ai:");
            var nome = Console.ReadLine();
            var resultRequestDelete = httpClient.GetAsync($"{ URL}?Nome={nome}");
            resultRequestDelete.Wait();

            var resultDelete = resultRequestDelete.Result.Content.ReadAsStringAsync();
            result.Wait();

            Console.WriteLine(resultDelete.Result);



            Console.ReadLine();
        }
    }
}
