namespace MoviesApp.Common.Series
{
    public interface ISerie: INameable,
        IDescription, IPoster,
        IRating, IReleaseDate
    {
    }
}
