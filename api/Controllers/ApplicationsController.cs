using api.Data;
using api.DTOs;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUP user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.UserName))
                return BadRequest("Thông tin người dùng không hợp lệ.");
            var existUser = await _userManager.FindByNameAsync(user.UserName);
            if (existUser == null)
                return NotFound("Người dùng không tồn tại.");

            existUser.Address = user.Address;
            existUser.FullName = user.FullName;
            existUser.PhoneNumber = user.PhoneNumber;
            var saveResult = await _context.SaveChangesAsync();
            return saveResult > 0
                ? Ok("Cập nhật thông tin người dùng thành công.")
                : StatusCode(StatusCodes.Status500InternalServerError, "Cập nhật thất bại.");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePassword)
        {
            var existUser = await _userManager.FindByNameAsync(changePassword.username);
            var isOldPasswordValid = await _userManager.CheckPasswordAsync(existUser, changePassword.currentPassword);
            if (!isOldPasswordValid)
            {
                return StatusCode(StatusCodes.Status409Conflict);
            }
            var result = await _userManager.ChangePasswordAsync(existUser, changePassword.currentPassword, changePassword.newPassword);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Status = "Error", StatusMessage = "failed" });
            }
            return StatusCode(StatusCodes.Status200OK, new { Status = "Sucessed", StatusMessage = "Change Password sucessfully" });
        }
    }
}
