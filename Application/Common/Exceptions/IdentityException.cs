using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Common.Exceptions;

[Serializable]
public class IdentityException : Exception
{
    public IEnumerable<string> Errors { get; }

    public IdentityException(string message,IEnumerable<IdentityError> errors) : base(message)
    {
        Errors = errors.Select(x => x.Description);
    }

    public IdentityException(string message) : base(message)
    {
        Errors = new[] { message };
    }
}