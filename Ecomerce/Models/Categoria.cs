using System.ComponentModel.DataAnnotations;

namespace Ecomerce.Models
{
    public class Categoria
    {
        [Key]
        public int id_categoria { get; set; }
        public string Descripcion { get; set; }
        //0 activo, inactivo 1
        public int Estado { get; set; }
    }
}
