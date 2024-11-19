namespace MedSolution.Server.Models
{
    public class Ficha
    {
        public int IdFicha { get; set; }
        public int IdPaciente { get; set; }
        public string Fecha { get; set; }
        public int FirmaInforme { get; set; }
        public int FirmaEnfermeria { get; set; }
    }
}
