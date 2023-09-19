using System.ComponentModel.DataAnnotations;

namespace Ecomerce.Models
{
    public class Carrito
    {
      

        [Key]  // Define IdCarrito as the primary key
        public int id_carrito { get; set; }
        public int id_usuario { get; set; }
        public int id_producto { get; set; }
        public int Cantidad { get; set; }
        public DateTime fecha_agregado { get; set; }

        public Usuario Usuario { get; set; }
        public Producto Producto { get; set; }
    }
}
