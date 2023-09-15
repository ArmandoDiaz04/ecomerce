namespace Ecomerce.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Domicilio { get; set; }
        public string Contrasenia { get; set; }
        public List<Carrito> Carritos { get; set; }
        public List<Subasta> SubastasPublicadas { get; set; }
        public List<DetalleSubasta> DetallesSubasta { get; set; }
        public List<Venta> VentasPublicadas { get; set; }
        public List<DetalleVenta> DetallesVenta { get; set; }s
    }
}
