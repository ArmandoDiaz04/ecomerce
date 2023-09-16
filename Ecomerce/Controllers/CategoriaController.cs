using Ecomerce.BD;
using Ecomerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly comercioDbContext _context;

        public CategoriaController(comercioDbContext context)
        {
            _context = context;
        }

        #region GET_ALL - GET
        [HttpGet]
        [Route("Categoria/GetAll")]
        public ActionResult GetAllCategorias()
        {
            List<Categoria> categorias = _context.categoria.ToList();

            if (categorias.Count == 0)
            {
                return NotFound();
            }

            return Ok(categorias);
        }
        #endregion



        #region GET_BY_ID - GET
        [HttpGet]
        [Route("Categoria/GetById")]
        public ActionResult GetCategoriaById(int id)
        {
            Categoria categoria = _context.categoria.Find(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }
        #endregion

        #region AGREGAR - POST
        [HttpPost]
        [Route("Categoria/Add")]
        public IActionResult AgregarCategoria([FromBody] Categoria categoria)
        {
            try
            {
                _context.categoria.Add(categoria);
                _context.SaveChanges();

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region ACTUALIZAR - PUT
        [HttpPut]
        [Route("Categoria/Actualizar/{id}")]
        public IActionResult ActualizarCategoria(int id, [FromBody] Categoria categoria)
        {
            Categoria categoriaExistente = _context.categoria.Find(id);

            if (categoriaExistente == null)
            {
                return NotFound();
            }

            categoriaExistente.Descripcion = categoria.Descripcion;
            // Otras propiedades que desees actualizar

            _context.Entry(categoriaExistente).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoriaExistente);
        }
        #endregion

        #region ELIMINAR - DELETE 
        [HttpDelete]
        [Route("deleteUsuario/{id}")]
        public void DeleteCategoria(int id)
        {
            var categoria = _context.Set<Categoria>().FirstOrDefault(u => u.id_categoria == id);
            if (categoria != null)
            {
                _context.Set<Categoria>().Remove(categoria);
                _context.SaveChanges();
            }
        }
        #endregion

    }
}
