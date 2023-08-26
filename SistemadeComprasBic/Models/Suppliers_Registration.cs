namespace SistemadeComprasBic.Models
{
    public class SuppliersRegistration
    {
        public Guid Id { get; set; }

        public string Company { get; set; }

        public string EmailSupplier { get; set; }

        public string CNPJ { get; set; }

        public string Phone { get; set; }
    }
}
