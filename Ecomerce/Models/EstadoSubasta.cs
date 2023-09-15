namespace Ecomerce.Models
{
    public class EstadoSubasta
    {
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public List<DetalleSubasta> DetallesSubasta { get; set; }
    }
}
