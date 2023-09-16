using System.ComponentModel.DataAnnotations;

namespace Ecomerce.Models
{
    public class EstadoPedido
    {
        [Key]
        public int id_estado_pedido { get; set; }
        public string Estado { get; set; }
    }
}
