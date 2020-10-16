using ATP.Fipe.Models;

namespace ATP.Fipe.Repository
{
    public class VeiculoRepository : BaseRespository<VeiculoModel>, IVeiculoRepository
    {
        public VeiculoRepository() : base("Veiculo") { }
    }
}
