using ATP.Fipe.Scrapping.Config;
using System.Threading;

namespace ATP.Fipe.Scrapping.Pages
{
    public class CarroPartialPage : VeiculoPage
    {       
        public CarroPartialPage(SeleniumHelper helper) 
            : base(helper,
                "selectTabelaReferenciacarro_chosen",
                "selectMarcacarro_chosen",
                "selectAnoModelocarro_chosen",
                "selectAnocarro_chosen",
                "buttonPesquisarcarro",
                "buttonLimparPesquisarcarro",
                "resultadoConsultacarroFiltros") { }

        public override void ClicarNoAccordion() 
        { 
            Helper.ClicarPorXPath($"//div[@class='tab vertical tab-veiculos']/ul/li/a");
            Thread.Sleep(1000);
        }
    }
}
