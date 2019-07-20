namespace MoviesApp.Common.Animes
{
    public interface IAnime: INameable,
        IDescription, IPoster,
        IRating, IReleaseDate
    {
    }
}
