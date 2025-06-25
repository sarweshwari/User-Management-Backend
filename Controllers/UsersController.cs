﻿using BackendDotNet.Dto;
using BackendDotNet.Helpers;
using BackendDotNet.Models;
using BackendDotNet.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await usersService.GetAllUsers();
            return Ok(new ApiResponse<IList<User>>
            {
                Status = true,
                Data = users,
                Message = "Users retrieved successfully."
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await usersService.GetUserById(id);
            if (user == null)
                return NotFound(new ApiResponse<User>
                {
                    Status = false,
                    Message = "User not found."
                });

            return Ok(new ApiResponse<User>
            {
                Status = true,
                Data = user,
                Message = "User retrieved successfully."
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto obj)
        {
            var success = await usersService.Register(obj);
            if (!success)
                return BadRequest(new ApiResponse<object>
                {
                    Status = false,
                    Message = "User already exists."
                });

            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "User registered successfully."
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] RegisterDto obj)
        {
            var success = await usersService.Update(id, obj);
            if (!success)
                return BadRequest(new ApiResponse<object>
                {
                    Status = false,
                    Message = "User not found."
                });

            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "User updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await usersService.Delete(id);
            if (!success)
                return NotFound(new ApiResponse<object>
                {
                    Status = false,
                    Message = "User not found."
                });

            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "User deleted successfully."
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto obj)
        {
            var user = await usersService.Login(obj);
            if (user == null)
                return Unauthorized(new ApiResponse<object>
                {
                    Status = false,
                    Message = "Invalid credentials."
                });

            return Ok(new ApiResponse<User>
            {
                Status = true,
                Data = user,
                Message = "Login successful."
            });
        }

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetDto resetDto)
        {
            var res = await usersService.ResetPassword(resetDto);
            if (res)
            {
                return Ok(new ApiResponse<object>
                {
                    Status = true,
                    Message = "password reset successfully"
                });
            }
            return BadRequest(new ApiResponse<object>
            {
                Status = false,
                Message = "Email not found"
            });
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> ModifyUser(int id, [FromBody] RegisterDto obj)
        {
            var success = await usersService.Update(id, obj);
            if (!success)
                return BadRequest(new ApiResponse<object>
                {
                    Status = false,
                    Message = "User not found."
                });

            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "User updated successfully."
            });
        }

        [HttpGet("Profile")]
        public async Task<IActionResult> GetUserProfile(int id)
        {
            var user = await usersService.Getuser(id);

            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            return Ok(new { data = user });
        }

    }
}