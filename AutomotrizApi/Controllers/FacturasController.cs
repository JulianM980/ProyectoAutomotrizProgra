using AutomotrizAplicacion.Datos;
using AutomotrizAplicacion.Dominio;
using AutomotrizAplicacion.Fachada;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AutomotrizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private IDataApi dataApi;
        public FacturasController(AbstractDaoFactory data)
        {
            //inyeccion de dependencias
            dataApi = data.CrearDatosFactura();
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

                return StatusCode(500, "Error interrno. Intente Luego");
            }
        }
        [HttpGet("/facturas/{anio}")]
        public IActionResult GetFacturasPorAnio(int anio)
        {
            List<Factura> lst = null;
            try
            {
                lst = dataApi.ObtenerAlgunas(anio);
                return Ok(lst);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interrno. Intente Luego");
            }
        }
        [HttpGet("/factura/{id}")]
        public IActionResult GetFactura(int id)
        {
            Factura factura = null; 
            try
            {
                factura = dataApi.ObtenerUna(id);
                return Ok(factura);
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
        [HttpGet("/vendedores")]
        public IActionResult GetVendedores() {
            List<Vendedor> lst = null;
            try
            {
                lst = dataApi.ObtenerVendedores();
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
                    return BadRequest("Los datos de la factura son incorrectos");
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
