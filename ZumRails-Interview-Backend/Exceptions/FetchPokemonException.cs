namespace ZumRails_Interview_Backend.Exceptions
{
    public class FetchPokemonException : Exception
    {
        public FetchPokemonException(int id) : base(string.Format("Failed to fetch pokemon {0}", id))
        {
        }
    }
}
