namespace Ecomerce.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuarioPublica { get; set; }
        public Producto Producto { get; set; }
        public Usuario UsuarioPublica { get; set; }
        public List<DetalleVenta> DetallesVenta { get; set; }
    }
}
