namespace Ecomerce.Models
{
    public class Subasta
    {
        public int IdSubasta { get; set; }
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public DateTime TiempoInicia { get; set; }
        public DateTime TiempoFinaliza { get; set; }
        public decimal MontoInicial { get; set; }
        public int IdUsuarioPublica { get; set; }
        public Producto Producto { get; set; }
        public Usuario UsuarioPublica { get; set; }
        public List<DetalleSubasta> DetallesSubasta { get; set; }
    }
}
