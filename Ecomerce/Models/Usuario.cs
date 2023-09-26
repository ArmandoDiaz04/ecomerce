using System.ComponentModel.DataAnnotations;

namespace Ecomerce.Models
{
    public class Usuario
    {
        [Key]
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string apellido_usuario { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Password { get; set; }


    }
}
