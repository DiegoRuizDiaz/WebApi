using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Repository.Models;
using WebApi.Service;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriasService _categoriasService;
        public CategoriasController(CategoriasService categoriasService) 
        {
            _categoriasService = categoriasService;
        }

        [HttpGet]
        public async Task<ActionResult<CategoriasResponse>> GetAll()
        {
            try
            {    
                var categorias = await _categoriasService.GetCategorias();

                if (categorias == null)
                {
                    return BadRequest("No se pudo encontrar el archivo y la data solicitada.");
                }

                return Ok(categorias);                
            }
            catch (JsonReaderException ex)
            {
                return StatusCode(500,$"Error al procesar los datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }       
    }
}
