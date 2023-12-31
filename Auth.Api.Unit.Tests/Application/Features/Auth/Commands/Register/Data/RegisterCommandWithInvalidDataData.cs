﻿using Auth.API.Application.Exceptions;
using Auth.API.Application.Features.Auth.Commands.Register;
using System.Collections;

namespace Auth.Api.Unit.Tests.Application.Features.Auth.Commands.Register.Data;

public class RegisterCommandWithInvalidDataData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new RegisterCommand("", "", "", "") { },
            new BadRequestException("Some data are not valid")
            {
                Errors = new Dictionary<string, string[]>()
                {
                    { nameof(RegisterCommand.Password), new string[] { "'Password' must not be empty." } },
                    { nameof(RegisterCommand.Email), new string[] { "'Email' must not be empty.", "'Email' is not a valid email address." } },
                    { nameof(RegisterCommand.Name), new string[] { "'Name' must not be empty." } },
                }
            }
        };
        yield return new object[]
        {
            new RegisterCommand("test", "", "", "") { },
            new BadRequestException("Some data are not valid")
            {
                Errors = new Dictionary<string, string[]>()
                {
                    { nameof(RegisterCommand.Password), new string[] { "'Password' must not be empty." } },
                    { nameof(RegisterCommand.Email), new string[] { "'Email' is not a valid email address." } },
                    { nameof(RegisterCommand.Name), new string[] { "'Name' must not be empty." } },
                }
            }
        };
        yield return new object[]
        {
            new RegisterCommand("test@test.com", "", "xtexte", "") { },
            new BadRequestException("Some data are not valid")
            {
                Errors = new Dictionary<string, string[]>()
                {
                    { nameof(RegisterCommand.Password), new string[] { "'Password' must not be empty." } },
                    { nameof(RegisterCommand.PhoneNumber), new string[] { "Phone Number is not a valid phone number" } },
                    { nameof(RegisterCommand.Name), new string[] { "'Name' must not be empty." } },
                }
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
