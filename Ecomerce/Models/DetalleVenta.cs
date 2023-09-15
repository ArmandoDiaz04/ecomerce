namespace Ecomerce.Models
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public int Cantidad { get; set; }
        public int IdUsuarioCompra { get; set; }
        public DateTime FechaCompra { get; set; }
        public Usuario UsuarioCompra { get; set; }
        public Venta Venta { get; set; }
    }
}
