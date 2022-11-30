using Microsoft.AspNetCore.Mvc;
using sistema_de_gestion.Models;
using sistema_de_gestion.Repository;

namespace sistema_de_gestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : Controller
    {
        private VentaRepository repository = new VentaRepository();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Venta> lista = repository.listarVenta();
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