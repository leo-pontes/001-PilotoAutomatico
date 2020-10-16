namespace ATP.Fipe.Models
{
    public class VeiculoModel
    {
        public int IdVeiculo { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string AnoModelo { get; set; }
        public string MesReferencia { get; set; }
        public string CodigoFipe { get; set; }
        public string Autenticacao { get; set; }        
        public decimal PrecoMedio { get; set; }
        public TipoVeiculoEnum Tipo { get; set; }

        public int IdMarca { get; set; }
        public int IdModelo { get; set; }
        public int IdTabela { get; set; }
    }
}
