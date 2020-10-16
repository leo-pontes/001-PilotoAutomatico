using ATP.Fipe.Scrapping.Config;
using System.Threading;

namespace ATP.Fipe.Scrapping.Pages
{
    public class MotoPartialPage : VeiculoPage
    {       
        public MotoPartialPage(SeleniumHelper helper) 
            : base(helper,
                  "selectTabelaReferenciamoto_chosen",
                  "selectMarcamoto_chosen",
                  "selectAnoModelomoto_chosen",
                  "selectAnomoto_chosen",
                  "buttonPesquisarmoto",
                  "buttonLimparPesquisarmoto",
                  "resultadoConsultamotoFiltros") { }

        public override void ClicarNoAccordion() 
        { 
            Helper.ClicarPorXPath($"//div[@class='tab vertical tab-veiculos']/ul/li[3]/a");
            Thread.Sleep(1000);
        }
    }
}
