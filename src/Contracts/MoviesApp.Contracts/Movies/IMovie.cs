namespace MoviesApp.Common.Movies
{
    public interface IMovie:INameable, 
        IDescription, IPoster, 
        IRating, ITrailer, ILink,IReleaseDate
    {
    }
}
