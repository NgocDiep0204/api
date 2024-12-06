namespace api.DTOs;

public class ChangePasswordDTO
{
    public string? username { get; set; }
    public string? currentPassword { get; set; }
    public string? newPassword { get; set; }
}