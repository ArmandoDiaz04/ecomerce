namespace Ecomerce.Models
{
    public class DetalleSubasta
    {
        public int IdDetalle { get; set; }
        public int IdSubasta { get; set; }
        public int IdUsuario { get; set; }
        public decimal MontoTotal { get; set; }
        public int IdEstado { get; set; }
        public Subasta Subasta { get; set; }
        public Usuario Usuario { get; set; }
        public EstadoSubasta EstadoSubasta { get; set; }
    }
}
