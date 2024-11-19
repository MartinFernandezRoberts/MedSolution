namespace MedSolution.Server
{
    public class DesfirmarRequest
    {
        public int IdFicha { get; set; }
        public string Fecha { get; set; }
        public string Rut { get; set; }
        public bool DesfirmarInformeMedico { get; set; }
        public bool DesfirmarInformeEnfermeria { get; set; }
    }
}
