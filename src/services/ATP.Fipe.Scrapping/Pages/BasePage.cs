using ATP.Fipe.Scrapping.Config;

namespace ATP.Fipe.Scrapping.Pages
{
    public abstract class BasePage
    {
        protected readonly SeleniumHelper Helper;

        protected BasePage(SeleniumHelper helper)
        {
            Helper = helper;
        }

        public string ObterUrl()
        {
            return Helper.ObterUrl();
        }

        public void NavegarParaUrl(string url)
        {
            Helper.IrParaUrl(url);
        }
    }
}
