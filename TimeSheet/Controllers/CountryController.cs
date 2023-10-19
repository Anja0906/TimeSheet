using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;
using TimeSheet.WebAPI.DTOs;
using TimeSheet.WebAPI.Routes;

namespace TimeSheet.WebAPI.Controllers
{
    [ApiController]
    public class CountryController : BaseAuthorizedController
    {
        private readonly ICountryService _countryService;
        public CountryController(IMapper mapper, ICountryService countryService) : base(mapper)
        {
            _countryService = countryService;
        }
        [HttpGet(CountryRoutes.CountryGetAll)]
        [ProducesResponseType(typeof(List<Country>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var serviceResponse = await _countryService.GetAll();
            var response = _mapper.Map<List<CountryResponseDTO>>(serviceResponse);
            return Ok(response);
        }
        [HttpGet(CountryRoutes.CountryFindByName)]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string name)
        {
            var country = await _countryService.GetByName(name);
            var result = _mapper.Map<CountryResponseDTO>(country);
            return Ok(result);
        }
        [HttpGet(CountryRoutes.CountryFindById)]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await _countryService.GetById(id);
            var result = _mapper.Map<CountryResponseDTO>(country);
            return Ok(result);
        }
        [Authorize(Roles = Constants.Admin)]
        [HttpPost(CountryRoutes.CountryCreate)]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(CountryDTO countryDTO)
        {
            var countryModel = _mapper.Map<Country>(countryDTO);
            var createdModel = await _countryService.AddCountry(countryModel);
            var response = new { Model = _mapper.Map<CountryResponseDTO>(createdModel), Message = "Successfully created country!" };
            return Ok(response);
        }
        [Authorize(Roles = Constants.Admin)]
        [HttpPut(CountryRoutes.CountryUpdate)]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(CountryResponseDTO countryDTO)
        {
            var countryModel = _mapper.Map<Country>(countryDTO);
            var updatedModel = await _countryService.UpdateCountry(countryModel);
            var response = new { Model = _mapper.Map<CountryResponseDTO>(updatedModel), Message = "Successfully created country!" };
            return Ok(response);
        }
        [Authorize(Roles = Constants.Admin)]
        [HttpDelete(CountryRoutes.CountryDelete)]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            _countryService.DeleteCountry(id);
            return Ok();
        }
    }
}
