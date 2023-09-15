namespace Ecomerce.Models
{
    public class Carrito
    {
        public int IdCarrito { get; set; }
        public int IdUsuario { get; set; }
        public decimal TotalPagar { get; set; }
        public Usuario Usuario { get; set; }
    }
}
