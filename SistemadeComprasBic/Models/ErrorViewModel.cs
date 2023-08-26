namespace SistemadeComprasBic.Models
{
    public class ErroViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestaId => !string.IsNullOrEmpty(RequestId);
    }
}