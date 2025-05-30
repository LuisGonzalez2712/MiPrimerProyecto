using Microsoft.AspNetCore.Mvc;
using MiPrimerProyecto.DAL.Entities;
using MiPrimerProyecto.Domain.Interfaces;

namespace MiPrimerProyecto.Controllers
{
    [Route("api/[controller]")]//nombre inicial de la ruta, url o path
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService) 
        {
            _countryService = countryService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]

        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()
        {
            var countries = await _countryService.GetCountriesAsync();

            if (countries == null || !countries.Any()) return NotFound(); 

            return Ok(countries);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById{id}")]// URL :api/countries/get

        public async Task<ActionResult<Country>> GetCountryByIdAsync(Guid Id)
        { 
            var country = await _countryService.GetCountryByIdAsync(Id);
            if (country == null) return NotFound();// status code 404 - not found

            return Ok(country);//status code 200 - ok

        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Country>> CreateCountryAsync(Country country)
        {
            try
            {
                var newCountry = await _countryService.CreateCountryAsync(country);
                if (newCountry == null) return NotFound();  
                return Ok(newCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", country.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]

        public async Task<ActionResult<Country>> EditCountryAsync(Country country)
        {
            try
            {
                var editeCountry = await _countryService.EditCountryAsync(country);
                if(editeCountry == null) return NotFound();
                return Ok(editeCountry);    
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", country.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]

        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid Id)
        {
                if(Id == null) return BadRequest();

                var deletedCountry = await _countryService.DeleteCountryAsync(Id);
                if (deletedCountry == null) return NotFound(); 
                return Ok(deletedCountry);
        }
    }
}
