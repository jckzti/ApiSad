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
            
            return Ok(json);
        }
    }
}
