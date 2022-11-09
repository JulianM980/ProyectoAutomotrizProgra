using AutomotrizAplicacion.Datos;
using AutomotrizAplicacion.Fachada;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomotrizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IDataUser dataUsuarios;
        public UsuariosController(AbstractDaoFactory data)
        {
            dataUsuarios = data.CrearDatosUsuarios();
        }
        [HttpGet("/credenciales/{user}/{pass}")]
        public IActionResult GetCredenciales(string user,string pass) {
            bool aux;
            try
            {
                aux = dataUsuarios.ComprobarCredenciales(user, pass);
                return Ok(aux);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error en el servidor. Intente luego.");
            }
        }
    }
}
