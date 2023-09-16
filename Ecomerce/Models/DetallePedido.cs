using System.ComponentModel.DataAnnotations;

namespace Ecomerce.Models
{
    public class DetallePedido
    {
        [Key]
        public int id_detalle { get; set; }
        public int id_producto { get; set; }
        public int id_pedido { get; set; }
        public int Cantidad { get; set; }
    }
}
