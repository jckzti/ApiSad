using System;
using ApiSad.Interface;
using ApiSad.Model;

namespace ApiSad.Action
{
    public class CidadeAction : ITerritorio
    {

        private Cidade Cidade { get; set; }

        public CidadeAction(Cidade cidade)
        {
            Cidade = cidade;
        }

        public decimal PreverTemperatura(DateTime data)
        {
            if (Cidade.Nome.Equals("Blumenau", StringComparison.InvariantCultureIgnoreCase)) {
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
