using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiSad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MediaController : Controller
    {

        public IActionResult Post(JObject conteudo)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            dynamic json = JObject.Parse(conteudo.ToString());

            json.valores = json.valores;
            double total = 0;
            foreach (double valor in json.valores)
            {
                if (valor > 10 || valor < 0)
                {
                    return Problem("Valor precisam estar entre 0 e 10", null, 400, "Valores incorretos", null);
                }
                total += valor;
            }
            total = total / json.valores.Count;
            //return Ok(); // BadRequestResult
            //return Problem("Valor precisam estar entre 0 e 10", null, 400, "Valores incorretos", null);
            stopWatch.Stop();
            var resultado = new { resultado = total, tempoGasto = stopWatch.Elapsed };
            string alo = "ALO";
            string alou = $"Alou significa {alo}";
            return Ok(resultado);
        }
    }
}
