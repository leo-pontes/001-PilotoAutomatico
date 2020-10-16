using ATP.Fipe.Models;
using System.Threading.Tasks;

namespace ATP.Fipe.Services
{
    public class ExtracaoFipeService
    {
        public readonly IVeiculoRepository _repository;
        public readonly ExtrairCarroService _extrairCarroService;        

        public ExtracaoFipeService(IVeiculoRepository repository, 
            ExtrairCarroService extrairCarroService)
        {
            _repository = repository;
            _extrairCarroService = extrairCarroService;
        }

        public async Task ExtrairCarros()
        {           
            foreach (var item in _extrairCarroService.ExtrairMarcasTabela(1))
            {
                await _repository.InserirAsync(item);
            }
        }

        public async Task ExtrairCaminhoes()
        {

        }

        public async Task ExtrairMotos()
        {

        }
    }
}
