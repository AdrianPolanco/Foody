using AutoMapper;
using Foody.API.Requests;
using Foody.API.Responses;
using Foody.Core.Application.HATEOAS;
using Foody.Core.Application.Interfaces;
using Foody.Core.Application.Interfaces.HATEOAS;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Enums;
using Foody.Infrastructure.Persistence.Models;
using Foody.Shared.Constants;
using Foody.Shared.Constants.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Foody.API.Controllers
{
    [ApiController]
    [Route("api/accounts")]
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
        private readonly ILinkFactory _linkFactory;

        public AccountController(ILogger<AccountController> logger, IMapper mapper, 
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IJwtGenerator jwtGenerator, ILinkFactory linkFactory)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
            _linkFactory = linkFactory;
        }

        
        [HttpPost(Hateoas.LOGIN, Name = nameof(Login))]
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

        [HttpPost(Hateoas.SIGN_UP_ADMIN, Name = nameof(SignUpAdmin))]
        public async Task<IActionResult> SignUpAdmin([FromBody] SignUpUserRequest request)
        {
           if(!ModelState.IsValid) return BadRequest(ResponseMessages.InvalidRequest);

            ApplicationUser appUser = _mapper.Map<ApplicationUser>(request);

            IdentityResult result = await _userManager.CreateAsync(appUser, request.Password);

            if(!result.Succeeded) return BadRequest(ResponseMessages.InvalidRequest);

            await _userManager.AddToRoleAsync(appUser, "Manager");

            _linkFactory.CreateLink(nameof(SignUpAdmin), Hateoas.SELF, HttpMethod.Post);
            _linkFactory.CreateLink(nameof(SignUpWaiter), Hateoas.SELF, HttpMethod.Post);
            _linkFactory.CreateLink(nameof(Login), Hateoas.SELF, HttpMethod.Post);

            List<Link> links = _linkFactory.GetLinks();

            //SignUpUserResponse response = new(appUser.Id, appUser.Name, appUser.Lastname, appUser.UserName!, appUser.Email!, nameof(ApplicationRoles.Manager), links);
            SignUpUserResponse response = new(appUser.Id, appUser.Name, appUser.Lastname, appUser.UserName!, appUser.Email!, nameof(ApplicationRoles.Manager), links);
            return Ok(response);
        }

        [HttpPost(Hateoas.SIGN_UP_WAITER, Name = nameof(SignUpWaiter))]
        public async Task<IActionResult> SignUpWaiter([FromBody] SignUpUserRequest request)
        {
            if(!ModelState.IsValid) return BadRequest(ResponseMessages.InvalidRequest);

            ApplicationUser appUser = _mapper.Map<ApplicationUser>(request);

            IdentityResult result = await _userManager.CreateAsync(appUser, request.Password);

            if(!result.Succeeded) return BadRequest(ResponseMessages.InvalidRequest);

            await _userManager.AddToRoleAsync(appUser, "Waiter");

            _linkFactory.CreateLink(nameof(SignUpAdmin), Hateoas.SIGN_UP_ADMIN, HttpMethod.Post, Hateoas.SELF);
            _linkFactory.CreateLink(nameof(SignUpWaiter), Hateoas.SIGN_UP_WAITER, HttpMethod.Post, Hateoas.SELF);
            _linkFactory.CreateLink(nameof(Login), Hateoas.LOGIN, HttpMethod.Post, Hateoas.SELF);

            List<Link> links = _linkFactory.GetLinks();

            SignUpUserResponse response = new(appUser.Id, appUser.Name, appUser.Lastname, appUser.UserName!, appUser.Email!, nameof(ApplicationRoles.Waiter), links);

            return Ok(response);
        }

        [Authorize(Policy = "RequireManagerRole")]
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
