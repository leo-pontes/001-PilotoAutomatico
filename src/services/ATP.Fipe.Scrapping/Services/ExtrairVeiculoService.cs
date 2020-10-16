using ATP.Fipe.Models;
using ATP.Fipe.Scrapping.Pages;
using System;

namespace ATP.Fipe.Services
{
    public abstract class ExtrairVeiculoService
    {
        protected VeiculoPage pagina;

        public ExtrairVeiculoService(int idxVeiculo)
        {
            pagina = VeiculoPageFactory.ObterVeiculo(idxVeiculo);

            pagina.AcessarPagina();
            pagina.ClicarNoAccordion();
        }

        public void SelecionarValores(int idxTabela, int idxMarca, int idxModelo, int idxAno)
        {
            pagina.EscolherItemSelect(pagina.ObterIdSelectMesAnoTabela(), idxTabela);
            pagina.EscolherItemSelect(pagina.ObterIdSelectMarca(), idxMarca);
            pagina.EscolherItemSelect(pagina.ObterIdSelectModelo(), idxModelo);
            pagina.EscolherItemSelect(pagina.ObterIdSelectAno(), idxAno);

            pagina.ClicarNoBotaoPesquisar();
        }

        public VeiculoModel ExtrairInformacoes()
        {
            var precoFormatado = Convert.ToDecimal(
                pagina.ObterValorTabelaResultado(IndiceInfoTabelaResultadoEnum.PrecoMedio)
                    .Replace("R$", "").Replace(".", ""));

            var retorno = new VeiculoModel();

            retorno.MesReferencia = pagina.ObterValorTabelaResultado(IndiceInfoTabelaResultadoEnum.MesReferencia);
            retorno.CodigoFipe = pagina.ObterValorTabelaResultado(IndiceInfoTabelaResultadoEnum.CodigoFipe);
            retorno.Marca = pagina.ObterValorTabelaResultado(IndiceInfoTabelaResultadoEnum.Marca);
            retorno.Modelo = pagina.ObterValorTabelaResultado(IndiceInfoTabelaResultadoEnum.Modelo);
            retorno.AnoModelo = pagina.ObterValorTabelaResultado(IndiceInfoTabelaResultadoEnum.AnoModelo);
            retorno.Autenticacao = pagina.ObterValorTabelaResultado(IndiceInfoTabelaResultadoEnum.Autenticacao);
            retorno.PrecoMedio = precoFormatado;
            
            pagina.ClicarNoBotaoLimparPesquisa();

            return retorno;
        }
    }
}
