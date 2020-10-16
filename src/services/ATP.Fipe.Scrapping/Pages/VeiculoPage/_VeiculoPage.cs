using ATP.Fipe.Scrapping.Config;
using System;

namespace ATP.Fipe.Scrapping.Pages
{
    public abstract class VeiculoPage : BasePage
    {
        private string ID_SELECT_MESANO_TABELA;
        private string ID_SELECT_MARCA;
        private string ID_SELECT_MODELO;
        private string ID_SELECT_ANO;
        private string ID_BOTAO_PESQUISAR;
        private string ID_BOTAO_LIMPAR;
        private string ID_DIV_RESULTADO;

        public VeiculoPage(SeleniumHelper helper, 
            string idSelectMesAnoTabela, 
            string idSelectMarca, 
            string idSelectModelo, 
            string idSelectAno, 
            string idBotaoPesquisar,
            string idBotaoLimpar,
            string idDivResultado) : base(helper) 
        {
            ID_SELECT_MESANO_TABELA = idSelectMesAnoTabela;
            ID_SELECT_MARCA = idSelectMarca;
            ID_SELECT_MODELO = idSelectModelo;
            ID_SELECT_ANO = idSelectAno;
            ID_BOTAO_PESQUISAR = idBotaoPesquisar;
            ID_DIV_RESULTADO = idDivResultado;
            ID_BOTAO_LIMPAR = idBotaoLimpar;
        }

        public void AcessarPagina()
        {
            Helper.IrParaUrl(Helper.Configuration.PaginaUrl);
        }

        public string ObterIdSelectMesAnoTabela() => ID_SELECT_MESANO_TABELA;

        public string ObterIdSelectMarca() => ID_SELECT_MARCA;

        public string ObterIdSelectModelo() => ID_SELECT_MODELO;

        public string ObterIdSelectAno() => ID_SELECT_ANO;        

        public string EscolherItemSelect(string select, int qtdePressDown)
        {
            Helper.ClicarBotaoPorId(select);
            
            Helper.ClicarPorXPath($"//div[@id='{select}']//ul[@class='chosen-results']/li[{qtdePressDown}]");
            
            return Helper.ObterTextoElementoPorId(select);
        }

        public void ClicarNoBotaoPesquisar()
        {
            Helper.ClicarBotaoPorId(ID_BOTAO_PESQUISAR);
        }

        public void ClicarNoBotaoLimparPesquisa()
        {
            //Helper.ClicarPorXPath($"//div[id='{ID_BOTAO_LIMPAR}']//a");
            Helper.ClicarBotaoPorId(ID_BOTAO_LIMPAR);
        }

        public string ObterValorTabelaResultado(IndiceInfoTabelaResultadoEnum idx)
        {
            return Helper.ObterElementoPorXPath($"//div[@id='{ID_DIV_RESULTADO}']//table//tbody//tr[{Convert.ToInt32(idx)}]//td[2]//p").Text;
        }

        public virtual void ClicarNoAccordion() { throw new NotImplementedException(); }
    }
}
