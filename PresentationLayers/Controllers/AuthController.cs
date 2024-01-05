using BusinessLogicLayer.Extended;
using BusinessLogicLayer.Interfaces;
using DTO.DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayers.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController(IUserService userService)
    : ControllerBase
{
    private readonly IUserService userService = userService;

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterUserDto dto)
    {
        try
        {
            await userService.RegisterAsync(dto);
            return Ok();
        }
        catch (CustomException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginUserDto dto)
    {
        try
        {
            var result = await userService.LoginAsync(dto);
            return Ok(result);
        }
        catch (CustomException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}