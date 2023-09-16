namespace Ecomerce.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal? PrecioSubasta { get; set; }
        public string ImagenUrl { get; set; }
        public string Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public int Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string TipoProducto { get; set; }
    }
}
