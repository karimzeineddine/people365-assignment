using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;

public class AuthControllerTests
{
    private readonly Mock<IConfiguration> _configurationMock;
    private readonly AuthController _authController;

    public AuthControllerTests()
    {
        _configurationMock = new Mock<IConfiguration>();
        _configurationMock.SetupGet(c => c["Jwt:SecretKey"]).Returns("YourVeryLongSecretKeyOfAtLeast32Bytes!");

        _authController = new AuthController(_configurationMock.Object);
    }


// testing login api with invalid credentials
[Fact]
public void Login_InvalidCredentials_ReturnsUnauthorized()
{
    // Arrange
    var login = new UserLogin { Username = "admin", Password = "wrongpassword" }; // Invalid password

    // Act
    var result = _authController.Login(login) as UnauthorizedResult;

    // Assert
    Assert.NotNull(result); // Result should not be null
    Assert.Equal(401, result.StatusCode); // Status code should be 401 (Unauthorized)
}

// testing login api with valid credentials
[Fact]
public void Login_ValidCredentials_ReturnsOk()
{
    // Arrange
    var login = new UserLogin { Username = "admin", Password = "password" }; // Valid credentials

    // Act
    var result = _authController.Login(login) as OkObjectResult;

    // Assert
    Assert.NotNull(result); // Result should not be null
    Assert.Equal(200, result.StatusCode); // Status code should be 200 (OK)
    Assert.NotNull(result.Value); // Token should be returned
}


}
