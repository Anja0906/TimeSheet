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

        const string getAll = "/categories";
        const string findByName = "/findCategoryByName/{name}";
        const string findById = "/category/{id}";
        const string create = "/category";
        const string update = "/category/update";
        const string delete = "/category/delete/{id}";
        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }
        [HttpGet(getAll)]
        [ProducesResponseType(typeof(Task<List<CategoryResponseDTO>>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                var serviceResponse = _categoryService.GetAll();
                var response = _mapper.Map<List<CategoryResponseDTO>>(serviceResponse);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }
        [HttpGet(findByName)]
        [ProducesResponseType(typeof(CategoryResponseDTO), StatusCodes.Status200OK)]
        public IActionResult Get([FromRoute] string name)
        {
            try
            {
                var category = _categoryService.GetByName(name);
                var result = _mapper.Map<CategoryResponseDTO>(category);
                return Ok(result);
            }
            catch (NullReferenceException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { exception_message = "Category with this id does not exist!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }
        [HttpGet(findById)]
        [ProducesResponseType(typeof(CategoryResponseDTO), StatusCodes.Status200OK)]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var category = _categoryService.GetById(id);
                var result = _mapper.Map<CategoryResponseDTO>(category);
                return Ok(result);
            }
            catch (NullReferenceException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { exception_message = "Category with this id does not exist!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }
        [HttpPost(create)]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public IActionResult Post(CategoryDTO categoryDTO)
        {
            try
            {
                var categoryModel = _mapper.Map<Category>(categoryDTO);
                _categoryService.AddCategory(categoryModel);
                return Ok("Successfully created category!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }
        [HttpPut(update)]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public IActionResult Put(UpdateCategoryDTO categoryDTO)
        {
            try
            {
                var categoryModel = _mapper.Map<Category>(categoryDTO);
                _categoryService.UpdateCategory(categoryModel);
                return Ok("Successfully updated category!");
            }
            catch (NullReferenceException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { exception_message = "Category with this id does not exist!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }
        [HttpDelete(delete)]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _categoryService.DeleteCategory(id);
                return Ok("Successfully deleted category!");
            }
            catch (NullReferenceException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { exception_message = "Category with this id does not exist!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }
    }
}
