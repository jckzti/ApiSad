using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ApiSad.Model;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetCidadeAsync()
        {
            //dynamic json = JObject.Parse("");            

            if (String.IsNullOrEmpty(Cidade))
            {
                return Problem("Cidade não informada e / ou inválida!");
            }

            Cidade cidade = new Cidade(Cidade);
            await cidade.CarregaInformacoes();

            HttpClient client = new HttpClient();
            if (System.Environment.OSVersion.VersionString.Contains("WINDOWS", StringComparison.InvariantCultureIgnoreCase)) // uso futuro
                client.BaseAddress = new Uri("https://localhost:44358");
            else
                client.BaseAddress = new Uri("https://localhost:5001");

            var cidadeJson = new {
                cidade = cidade.Nome, // deixar primeiras letras maísculas
                temperaturaAtual = cidade.TemperaturaAtual ,
                sensacaoTermica = cidade.SensacaoTermica,
                descricaoTempo =  cidade.DescricaoTempo, // deixar primeira letra maíscula
                umidade = cidade.Umidade,
                temperaturaMedia = cidade.TemperaturaMedia,
                dataAtual = DateTime.Now.ToString("dd/MMM/yy HH:mm:ss")
            };

            return Ok(cidadeJson);
        }
    }
}
