using System;
using ApiSad.Interface;
using ApiSad.Model;

namespace ApiSad.Action
{
    public class CidadeAction : ITerritorio
    {

        private Cidade cidade { get; set; }

        public CidadeAction(string cidadeNome)
        {
            cidade = new Cidade(cidadeNome);
        }

        public decimal PreverTemperatura(DateTime data)
        {
            if (cidade.Nome.Equals("Blumenau", StringComparison.InvariantCultureIgnoreCase)) {
                return 50;
            }
            return 1;
        }

        public Decimal temperatuaMedia()
        {
            return 1;
        }
    }
}
