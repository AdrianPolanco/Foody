using AutoMapper;
using Foody.API.Requests;
using Foody.API.Responses;
using Foody.Core.Application.Interfaces;
using Foody.Core.Domain.Entities;
using Foody.Infrastructure.Persistence.Models;
using Foody.Shared.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Foody.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AccountController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;

        public AccountController(ILogger<AccountController> logger, IMapper mapper, 
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IJwtGenerator jwtGenerator)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if(!ModelState.IsValid) return BadRequest(ResponseMessages.InvalidRequest);

            ApplicationUser? appUser = await _userManager.FindByNameAsync(request.Username);

            if(appUser == null) return BadRequest(ResponseMessages.InvalidCredentials);

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(appUser, request.Password, false);

            if(!result.Succeeded) return BadRequest(ResponseMessages.InvalidCredentials);

            User user = _mapper.Map<User>(appUser);

            string token = _jwtGenerator.Generate(user);

            LoginResponse response = new LoginResponse(token);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("forecasts")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
