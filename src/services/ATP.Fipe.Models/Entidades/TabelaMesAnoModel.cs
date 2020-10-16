using System.Globalization;

namespace ATP.Fipe.Models.Entidades
{
    public class TabelaMesAnoModel
    {
        public int IdTabela { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public string MesAnoExtenso { get; set; }

        public string MesAno { get => $"{DateTimeFormatInfo.CurrentInfo.GetMonthName(Mes)}/{Ano}"; }

        public TabelaMesAnoModel(int mes, int ano, string extenso)
        {
            Mes = mes;
            Ano = ano;
            MesAnoExtenso = extenso;
        }
    }
}
