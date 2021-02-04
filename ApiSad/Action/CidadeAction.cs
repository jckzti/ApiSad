using System;
using System.Net.Http;
using System.Threading.Tasks;
using ApiSad.Interface;
using ApiSad.Model;
using Newtonsoft.Json.Linq;

namespace ApiSad.Action
{
    public class CidadeAction : ITerritorio
    {

        private Cidade Cidade { get; set; }

        public CidadeAction(Cidade cidade)
        {
            Cidade = cidade;
        }

        public async Task<String> PreencheValores()
        {
            String body;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://community-open-weather-map.p.rapidapi.com/weather?q={Cidade.Nome}, Brasil&lang=pt&units=metric"),
                Headers = {
                            { "x-rapidapi-key", "3adfaf8a3dmshd546669e38be6b9p1df25ajsn255166f5ff69" },
                            { "x-rapidapi-host", "community-open-weather-map.p.rapidapi.com" },
                        }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                JObject jsonRetorno = JObject.Parse(body);
                //cidade.Nome = 

                dynamic principal = (jsonRetorno["main"]);
                //dynamic tempo = (jsonRetorno["weather"][0]);

                Cidade.TemperaturaAtual = principal.temp;
                Cidade.SensacaoTermica = principal.feels_like;
                Cidade.DescricaoTempo = (string)jsonRetorno["weather"][0]["description"];
                Cidade.Umidade = principal.humidity;
                Cidade.TemperaturaMedia = 0;
            }
            return Cidade.ToString();
           
        }

        public decimal PreverTemperaturaAsync(DateTime data)
        {
            return 0;
        }

        public Decimal temperatuaMedia()
        {
            return 0;
        }

    }
}
