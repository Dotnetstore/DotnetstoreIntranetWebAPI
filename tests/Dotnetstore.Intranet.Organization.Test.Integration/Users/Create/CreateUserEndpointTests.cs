﻿using System.Net;
using Dotnetstore.Intranet.Organization.Users.Create;
using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using FluentAssertions.Execution;
using SDK.Dto.Organization.Users.Requests;
using SDK.Dto.Organization.Users.Responses;
using Xunit;

namespace Dotnetstore.Intranet.Organization.Test.Integration.Users.Create;

public class CreateUserEndpointTests(DotnetstoreIntranetBase dotnetstoreIntranetBase) : TestBase<DotnetstoreIntranetBase>
{
    [Theory, Priority(1)]
    [InlineData("")]
    public async Task Post_InvalidLastName_ReturnsBadRequest(string lastName)
    {
        // Act
        var (rsp, res) = await dotnetstoreIntranetBase.Client.POSTAsync<CreateUserEndpoint, UserCreateRequest, ErrorResponse>(
            CreateRequest(password: "Test", confirmPassword: "Test", lastName: lastName));
        
        // Assert
        rsp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        res.Errors.Count.Should().Be(1);
        res.Errors.Keys.Should().Equal(nameof(lastName));
    }
    
    [Theory, Priority(2)]
    [InlineData("")]
    public async Task Post_InvalidFirstName_ReturnsBadRequest(string firstName)
    {
        // Act
        var (rsp, res) = await dotnetstoreIntranetBase.Client.POSTAsync<CreateUserEndpoint, UserCreateRequest, ErrorResponse>(
            CreateRequest(password: "Test", confirmPassword: "Test", firstName: firstName));
        
        // Assert
        rsp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        res.Errors.Count.Should().Be(1);
        res.Errors.Keys.Should().Equal(nameof(firstName));
    }
    
    [Theory, Priority(3)]
    [InlineData("")]
    public async Task Post_InvalidUsername_ReturnsBadRequest(string username)
    {
        // Act
        var (rsp, res) = await dotnetstoreIntranetBase.Client.POSTAsync<CreateUserEndpoint, UserCreateRequest, ErrorResponse>(
            CreateRequest(password: "Test", confirmPassword: "Test", username: username));
        
        // Assert
        rsp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        res.Errors.Count.Should().Be(1);
        res.Errors.Keys.Should().Equal(nameof(username));
    }
    
    [Theory, Priority(4)]
    [InlineData("", "")]
    [InlineData("test", "testing")]
    public async Task Post_InvalidPassword_ReturnsBadRequest(string password, string confirmPassword)
    {
        // Act
        var (rsp, res) = await dotnetstoreIntranetBase.Client.POSTAsync<CreateUserEndpoint, UserCreateRequest, ErrorResponse>(
            CreateRequest(password: password, confirmPassword: confirmPassword));
        
        // Assert
        rsp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Theory, Priority(5)]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
    public async Task Post_InvalidMiddleName_ReturnsBadRequest(string middleName)
    {
        // Act
        var (rsp, res) = await dotnetstoreIntranetBase.Client.POSTAsync<CreateUserEndpoint, UserCreateRequest, ErrorResponse>(
            CreateRequest(password: "Test", confirmPassword: "Test", middleName: middleName));
        
        // Assert
        rsp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        res.Errors.Count.Should().Be(1);
        res.Errors.Keys.Should().Equal(nameof(middleName));
    }
    
    [Theory, Priority(6)]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
    public async Task Post_InvalidEnglishName_ReturnsBadRequest(string englishName)
    {
        // Act
        var (rsp, res) = await dotnetstoreIntranetBase.Client.POSTAsync<CreateUserEndpoint, UserCreateRequest, ErrorResponse>(
            CreateRequest(password: "Test", confirmPassword: "Test", englishName: englishName));
        
        // Assert
        rsp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        res.Errors.Count.Should().Be(1);
        res.Errors.Keys.Should().Equal(nameof(englishName));
    }
    
    [Theory, Priority(7)]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
    public async Task Post_InvalidSocialSecurityNumber_ReturnsBadRequest(string socialSecurityNumber)
    {
        // Act
        var (rsp, res) = await dotnetstoreIntranetBase.Client.POSTAsync<CreateUserEndpoint, UserCreateRequest, ErrorResponse>(
            CreateRequest(password: "Test", confirmPassword: "Test", socialSecurityNumber: socialSecurityNumber));
        
        // Assert
        rsp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        res.Errors.Count.Should().Be(1);
        res.Errors.Keys.Should().Equal(nameof(socialSecurityNumber));
    }
    
    [Theory, Priority(8)]
    [InlineData("1700-12-12")]
    [InlineData("2040-12-12")]
    public async Task Post_InvalidDateOfBirth_ReturnsBadRequest(string? dateOfBirth)
    {
        DateTime? dateOfBirthAsDate = null;
        
        if (!string.IsNullOrWhiteSpace(dateOfBirth))
            dateOfBirthAsDate = DateTime.Parse(dateOfBirth);
            
        // Act
        var (rsp, res) = await dotnetstoreIntranetBase.Client.POSTAsync<CreateUserEndpoint, UserCreateRequest, ErrorResponse>(
            CreateRequest(password: "Test", confirmPassword: "Test", dateOfBirth: dateOfBirthAsDate));
        
        // Assert
        rsp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        res.Errors.Count.Should().Be(1);
        res.Errors.Keys.Should().Equal(nameof(dateOfBirth));
    }
    
    [Fact, Priority(9)]
    public async Task Post_ValidRequest_ReturnsOk()
    {
        // Act
        var request = CreateRequest("Test", "Test");
        var (rsp, res) = await dotnetstoreIntranetBase.Client.POSTAsync<CreateUserEndpoint, UserCreateRequest, UserResponse>(
            request);
        
        // Assert
        using (new AssertionScope())
        {
            rsp.StatusCode.Should().Be(HttpStatusCode.OK);
            res.Should().NotBeNull();
            res.Id.Should().NotBeEmpty();
        }
    }
    
    [Fact, Priority(10)]
    public async Task Post_AddingAndExistingUser_ReturnsConflict()
    {
        // Act
        var request = CreateRequest("Test", "Test");
        var (rsp, res) = await dotnetstoreIntranetBase.Client.POSTAsync<CreateUserEndpoint, UserCreateRequest, UserResponse>(
            request);
        
        var (rsp2, res2) = await dotnetstoreIntranetBase.Client.POSTAsync<CreateUserEndpoint, UserCreateRequest, UserResponse>(
            request);
        
        // Assert
        using (new AssertionScope())
        {
            rsp2.StatusCode.Should().Be(HttpStatusCode.Conflict);
        }
    }

    private static UserCreateRequest CreateRequest(
        string password,
        string confirmPassword,
        string lastName = "Testsson",
        string firstName = "Test",
        string middleName = "Testar",
        string englishName = "Testing",
        string socialSecurityNumber = "1234567890",
        DateTime? dateOfBirth = null,
        bool isMale = true,
        bool lastNameFirst = true,
        string username = "test@test.com")
    {
        return new UserCreateRequest(
            lastName,
            firstName,
            middleName,
            englishName,
            socialSecurityNumber,
            dateOfBirth,
            isMale,
            lastNameFirst,
            username,
            password,
            confirmPassword);
    }
}