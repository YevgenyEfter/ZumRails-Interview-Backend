namespace ZumRails_Interview_Backend.Exceptions
{
    public class FetchPokemonFailureException : Exception
    {
        public FetchPokemonFailureException(int id) : base(string.Format("Failed to fetch pokemon {0}", id))
        {
        }
    }
}
