﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RepositoryPatternWithUOW.Core.Consts;
using RepositoryPatternWithUOW.Core.Dtos;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<Customer> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationModel model)
        {
            var user = new Customer
            {
                UserName = model.Email,
                Email = model.Email,
                CustomerName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
                return Ok(new { UserId = user.Id });
            }

            return BadRequest(result.Errors);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("createAdmin")]
        public async Task<IActionResult> CreateAdminUser([FromBody] RegistrationModel model)
        {
            var user = new Customer
            {
                UserName = model.Email,
                Email = model.Email,
                CustomerName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                return Ok(new { UserId = user.Id });
            }

            return BadRequest(result.Errors);
        }

    }

}
