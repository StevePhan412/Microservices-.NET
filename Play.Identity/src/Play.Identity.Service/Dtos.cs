using System;
using System.ComponentModel.DataAnnotations;

namespace Play.Identity.Service.Dtos
{
    public record UserDto(
        Guid id,
        string Username,
        string Email,
        decimal Gil,
        DateTimeOffset CreatedDate
    );

    public record UpdateUserDto(
        [Required][EmailAddress] string Email,
        [Range(0, 1000000)] decimal Gil
    );
}