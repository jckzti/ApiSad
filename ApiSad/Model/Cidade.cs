using System;
using ApiSad.Action;
using ApiSad.Interface;
using ApiSad.Utils;

namespace ApiSad.Model
{
    public class Cidade
    {

        public string Nome { get; set; }

        public Decimal TemperaturaAtual { get { return temperaturaAtual; } }
        private Decimal temperaturaAtual { get; set; }

        public Decimal TemperaturaMedia { get { return temperaturaMedia; } }
        private Decimal temperaturaMedia { get; set; }

        public Decimal Umidade { get { return umidade; } }
        private Decimal umidade { get; set; }

        private CidadeAction CidadeAction { get; set; }

        public CidadeAction GetCidadeAction()
        {
            if (this.CidadeAction == null)
            {
                Random rng = new Random();
                temperaturaAtual = TemperaturaUtil.TemperaturaAleatoria();
                this.CidadeAction = new CidadeAction(this);
                umidade = 100;
            }

            return CidadeAction;
        }

        public Cidade(string Nome)
        {
            this.Nome = Nome;
        }

    }
}
