using System.Threading.Tasks;
using Explorer.Domain;
using Explorer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LocationController : ControllerBase
    {
        public readonly IExplorerRepository _repo;

        public LocationController(IExplorerRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("listAllLocations")]
        public async Task<IActionResult> ListAllLocations()
        {
            try
            {
                var locations = await _repo.GetAllLocationsAsync();

                if (locations == null) return NotFound("Não existem localizacoes cadastradas");

                return Ok(locations);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao listar as localizacoes");
            }
        }

        [HttpGet("GetLocationById/{id}")]
        public async Task<IActionResult> GetLocationById(int locationId)
        {
            try
            {
                var location = await _repo.GetLocationById(locationId);

                if (location == null) return NotFound("Localizacao nao encontrada");

                return Ok(location);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao encontrar localizacao");
            }
        }

        [HttpPut("EditLocation/{id}")]
        public async Task<IActionResult> EditLocation(Location location, int locationId)
        {
            try
            {
                var locationDb = _repo.GetLocationById(locationId);

                if (locationDb == null) return NotFound("Localizacao nao encontrada");

                _repo.Update(location);

                if (!await _repo.SaveChangesAsync()) throw new System.Exception();

                return Created($"/api/location/{location.Id}", location);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar localizacao");
            }
        }

        [HttpPost("AddLocation")]
        public async Task<IActionResult> AddLocation(Location location)
        {
            try
            {
                if (location.Name == string.Empty) return BadRequest();

                if (location.Description == string.Empty) return BadRequest();

                _repo.Add(location);

                if (!await _repo.SaveChangesAsync()) throw new System.Exception();

                return Created($"/api/location/{location.Id}", location);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao editar localizacao");
            }
        }

        [HttpPost("DeleteLocation/{id}")]
        public async Task<IActionResult> DeleteLocation(int locationId)
        {
            try
            {
                var location = await _repo.GetLocationById(locationId);

                if (location == null) return NotFound("Localizacao nao encontrada");

                _repo.Delete(location);

                if (!await _repo.SaveChangesAsync()) throw new System.Exception();

                return Ok("Localizacao deletada");

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar localizacao");
            }
        }

    }
}