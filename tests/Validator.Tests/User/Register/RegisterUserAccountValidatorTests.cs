using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication.Request;

namespace Validators.Tests.User.Register;

public class RegisterUserAccountValidatorTests
{
    [Fact]
    public void Sucess()
    {
        //AAA
        //Arrange

        var request = new RequestRegisterUserAccountJson
        { 
            Name = "Rafael",
            Email = "rafa@gmail.com",
            Password = "123456789"
        };

        var validator = new RegisterUserAccountValidator();

        //Act

        var result = validator.Validate(request);

        // Assert
        Assert.True(result.IsValid);
    }
}
