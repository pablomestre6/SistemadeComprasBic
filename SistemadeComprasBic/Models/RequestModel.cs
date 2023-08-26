namespace SistemadeComprasBic.Models
{
    public class RequestModel
    {
        public Guid Id { get; set; }

        public string ProductModel { get; set; }

        public string RequestingSector { get; set; }

        public DepartamentModel Departament { get; set; }
    }
}
