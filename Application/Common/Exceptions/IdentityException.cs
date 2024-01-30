using System.Runtime.Serialization;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Common.Exceptions;

[Serializable]
public class IdentityException : Exception
{
    public IEnumerable<IdentityError> Errors { get; }

    public IdentityException(string message,IEnumerable<IdentityError> errors) : base(message)
    {
        Errors = errors;
    }

    public IdentityException(string message) : base(message)
    {
        Errors = new[] { new IdentityError{Description = message} };
    }
}