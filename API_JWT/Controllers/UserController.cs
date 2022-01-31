using API_JWT.Models;
using API_JWT.Models.Request;
using API_JWT.Models.Response;
using API_JWT.Models.Tools;
using API_JWT.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

  
    public class UserController : ControllerBase
    {
        //Inyeccion Dependencia
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Autentification([FromBody] AuthRequest model)
        {
            Response response = new Response();

            var userResponse = _userService.Auth(model);

            if (userResponse == null)
            {
                response.Success = 0;
                response.Message = "Usuario o contraseña inconrecta";
                return BadRequest(response);
            }
            response.Success = 1;
            response.Message = "Usuario Autenticado!";
            response.Data = userResponse;

           return Ok(response);
        }
        [HttpPost]
        public IActionResult CreateUser(User Model)
        {
            Response response = new Response();
            try
            {
                User user = new User();
                using (var db = new PruebaJWTContext())
                {
                    
                    user.Name = Model.Name;
                    user.Email = Model.Email;
                    user.Password = Encrypt.Encryption(Model.Password);
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                response.Success = 1;
                response.Message = "El usuario ha sido creado con exito!";
                response.Data = user;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            Response response = new Response();
            try
            {
                using (var db = new PruebaJWTContext())
                {
                    var customer =db.Users.Find(id);
                    db.Users.Remove(customer);
                    db.SaveChanges();
                }
                response.Success = 1;
                response.Message = "El usuario ha sido borrado con exito!";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Ok(response);

        }
    }
}
