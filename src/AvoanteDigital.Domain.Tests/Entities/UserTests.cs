using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Enums;
using AvoanteDigital.Domain.ValueObjects;

namespace AvoanteDigital.Domain.Tests.Entities;

[TestClass]
public class UserTests
{
    // Geral
    [TestMethod]
    public void Should_Create_User_With_Valid_Data()
    {
        // Arrange
        var firstName = "Romulo";
        var lastName = "de Oliveira";
        var email = "devromulodeoliveira@gmail.com";
        var password = "Linux@123";
        var role = (UserRole)1;

        // Act
        var user = new User
        {
            Firstname = firstName,
            Lastname = lastName,
            Email = email,
            Password = new Password(password),
            Role = role,
        };

        // Assert
        Assert.AreEqual(firstName, user.Firstname);
        Assert.AreEqual(lastName, user.Lastname);
        Assert.AreEqual(email, user.Email);
        Assert.AreEqual(password, user.Password.Literal);
        Assert.AreEqual(role, user.Role);
        Assert.IsTrue((DateTime.UtcNow - user.CreatedAt)
            .TotalSeconds < 1, "CreatedAt is not close to UTC Now.");
    }
}