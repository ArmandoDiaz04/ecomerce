namespace Ecomerce.Models
{
    public class Categoria
    {
        public int IdCategorias { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
