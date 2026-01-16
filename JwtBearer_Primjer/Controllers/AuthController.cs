using JwtBearer_Primjer.Services.Implementations;
using JwtBearer_Primjer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShop_Shared.Model.Binding.AccountModels;
using WebShop_Shared.Model.Dto;
using WebShop_Shared.Model.ViewModel.AccountModels;

namespace JwtBearer_Primjer.Controllers
{
    [Authorize]
    public class AuthController : ControllerBase
    {

        private IAccountService accountService;

        public AuthController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        /// <summary>
        /// Authenticates a user and generates an access token and a refresh token.
        /// </summary>
        /// <param name="model">The login binding model containing the user's credentials.</param>
        /// <returns>
        /// A Task resulting in a <see cref="TokenViewModel"/> containing the access and refresh tokens for the user. Returns null if authentication fails.
        /// </returns>
        /// <remarks>
        /// This method attempts to authenticate a user using their username and password. If authentication succeeds, it generates a JWT access token and a refresh token for the user. The refresh token is stored in the user's record along with its expiry time, and both tokens are returned in a TokenViewModel. If authentication fails, the method returns null.
        /// </remarks>
        [AllowAnonymous]
        [Route("token")]
        [HttpPost]
        [ProducesResponseType(typeof(TokenViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Token([FromBody] LoginBinding model)
        {

            var token = await accountService.GetToken(model);
            if (token == null)
            {
                return BadRequest(new
                {
                    Msg = "Invalid username or password!",
                });
            }
            return Ok(token);


          
        }

        /// <summary>
        /// Refreshes an expired access token using a refresh token.
        /// </summary>
        /// <param name="model">The token model binding containing the expired access token and refresh token.</param>
        /// <returns>
        /// A Task resulting in a <see cref="TokenViewModel"/> containing the new access token and refresh token.
        /// </returns>
        /// <exception cref="Exception">Thrown when the provided tokens are invalid or the refresh token has expired.</exception>
        /// <remarks>
        /// This method validates the provided refresh token against the stored token and its expiry time for the associated user. If the validation is successful, it generates a new access token and refresh token for the user. The new refresh token replaces the old one in the user's record. The method returns the new tokens in a TokenViewModel. If the tokens are invalid or the refresh token has expired, an exception is thrown.
        /// </remarks>
        [AllowAnonymous]
        [Route("refresh-token")]
        [HttpPost]
        [ProducesResponseType(typeof(TokenViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshToken([FromBody] TokenModelBinding model)
        {
            var token = await accountService.RefreshToken(model);
            return Ok(token);
        }


        [Route("test")]
        [HttpGet]
        public async Task<IActionResult> Test()
        {

            return Ok(new {msg = "Ja sam test!" });
        }

    }
}
