namespace Ecomerce.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public double TotalPagar { get; set; }
        public DateTime FechaPedido { get; set; }
        public int IdEstadoPedido { get; set; }
        public int IdUsuario { get; set; }
        public string Ubicacion { get; set; }
    }
}
