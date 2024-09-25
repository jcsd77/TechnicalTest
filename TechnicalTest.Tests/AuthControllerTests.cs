using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Controllers;
using Xunit;

namespace TechnicalTest.TechnicalTest.Tests
{
    public class AuthControllerTests
    {
        private readonly AuthController _controller;
        private readonly IConfiguration _config;

        public AuthControllerTests()
        {
            var inMemorySettings = new Dictionary<string, string> {
            {"Jwt:Key", "SuperSecretKey123"},
            {"Jwt:Issuer", "MyApi"},
            {"Jwt:Audience", "MyApiUsers"}
        };

            _config = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _controller = new AuthController(_config);
        }

        [Fact]
        public void Login_ShouldReturnToken_WhenCredentialsAreValid()
        {
            var login = new UserLogin { Username = "test", Password = "password" };
            var result = _controller.Login(login);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Login_ShouldReturnNotFound_WhenCredentialsAreInvalid()
        {
            var login = new UserLogin { Username = "invalid", Password = "invalid" };
            var result = _controller.Login(login);

            Assert.IsType<NotFoundObjectResult>(result);
        }
    }

}
