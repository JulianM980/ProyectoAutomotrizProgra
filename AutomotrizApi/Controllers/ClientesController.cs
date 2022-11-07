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
        [HttpGet("/cliente/{id}")]
        public IActionResult GetCliente(int id)
        {
            Cliente cliente = null;
            try
            {
                cliente = dataClientes.ObtenerUno(id);
                return Ok(cliente);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interrno. Intente Luego");
            }
        }
        [HttpGet("/tiposClientes")]
        public IActionResult GetTiposClientes() {
            List<TipoCliente> lst = null;
            try
            {
                lst = dataClientes.ObtenerTiposClientes();
                return Ok(lst);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interrno. Intente Luego");
            }
        }
        [HttpGet("/tiposDocs")]
        public IActionResult GetTiposDocs()
        {
            List<TipoDoc> lst = null;
            try
            {
                lst = dataClientes.ObtenerTiposDoc();
                return Ok(lst);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interrno. Intente Luego");
            }
        }
        [HttpPost("/clientes")]
        public IActionResult PostClientes(Cliente cliente) {
            try
            {
                if (cliente == null)
                {
                    return BadRequest("Datos de cliente incorrectos");
                }

                return Ok(dataClientes.InsertarCliente(cliente));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id) {
            try
            {
                if (id == 0) return BadRequest("Datos de cliente incorrecto");
                return Ok(dataClientes.BajaLogicaCliente(id));
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno! Intente luego");

            }
        }
        [HttpPut("/clientes/actualizar")]
        public IActionResult PutCliente(Cliente cliente)
        {
            try
            {
                if (cliente == null)
                {
                    return BadRequest("Datos de cliente incorrectos");
                }

                return Ok(dataClientes.ActualizarCliente(cliente));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
    }
}
