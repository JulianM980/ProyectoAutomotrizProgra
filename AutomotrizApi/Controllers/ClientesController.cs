using AutomotrizAplicacion.Dominio;
using AutomotrizAplicacion.Fachada;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomotrizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IDataClientes dataClientes;
        public ClientesController()
        {
            dataClientes = new DataClientes();
        }
        [HttpGet("/clientes")]
        public IActionResult GetClientes() {
            List<Cliente> lst = null;
            try
            {
                lst = dataClientes.ObtenerClientes();
                return Ok(lst);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interrno. Intente Luego");
            }
        }
        //[HttpGet("/credenciales/{user}/{pass}")]
        //public IActionResult Credenciales(string user,string pass) {
        //    bool aux = true;
        //    try
        //    {
        //        aux = dataClientes.ComprobarCredenciales(user, pass);
        //        return Ok(aux);
        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(500, "Error en el servidor. Intente luego.");
        //    }
        //}
    }
}
