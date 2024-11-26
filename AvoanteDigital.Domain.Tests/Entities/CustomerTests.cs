using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Service.Validators;

namespace AvoanteDigital.Domain.Tests.Entities;

[TestClass]
public class CustomerTests
{
    // Geral
    [TestMethod]
    public void Should_Create_Customer_With_Valid_Data()
    {
        // Arrange
        var name = "Test";
        var email = "test@example.com";
        var telephoneNumber = "1234567890";

        // Act
        var customer = new Customer
        {
            Name = name,
            Email = email,
            TelephoneNumber = telephoneNumber
        };

        // Assert
        Assert.AreEqual(name, customer.Name);
        Assert.AreEqual(email, customer.Email);
        Assert.AreEqual(telephoneNumber, customer.TelephoneNumber);
        Assert.IsTrue((DateTime.UtcNow - customer.CreatedAt)
            .TotalSeconds < 1, "CreatedAt is not close to UTC Now.");
    }

    // Name
    [TestMethod]
    public void Should_Fail_When_Name_Is_Empty()
    {
        // Arrange
        var customer = new Customer
        {
            Name = "",
            Email = "test@email.com",
            TelephoneNumber = "01234567890",
        };

        var validator = new CustomerValidator();
        
        // Act
        var result = validator.Validate(customer);
        
        // Assert
        Assert.IsFalse(result.IsValid, 
            "Validation should fail when Name is empty.");
        Assert.IsTrue(result.Errors.Any(e => 
                e.PropertyName == "Name" && 
                e.ErrorMessage == "Por favor, insira o nome"),
            "Expected a validation error for the Name property.");
    }

    [TestMethod]
    public void Should_Fail_When_The_Name_Is_Greater_Than_Thousand_Characters()
    {
        // Arrange
        var customer = new Customer
        {
            Name = "Pedro de Alcântara João Carlos Leopoldo Salvador Bibiano Francisco Xavier de Paula Leocádio Miguel Gabriel Rafael Gonzaga",
            Email = "test@email.com",
            TelephoneNumber = "01234567890",
        };

        var validator = new CustomerValidator();
        
        // Act
        var result = validator.Validate(customer);
        
        // Assert
        Assert.IsFalse(result.IsValid, 
            "Validation should fail when Name is greater than 100 characters.");
        Assert.IsTrue(result.Errors.Any(e => 
                e.PropertyName == "Name" && 
                e.ErrorMessage == "O nome não pode ter mais que 100 caracteres"),
            "Expected a validation error for the Name property.");
    }
    
    // Email
    [TestMethod]
    public void Should_Fail_When_Email_Is_Empty()
    {
        // Arrange
        var customer = new Customer
        {
            Name = "test",
            Email = "",
            TelephoneNumber = "01234567890",
        };

        var validator = new CustomerValidator();
        
        // Act
        var result = validator.Validate(customer);
        
        // Assert
        Assert.IsFalse(result.IsValid, 
            "Validation should fail when Email is empty.");
        Assert.IsTrue(result.Errors.Any(e => 
                e.PropertyName == "Email" && 
                e.ErrorMessage == "Por favor, insira o e-mail"),
            "Expected a validation error for the Email property.");
    }

    [TestMethod]
    public void Should_Fail_When_The_Email_Doesnt_Have_At_Sign()
    {
        // Arrange
        var customer = new Customer
        {
            Name = "test",
            Email = "testemail.com",
            TelephoneNumber = "01234567890",
        };

        var validator = new CustomerValidator();
        
        // Act
        var result = validator.Validate(customer);
        
        // Assert
        Assert.IsFalse(result.IsValid, 
            "Validation should fail when Email doesn't have at sign.");
        Assert.IsTrue(result.Errors.Any(e => 
                e.PropertyName == "Email" && 
                e.ErrorMessage == "O e-mail deve conter o caractere '@'"),
            "Expected a validation error for the Email property.");
    }
    
    [TestMethod]
    public void Should_Fail_When_The_Email_Doesnt_Have_Full_Stop()
    {
        // Arrange
        var customer = new Customer
        {
            Name = "test",
            Email = "test@emailcom",
            TelephoneNumber = "01234567890",
        };

        var validator = new CustomerValidator();
        
        // Act
        var result = validator.Validate(customer);
        
        // Assert
        Assert.IsFalse(result.IsValid, 
            "Validation should fail when Email doesn't have full stop.");
        Assert.IsTrue(result.Errors.Any(e => 
                e.PropertyName == "Email" && 
                e.ErrorMessage == "O e-mail deve conter o caractere '.'"),
            "Expected a validation error for the Email property.");
    }
    
    [TestMethod]
    public void Should_Fail_When_The_Email_Is_Greater_Than_Thousand_Characters()
    {
        // Arrange
        var customer = new Customer
        {
            Name = "Test",
            Email = "email_avoante_digital_fortaleza_ceara_teste@gmail.com",
            TelephoneNumber = "01234567890",
        };

        var validator = new CustomerValidator();
        
        // Act
        var result = validator.Validate(customer);
        
        // Assert
        Assert.IsFalse(result.IsValid, 
            "Validation should fail when Email is greater than 100 characters.");
        Assert.IsTrue(result.Errors.Any(e => 
                e.PropertyName == "Email" && 
                e.ErrorMessage == "O e-mail não pode ter mais que 50 caracteres"),
            "Expected a validation error for the Email property.");
    }
    
    // TelephoneNumber
    [TestMethod]
    public void Should_Fail_When_TelephoneNumber_Is_Empty()
    {
        // Arrange
        var customer = new Customer
        {
            Name = "test",
            Email = "test@email.com",
            TelephoneNumber = "",
        };

        var validator = new CustomerValidator();
        
        // Act
        var result = validator.Validate(customer);
        
        // Assert
        Assert.IsFalse(result.IsValid, 
            "Validation should fail when TelephoneNumber is empty.");
        Assert.IsTrue(result.Errors.Any(e => 
                e.PropertyName == "TelephoneNumber" && 
                e.ErrorMessage == "Por favor, insira o telefone"),
            "Expected a validation error for the TelephoneNumber property.");
    }

    [TestMethod]
    public void Should_Fail_When_The_TelephoneNumber_Is_Greater_Than_Eleven()
    {
        // Arrange
        var customer = new Customer
        {
            Name = "Test",
            Email = "test@email.com",
            TelephoneNumber = "012345678910" // Telefone com 12 caracteres
        };
        var validator = new CustomerValidator();

        // Act
        var result = validator.Validate(customer);

        // Assert
        Assert.IsFalse(result.IsValid, 
            "Validation should fail when TelephoneNumber is greater than 11 characters.");
        Assert.IsTrue(result.Errors.Any(e => 
                e.PropertyName == "TelephoneNumber" && 
                e.ErrorMessage == "O número de telefone deve ter exatamente 11 caracteres"),
            "Expected a validation error for the TelephoneNumber property.");
    }

    [TestMethod]
    public void Should_Fail_When_The_TelephoneNumber_Is_Less_Than_Eleven()
    {
        // Arrange
        var customer = new Customer
        {
            Name = "Test",
            Email = "test@email.com",
            TelephoneNumber = "1234567890" // Telefone com 10 caracteres
        };
        var validator = new CustomerValidator();

        // Act
        var result = validator.Validate(customer);

        // Assert
        Assert.IsFalse(result.IsValid, 
            "Validation should fail when TelephoneNumber is less than 11 characters.");
        Assert.IsTrue(result.Errors.Any(e => 
                e.PropertyName == "TelephoneNumber" && 
                e.ErrorMessage == "O número de telefone deve ter exatamente 11 caracteres"),
            "Expected a validation error for the TelephoneNumber property.");
    }

    [TestMethod]
    public void Should_Fail_When_The_TelephoneNumber_Has_Blanks()
    {
        // Arrange
        var customer = new Customer
        {
            Name = "Test",
            Email = "test@email.com",
            TelephoneNumber = "85 9 8888 8888" // Telefone com espaços em branco
        };
        var validator = new CustomerValidator();

        // Act
        var result = validator.Validate(customer);

        // Assert
        Assert.IsFalse(result.IsValid, 
            "Validation should fail when TelephoneNumber has blanks.");
        Assert.IsTrue(result.Errors.Any(e => 
                e.PropertyName == "TelephoneNumber" && 
                e.ErrorMessage == "O telefone não pode conter espaços em branco"),
            "Expected a validation error for the TelephoneNumber property.");
    }
}