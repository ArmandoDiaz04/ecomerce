using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Models
{
    public class Producto
    {

        [Key]
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public decimal? Precio { get; set; }
        public decimal? precio_subasta { get; set; }
        public string imagen_url { get; set; }
        public string descripcion { get; set; }
        public int id_categoria { get; set; }
        public int estado { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_final { get; set; }
        public string tipo_producto { get; set; }
        public int id_usuario { get; set; }
        public int? id_usuario_ultima_puja { get; set; }




    }
}
