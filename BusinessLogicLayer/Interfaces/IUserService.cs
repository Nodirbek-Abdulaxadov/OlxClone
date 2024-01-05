using DTO.DTOs.UserDtos;

namespace BusinessLogicLayer.Interfaces;
public interface IUserService
{
    Task RegisterAsync(RegisterUserDto dto);
    Task<LoginResultDto> LoginAsync(LoginUserDto dto);
}