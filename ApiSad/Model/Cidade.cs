using System;
using System.Threading.Tasks;
using ApiSad.Action;
using ApiSad.Interface;
using ApiSad.Utils;

namespace ApiSad.Model
{
    public class Cidade
    {

        public string Nome { get; set; }

        public Decimal TemperaturaAtual { get; set; }

        public Decimal TemperaturaMedia { get; set; }

        public Decimal Umidade { get; set; }

        public Decimal SensacaoTermica { get; set; }

        public string DescricaoTempo { get; set; }

        private CidadeAction CidadeAction { get; set; }

        public CidadeAction GetCidadeAction()
        {
            if (this.CidadeAction == null)
            {
                this.CidadeAction = new CidadeAction(this);
            }

            return CidadeAction;
        }

        public async Task<String> CarregaInformacoes()
        {
           return await GetCidadeAction().PreencheValores();
        }

        public Cidade(string Nome)
        {
            this.Nome = Nome;
        }

    }
}
