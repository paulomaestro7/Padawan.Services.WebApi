using HBSIS.Services.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            List<PokemonGO> minhalista = new List<PokemonGO>();
            minhalista = JsonConvert.DeserializeObject<List<PokemonGO>>(result.Result);

            minhalista.ForEach(s => {
                Console.WriteLine(s.Nome);
                Console.WriteLine(s.Tipo);
                Console.WriteLine(s.Forca);
            });

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
    class PokemonGO
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int Forca { get; set; }
    }
}
