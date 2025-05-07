using PromomashTest.Application.Handlers;
using PromomashTest.Application.Interfaces;
using PromomashTest.Application.Queries;
using Xunit;
using Moq;
using PromomashTest.Domain.Entities;

namespace PromomashTest.Application.Tests;

public class RegisterUserCommandHandlerTests
{
    [Fact]
    public async Task Handle_ValidCommand_AddsUser()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        var countryRepositoryMock = new Mock<ICountryRepository>();
        var handler = new RegisterUserCommandHandler(userRepositoryMock.Object, countryRepositoryMock.Object);

        var command = new RegisterUserCommand("test@example.com", "123456", 1, 1);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        userRepositoryMock.Verify(repo => repo.AddUserAsync(
            It.Is<User>(u =>
                u.Email == command.Email &&
                u.CountryId == command.CountryId &&
                u.ProvinceId == command.ProvinceId
            ),
            It.IsAny<CancellationToken>()
        ), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenEmailExists()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        var countryRepositoryMock = new Mock<ICountryRepository>();
        userRepositoryMock
            .Setup(repo => repo.EmailExistsAsync("existing@example.com"))
            .ReturnsAsync(true); 

        var handler = new RegisterUserCommandHandler(userRepositoryMock.Object, countryRepositoryMock.Object);

        var command = new RegisterUserCommand("test@example.com", "123456", 2, 1);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, CancellationToken.None));
        Assert.Equal("Email already exists", ex.Message);
    }
}
