namespace ATP.Fipe.Models
{
    public class ModeloModel
    {
        public int IdMarca { get; set; }
        public MarcaModel Marca { get; set; }
        public string Descricao { get; set; }

        public ModeloModel(int idMarca, MarcaModel marca, string descricao)
        {
            IdMarca = IdMarca;
            Marca = marca;
            Descricao = descricao;
        }
    }
}
