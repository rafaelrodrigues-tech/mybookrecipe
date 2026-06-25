using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Communication.Request;

namespace MyRecipeBook.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody]RequestRegisterUserAccountJson request)
    {//Registrar a conta de usuario

        return Created();//devolve 201
    }
}

