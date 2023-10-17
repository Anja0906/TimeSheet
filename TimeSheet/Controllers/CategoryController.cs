using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;
using TimeSheet.Service.Routes;
using TimeSheet.Service.Services;
using TimeSheet.WebAPI.DTOs;
using TimeSheet.WebAPI.Routes;

namespace TimeSheet.WebAPI.Controllers
{
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(IMapper mapper, ICategoryService categoryService)
            : base(mapper)
        {
            _categoryService = categoryService;
        }
        [HttpGet(CategoryRoutes.CategoryGetAll)]
        [ProducesResponseType(200, Type = typeof(List<CategoryResponseDTO>))]
        public async Task<IActionResult> GetAll()
        {
            var serviceResponse = await _categoryService.GetAll();
            var response = _mapper.Map<List<CategoryResponseDTO>>(serviceResponse);
            return Ok(response);
        }
        [HttpGet(CategoryRoutes.CategoryFindByName)]
        [ProducesResponseType(typeof(CategoryResponseDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute] string name)
        {
            var category = await _categoryService.GetByName(name);
            var result = _mapper.Map<CategoryResponseDTO>(category);
            return Ok(result);
        }
        [HttpGet(CategoryRoutes.CategoryFindById)]
        [ProducesResponseType(typeof(CategoryResponseDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _categoryService.GetById(id);
            var result = _mapper.Map<CategoryResponseDTO>(category);
            return Ok(result);
        }
        [Authorize(Roles = Constants.Admin)]
        [HttpPost(CategoryRoutes.CategoryCreate)]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(CategoryDTO categoryDTO)
        {
            var categoryModel = _mapper.Map<Category>(categoryDTO);
            var createdModel = await _categoryService.AddCategory(categoryModel);
            var response = new{ Model = _mapper.Map<CategoryResponseDTO>(createdModel),  Message = "Successfully created category!" };
            return Ok(response);
        }
        [Authorize(Roles = Constants.Admin)]
        [HttpPut(CategoryRoutes.CategoryUpdate)]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(CategoryResponseDTO categoryDTO)
        {
            var categoryModel = _mapper.Map<Category>(categoryDTO);
            var updatedModel =  await _categoryService.UpdateCategory(categoryModel);
            var response = new { Model = _mapper.Map<CategoryResponseDTO>(updatedModel), Message = "Successfully created category!" };
            return Ok(response);
        }
        [Authorize(Roles = Constants.Admin)]
        [HttpDelete(CategoryRoutes.CategoryDelete)]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public IActionResult Delete([FromRoute] int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok();
        }
    }
}
