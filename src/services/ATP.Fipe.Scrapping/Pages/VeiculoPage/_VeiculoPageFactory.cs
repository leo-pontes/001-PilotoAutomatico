using ATP.Fipe.Scrapping.Config;

namespace ATP.Fipe.Scrapping.Pages
{
    public static class VeiculoPageFactory
    {
        private static CarroPartialPage carroPage;
        private static CaminhaoPartialPage caminhaoPage;
        private static MotoPartialPage motoPage;

        public static VeiculoPage ObterVeiculo(int indiceVeiculo)
        {
            

            VeiculoPage resutado;

            switch (indiceVeiculo)
            {
                case 1: resutado = InstanciaCarro(); break;
                case 2: resutado = InstanciaCaminhao(); break;
                case 3: resutado = InstanciaMoto(); break;
                default: resutado = null; break;
            }

            return resutado;
        }

        private static CarroPartialPage InstanciaCarro()
        {
            var Configuration = new ConfigurationHelper();
            var BrowserHelper = new SeleniumHelper(BrowserEnum.Chrome, Configuration);

            if (carroPage == null)
                carroPage = new CarroPartialPage(BrowserHelper);

            return carroPage;
        }

        private static CaminhaoPartialPage InstanciaCaminhao()
        {
            var Configuration = new ConfigurationHelper();
            var BrowserHelper = new SeleniumHelper(BrowserEnum.Chrome, Configuration);

            if (caminhaoPage == null)
                caminhaoPage = new CaminhaoPartialPage(BrowserHelper);

            return caminhaoPage;
        }

        private static MotoPartialPage InstanciaMoto()
        {
            var Configuration = new ConfigurationHelper();
            var BrowserHelper = new SeleniumHelper(BrowserEnum.Chrome, Configuration);

            if (motoPage == null)
                motoPage = new MotoPartialPage(BrowserHelper);

            return motoPage;
        }
    }
}
