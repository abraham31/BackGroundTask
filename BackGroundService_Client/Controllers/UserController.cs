using BackGroundService_Client.Models;
using BackGroundService_Client.Models.Dto;
using BackGroundService_Client.Services.IServices;
using BackGrundTask_Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BackGroundService_Client.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        public IActionResult SingIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SingIn(LoginRequestDTO modelo)
        {

            var response = await _userService.Login<APIResponse>(modelo);
            if (response != null && response.IsExitoso == true)
            {
                LoginResponseDTO loginResponse = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(response.Resultado));

                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(loginResponse.Token);


                //Claims
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, jwt.Claims.FirstOrDefault(c => c.Type == "unique_name").Value));
                identity.AddClaim(new Claim(ClaimTypes.Role, jwt.Claims.FirstOrDefault(c => c.Type == "role").Value));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Session
                HttpContext.Session.SetString(DS.SessionToken, loginResponse.Token);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                return View(modelo);
            }

        }

        public IActionResult SingUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SingUp(RegistroRequestDTO modelo)
        {
            var response = await _userService.SingUp<APIResponse>(modelo);
            if (response != null && response.IsExitoso)
            {
                return RedirectToAction("SingIn");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString(DS.SessionToken, "");

            return RedirectToAction("Index", "Home");
        }


        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}