using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ApiSad.Model;
using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace ApiSad.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class TempoController : Controller
    {
        [FromQuery(Name = "cidade")]
        public string Cidade { get; set; }

        [FromQuery(Name = "data")]
        public string Data { get; set; }


        [FromHeader(Name = "content-type")]
        public string ContentType { get; set; }

        [Route("[controller]/cidade")]
        [HttpPost]
        public IActionResult PostCidade(JObject conteudo)
        {
            dynamic json = JObject.Parse(conteudo.ToString());
            json.oi = "Olá";
            json.cidade = Cidade;
            return Ok(json);
        }

        [Route("[controller]/cidade")]
        [HttpGet]
        public IActionResult GetCidade()
        {
            //dynamic json = JObject.Parse("");            

            if (String.IsNullOrEmpty(Cidade))
            {
                return Problem("Cidade não informada e / ou inválida!");
            }

            Cidade cidade = new Cidade(Cidade);
            var json = new
            {
                temperaturaPrevista = cidade.GetCidadeAction().PreverTemperatura(DateTime.Now),
                cidade = Cidade,
                data = DateTime.Now.ToString("dd/MMM/yy HH:mm")
            };


            Uri usuarioUri;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); //está dando erro caso nao ache a url, tratar
            System.Net.Http.HttpResponseMessage response = client.GetAsync("weatherforecast").Result;
            
            if (response.IsSuccessStatusCode)
            {                
                usuarioUri = response.Headers.Location;
                // response.Content.ReadAsStringAsync().Result   a reposta chega aqui
                dynamic jsonUsuarios = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine(jsonUsuarios);
            }

            //Se der erro na chamada, mostra o status do código de erro.
            else
                Console.WriteLine(response.StatusCode.ToString() + " - " + response.ReasonPhrase);

            return Ok(json);
        }
    }
}
