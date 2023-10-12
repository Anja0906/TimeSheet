/// <summary>
/// Represents an exception for not found object in database.
/// </summary>

namespace TimeSheet.Core.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() { }   
        public ResourceNotFoundException(string message) : base(message) { }

    }
}
