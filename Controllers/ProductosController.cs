using Microsoft.AspNetCore.Mvc;
using sistema_de_gestion.Repository;
using sistema_de_gestion.Models;



namespace sistema_de_gestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        private ProductoRepository repository = new ProductoRepository();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Producto> lista = repository.listarProducto();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}