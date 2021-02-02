using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ApiSad.Model;
using System;

namespace ApiSad.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class TempoController : Controller
    {
        [FromQuery(Name = "cidade")]
        public string Cidade { get; set; }

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
        public IActionResult GetCidade(JObject conteudo)
        {
            dynamic json = JObject.Parse(conteudo.ToString());
            Cidade cidade = new Cidade(Cidade);
            json.temperaturaPrevista = cidade.GetCidadeAction().PreverTemperatura(DateTime.Now);
            json.cidade = Cidade;
            json.data = DateTime.Now.ToString("dd/MMM/yy HH:mm");
            return Ok(json);
        }
    }
}
