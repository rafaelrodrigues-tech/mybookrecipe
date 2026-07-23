using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication.Request;

namespace MyRecipeBook.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]//Registrar a conta de usuario
    public async Task<IActionResult> Register([FromBody] RequestRegisterUserAccountJson request, [FromServices] IRegisterUserAccountUseCase useCase)
    {   
        var result = await useCase.Execute(request);

        return Created(string.Empty,result);//devolve 201
    }
}

