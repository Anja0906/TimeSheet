namespace TimeSheet.Core.Exceptions
{
    public class CountryNotFoundException : Exception
    {
        public CountryNotFoundException() { }
        public CountryNotFoundException(string message) : base(message) { }    
    }
}
