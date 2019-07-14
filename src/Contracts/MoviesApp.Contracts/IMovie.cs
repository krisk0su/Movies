namespace MoviesApp.Common
{
    public interface IMovie:INameable, 
        IDescription, IPoster, 
        IRating, ITrailer, ILink,IReleaseDate
    {
    }
}
