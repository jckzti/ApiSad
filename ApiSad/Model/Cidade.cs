using System;
using ApiSad.Action;
using ApiSad.Interface;

namespace ApiSad.Model
{
    public class Cidade
    {

        public string Nome { get; set; }

        public Decimal TemperaturaAtual { get; }

        public Decimal TemperaturaMedia { get; }

        private CidadeAction CidadeAction { get; set; }

        public CidadeAction GetCidadeAction()
        {
            if (this.CidadeAction == null)
            {
                this.CidadeAction = new CidadeAction(this);
            }

            return CidadeAction;
        }

        public Cidade(string Nome)
        {
            this.Nome = Nome;
        }

    }
}
