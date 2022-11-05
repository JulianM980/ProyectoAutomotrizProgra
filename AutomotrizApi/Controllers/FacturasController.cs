using AutomotrizAplicacion.Dominio;
using AutomotrizAplicacion.Fachada;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomotrizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private IDataApi dataApi;
        public FacturasController()
        {
            //inyeccion de dependencias
            dataApi = new DataApiImp();
        }
        [HttpGet("/facturas")]
        public IActionResult GetFacturas() {
            List<Factura> lst = null;
            try
            {
                lst = dataApi.ObtenerFacturas();
                return Ok(lst);
            }
            catch (Exception)
            {

                return StatusCode(500,"Error interrno. Intente Luego");
            }
        }
        [HttpGet("/facturas/{anio}")]
        public IActionResult GetFacturasPorAnio()
        {
            List<Factura> lst = null;
            try
            {
                lst = dataApi.ObtenerFacturas();
                return Ok(lst);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interrno. Intente Luego");
            }
        }
        [HttpGet("/productos/{marca}")]

        public IActionResult GetProductos(string marca) { 
            List<Producto> lst = null;
            try
            {
                lst = dataApi.ObtenerProductos(marca);
                return Ok(lst);

            }
            catch (Exception)
            {

                return StatusCode(500, "Error interrno. Intente Luego");

            }
        }
        [HttpGet("/marcas")]

        public IActionResult GetMarcas()
        {
            List<Marca> lst = null;
            try
            {
                lst = dataApi.ObtenerMarcas();
                return Ok(lst);

            }
            catch (Exception)
            {

                return StatusCode(500, "Error interrno. Intente Luego");

            }
        }
        [HttpPost("/facturas")]
        public IActionResult PostFactura(Factura f) {
            try
            {
                if (f == null)
                {
                    return BadRequest("Datos de presupuesto incorrectos!");
                }

                return Ok(dataApi.GuardarFacturas(f));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
    }
}
