namespace Ecomerce.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        //0 activo, inactivo 1
        public int Estado { get; set; }
    }
}
