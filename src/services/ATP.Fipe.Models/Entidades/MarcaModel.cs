namespace ATP.Fipe.Models
{
    public class MarcaModel
    {
        public string Descricao { get; set; }
        public TipoVeiculoEnum Tipo { get; set; }

        public MarcaModel(string descricao, TipoVeiculoEnum tipo)
        {
            Descricao = descricao;
            Tipo = tipo;
        }
    }
}
