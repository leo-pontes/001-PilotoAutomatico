using ATP.Fipe.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ATP.Fipe.Services
{
    public class ExtrairCarroService : ExtrairVeiculoService
    {
        public ExtrairCarroService() : base(1) { }

        public IEnumerable<VeiculoModel> ExtrairTudo()
        {
            var countIdxTabela = 1;

            while (true)
            {
                var lista = ExtrairMarcasTabela(countIdxTabela);

                if (lista.Any()) yield break;

                foreach (var item in lista)
                    yield return item;

                countIdxTabela++;
            }
        }

        public IEnumerable<VeiculoModel> ExtrairMarcasTabela(int idxAnoMes)
        {
            var countIdxMarca = 1;

            var listaRetorno = new List<VeiculoModel>();

            while (true)
            {
                var lista = ExtrairModelosMarca(idxAnoMes, countIdxMarca++);

                if (!lista.Any()) return listaRetorno;

                listaRetorno.AddRange(lista);
            }
        }

        public IEnumerable<VeiculoModel> ExtrairModelosMarca(int idxAnoMes, int idxMarca)
        {
            var countIdxModelo = 1;

            var listaRetorno = new List<VeiculoModel>();

            while (true)
            {
                var itens = ExtrairAnosModelo(idxAnoMes, idxMarca, countIdxModelo++);

                if (!itens.Any()) return listaRetorno;

                listaRetorno.AddRange(itens);
            }
        }

        public IEnumerable<VeiculoModel> ExtrairAnosModelo(int idxAnoMes, int idxMarca, int idxModelo)
        {
            var countIdxAno = 1;

            var listaRetorno = new List<VeiculoModel>();

            while (true)
            {
                var item = CapturarValores(idxAnoMes, idxMarca, idxModelo, countIdxAno++);

                if (item == null) return listaRetorno;

                listaRetorno.Add(item);
            }
        }

        public VeiculoModel CapturarValores(int idxAnoMes, int idxMarca, int idxModelo, int idxAno)
        {
            try
            {
                SelecionarValores(idxAnoMes, idxMarca, idxModelo, idxAno);

                Thread.Sleep(500);

                return ExtrairInformacoes();
            }
            catch
            {
                return null;
            }            
        }
    }
}
