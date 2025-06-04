using Microsoft.AspNetCore.Mvc;
using MiPrimerProyecto.DAL.Entities;
using MiPrimerProyecto.Domain.Interfaces;

namespace MiPrimerProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet, ActionName("GetStateByCountryId/{countryId}")]
        [Route("GetState")]
        public async Task<ActionResult<IEnumerable<State>>> GetStateByCountryIdAsync(Guid countryId)
        {
            var states = await _stateService.GetStateByCountryIdAsync(countryId);

            if (states == null || !states.Any()) return NotFound();

            return Ok(states);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<State>> CreateStateAsync(State state)
        {
            try
            {
                var newState = await _stateService.CreateStateAsync(state);
                if (newState == null) return NotFound();
                return Ok(newState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", state.Name));

                return Conflict(ex.Message);
            }
        }


        [HttpGet, ActionName("GetByName/{name}")]
        [Route("GetByName")]
        public async Task<ActionResult<State>> GetStateByNameAsync(string name)
        {
            var state = await _stateService.GetStateByNameAsync(name);

            if (state == null) return NotFound();

            return Ok(state);
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<State>> EditStateAsync(State state)
        {
            try
            {
                var editeState = await _stateService.EditStateAsync(state);
                if (editeState == null) return NotFound();

                return Ok(editeState);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<State>> DeleteStateAsync(Guid Id)
        {
            if(Id == null) return BadRequest();

            var deleteState = await _stateService.DeleteStateAsync(Id);
            if (deleteState == null) return NotFound();

            return Ok(deleteState);
        }
    }
}
