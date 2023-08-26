namespace SistemadeComprasBic.Models
{
    public class DepartamentModel
    {
        public Guid Id { get; set; }

        public string NameDepartament { get; set; }

        public string Manager { get; set; }

        public string Collaborator { get; set; }

        public DateTime DateTime { get; set; }
    }
}
