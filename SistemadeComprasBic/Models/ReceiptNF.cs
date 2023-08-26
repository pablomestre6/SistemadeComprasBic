namespace SistemadeComprasBic.Models
{
    public class ReceiptNF
    {
        public Guid Id { get; set; }

        public string NumberNF { get; set; }

        public string Approves { get; set; }

        public string NotAproves { get; set; }
    }
}
