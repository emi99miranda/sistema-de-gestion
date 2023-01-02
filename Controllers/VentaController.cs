using Microsoft.AspNetCore.Mvc;
using sistema_de_gestion.Models;
using sistema_de_gestion.Repository;

namespace sistema_de_gestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private VentaRepository repository = new VentaRepository();

        [HttpGet]
        public ActionResult<List<Venta>> Get()
        {
            try
            {
                List<Venta> lista = repository.getVenta();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult Post([FromBody] Venta venta)
        {
            try
            {
                Venta crearVenta = repository.CrearVenta(venta);
                return StatusCode(StatusCodes.Status201Created, crearVenta);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("GetVenta/{id}")]
        public ActionResult<Venta> GetVenta(int id)
        {
            try
            {
                Venta? venta = repository.ObtenerVenta(id);
                if (venta != null)
                {
                    return Ok(venta);
                }
                else
                {
                    return NotFound("La venta no fue encontrada");
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public ActionResult Delete([FromBody] int id)
        {
            try
            {
                bool EliminarVenta = repository.EliminarVenta(id);
                if (EliminarVenta)
                {
                    return Ok();
                }
                else { return NotFound(); }

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Venta> Put(long id, [FromBody] Venta ventaAActualizar)
        {
            try
            {
                Venta? ventaActualizada = repository.ActualizarVenta(id, ventaAActualizar);
                if (ventaActualizada != null)
                {
                    return Ok(ventaActualizada);
                }
                else
                {
                    return NotFound("La venta no fue encontrada");
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
