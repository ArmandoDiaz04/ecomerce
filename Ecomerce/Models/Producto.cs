namespace Ecomerce.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; }
        public string Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public int Eestado { get; set; }
        public Categoria Categoria { get; set; }
        public List<Subasta> Subastas { get; set; }
        public List<Venta> Ventas { get; set; }
    }
}
