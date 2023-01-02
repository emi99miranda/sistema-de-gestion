using Microsoft.AspNetCore.Mvc;
using sistema_de_gestion.Repository;
using sistema_de_gestion.Models;

namespace sistema_de_gestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosVendidosController : Controller
    {
        private ProductoVendidoRepository repository = new ProductoVendidoRepository();

        [HttpGet]
        public ActionResult<List<ProductoVendido>> Get()
        {
            try
            {
                List<ProductoVendido> lista = repository.getProductoVendido();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult Post([FromBody] ProductoVendido producto)
        {
            try
            {
                ProductoVendido crearProducto = repository.CrearProductoVendido(producto);
                return StatusCode(StatusCodes.Status201Created, crearProducto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("GetProducto/{id}")]
        public ActionResult<ProductoVendido> GetProducto(int id)
        {
            try
            {
                ProductoVendido? producto = repository.ObtenerProductoVendido(id);
                if (producto != null)
                {
                    return Ok(producto);
                }
                else
                {
                    return NotFound("El producto no fue encontrado");
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
                bool EliminarProducto = repository.EliminarProductoVendido(id);
                if (EliminarProducto)
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
        public ActionResult<ProductoVendido> Put(long id, [FromBody] ProductoVendido productoAActualizar)
        {
            try
            {
                ProductoVendido? productoActualizado = repository.ActualizarProductoVendido(id, productoAActualizar);
                if (productoActualizado != null)
                {
                    return Ok(productoActualizado);
                }
                else
                {
                    return NotFound("El producto no fue encontrado");
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}