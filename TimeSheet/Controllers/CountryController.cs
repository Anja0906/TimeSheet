using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;
using TimeSheet.WebAPI.DTOs;

namespace TimeSheet.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICountryService _countryService;

        public CountryController(IMapper mapper, ICountryService countryService)
        {
            _mapper = mapper;
            _countryService = countryService;
        }
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<Country>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                var result = _countryService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }
        [HttpGet("/Country/FindByName")]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        public IActionResult Get(string name)
        {
            try
            {
                var country = _countryService.GetByName(name);
                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }
        [HttpGet("/Country/FindById")]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            try
            {
                var country = _countryService.GetById(id);
                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }
        [HttpPost("/Country/New")]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        public IActionResult Post(CountryDTO countryDTO)
        {
            try
            {
                var countryModel = _mapper.Map<Country>(countryDTO);
                _countryService.AddCountry(countryModel);
                return Ok("Successfully created country!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }
        [HttpPut("/Country/Update")]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        public IActionResult Put(UpdateCountryDTO countryDTO)
        {
            try
            {
                var countryModel = _mapper.Map<Country>(countryDTO);
                _countryService.UpdateCountry(countryModel);
                return Ok("Successfully updated country!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }
        [HttpDelete("/Country/Delete")]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            try
            {
                _countryService.DeleteCountry(id);
                return Ok("Successfully deleted country!");
            }
            catch (NullReferenceException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = "Country with this id does not exist!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }
    }
}
