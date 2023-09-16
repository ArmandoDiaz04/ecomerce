using System.ComponentModel.DataAnnotations;

namespace Ecomerce.Models
{
    public class Pedido
    {
        [Key]
        public int id_pedido { get; set; }
        public double total_pagar { get; set; }
        public DateTime fecha_pedido { get; set; }
        public int id_estado_pedido { get; set; }
        public int id_usuario { get; set; }
        public string Ubicacion { get; set; }
    }
}
