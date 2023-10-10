using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;
using TimeSheet.WebAPI.DTOs;

namespace TimeSheet.WebAPI.Controllers
{
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        private const string GET_ALL = "/categories";
        private const string FIND_BY_NAME = "/findCategoryByName/{name}";
        private const string FIND_BY_ID = "/category/{id}";
        private const string CREATE = "/category";
        private const string UPDATE = "/category/update";
        private const string DELETE = "/category/delete/{id}";
        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }
        [HttpGet(GET_ALL)]
        [ProducesResponseType(200, Type = typeof(List<CategoryResponseDTO>))]
        public IActionResult GetAll()
        {
            var serviceResponse = _categoryService.GetAll();
            var response = _mapper.Map<List<CategoryResponseDTO>>(serviceResponse);
            return Ok(response);
        }
        [HttpGet(FIND_BY_NAME)]
        [ProducesResponseType(typeof(CategoryResponseDTO), StatusCodes.Status200OK)]
        public IActionResult Get([FromRoute] string name)
        {
            var category = _categoryService.GetByName(name);
            var result = _mapper.Map<CategoryResponseDTO>(category);
            return Ok(result);
        }
        [HttpGet(FIND_BY_ID)]
        [ProducesResponseType(typeof(CategoryResponseDTO), StatusCodes.Status200OK)]
        public IActionResult GetById([FromRoute] int id)
        {
            var category = _categoryService.GetById(id);
            var result = _mapper.Map<CategoryResponseDTO>(category);
            return Ok(result);
        }
        [HttpPost(CREATE)]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public IActionResult Post(CategoryDTO categoryDTO)
        {
            var categoryModel = _mapper.Map<Category>(categoryDTO);
            _categoryService.AddCategory(categoryModel);
            return Ok("Successfully created category!");
        }
        [HttpPut(UPDATE)]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public IActionResult Put(UpdateCategoryDTO categoryDTO)
        {
            var categoryModel = _mapper.Map<Category>(categoryDTO);
            _categoryService.UpdateCategory(categoryModel);
            return Ok("Successfully updated category!");
        }
        [HttpDelete(DELETE)]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public IActionResult Delete([FromRoute] int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok("Successfully deleted category!");
        }
    }
}
