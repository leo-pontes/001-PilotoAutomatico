using ATP.Fipe.Scrapping.Config;
using System.Threading;

namespace ATP.Fipe.Scrapping.Pages
{
    public class CaminhaoPartialPage : VeiculoPage
    {
        public CaminhaoPartialPage(SeleniumHelper helper) 
            : base(helper, 
                  "selectTabelaReferenciacaminhao_chosen", 
                  "selectMarcacaminhao_chosen",
                  "selectAnoModelocaminhao_chosen",
                  "selectAnocaminhao_chosen",
                  "buttonPesquisarcaminhao",
                  "buttonLimparPesquisarcaminhao",
                  "resultadoConsultacaminhaoFiltros") { }

        public override void ClicarNoAccordion()
        {
            Helper.ClicarPorXPath($"//div[@class='tab vertical tab-veiculos']/ul/li[2]/a");
            Thread.Sleep(1000);
        }
    }
}
