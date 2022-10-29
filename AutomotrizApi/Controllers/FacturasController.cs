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
        [HttpGet("/productos")]
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
    }
}
