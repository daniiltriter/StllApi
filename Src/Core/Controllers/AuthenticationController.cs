using Microsoft.AspNetCore.Mvc;
using Stll.Core.Tokens;
using Stll.Shared.Services;
using Stll.Shared.Types;

namespace Stll.Core.Controllers;

[ApiController]
public class AuthenticationController : ControllerBase
{
   private readonly IAuthenticationService _authentication;
   private readonly IJwtTokenBuilder _tokenBuilder;
   
   public AuthenticationController(IAuthenticationService authentication,
      IJwtTokenBuilder tokenBuilder)
   {
      _authentication = authentication;
      _tokenBuilder = tokenBuilder;
   }
   
   [HttpPost("api/oauth2/token")]
   public async Task<ActionResult<JwtGenerationResult>> Token(JwtTokenRequest request)
   {
      var authenticationResponse = await _authentication.AuthenticateAsync(request.Name, request.Password);
      if (!authenticationResponse.Processed)
      {
         return Forbid();
      }
      
      var jwtData = new JwtData
      {
         Subject = authenticationResponse.Identity
      };
      var token = _tokenBuilder.Build(jwtData);
      
      var result = JwtGenerationResult.New(token);
      return Ok(result);
   } 
}