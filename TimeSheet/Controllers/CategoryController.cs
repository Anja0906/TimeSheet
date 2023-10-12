using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;
using TimeSheet.Service.Routes;
using TimeSheet.WebAPI.DTOs;

namespace TimeSheet.WebAPI.Controllers
{
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
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
        [HttpPost(CategoryRoutes.CategoryCreate)]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(CategoryDTO categoryDTO)
        {
            var categoryModel = _mapper.Map<Category>(categoryDTO);
            var createdModel = await _categoryService.AddCategory(categoryModel);
            var response = new{ Model = createdModel,  Message = "Successfully created category!" };
            return Ok(response);
        }
        [HttpPut(CategoryRoutes.CategoryUpdate)]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(CategoryResponseDTO categoryDTO)
        {
            var categoryModel = _mapper.Map<Category>(categoryDTO);
            var updatedModel =  await _categoryService.UpdateCategory(categoryModel);
            var response = new { Model = updatedModel, Message = "Successfully created category!" };
            return Ok(response);
        }
        [HttpDelete(CategoryRoutes.CategoryDelete)]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public IActionResult Delete([FromRoute] int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok("Successfully deleted category!");
        }
    }
}
