using BusinessLogicLayer.Extended;
using BusinessLogicLayer.Interfaces;
using DTO.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationLayers.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService categoryService)
    : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet("getall")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var categories = await _categoryService.GetAll();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented,
                new JsonSerializerSettings() 
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return Ok(json);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("paged")]
    public async Task<IActionResult> Get(int pageSize = 10, int pageNumber = 1)
    {
        try
        {
            var categories = await _categoryService.GetPagedWithTSQL(pageSize, pageNumber);
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var category = await _categoryService.GetById(id);
            return Ok(category);
        }
        catch(ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddCategoryDto dto)
    {
        try
        {
            await _categoryService.Add(dto);
            return Ok();
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.ErrorMessage);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put(UpdateCategoryDto dto)
    {
        try
        {
            await _categoryService.Update(dto);
            return Ok();
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.ErrorMessage);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _categoryService.Delete(id);
            return Ok();
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("filter")]
    public async Task<IActionResult> Filter(string name, bool sorted)
    {
        try
        {
            var categories = await _categoryService.Filter(sorted, (n, sorted) => n.Contains(name) && sorted);
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}