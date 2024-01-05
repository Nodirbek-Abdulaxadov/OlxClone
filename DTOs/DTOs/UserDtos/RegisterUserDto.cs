using DataAccesLayer.Models;

namespace DTO.DTOs.UserDtos;
public class RegisterUserDto : LoginUserDto
{
    public string FullName { get; set; } = null!;

    public static implicit operator User(RegisterUserDto dto)
    {
        return new User
        {
            UserName = dto.PhoneNumber,
            PhoneNumber = dto.PhoneNumber,
            FullName = dto.FullName,
            PhoneNumberConfirmed = true,
        };
    }
}