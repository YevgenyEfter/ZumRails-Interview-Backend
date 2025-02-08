namespace ZumRails_Interview_Backend.Exceptions
{
    public class SortPropertyDoesNotExistException : Exception
    {
        public SortPropertyDoesNotExistException(string propertyName) : base(string.Format("Sorting property {0} does not exist.", propertyName))
        {
        }
    }
}
