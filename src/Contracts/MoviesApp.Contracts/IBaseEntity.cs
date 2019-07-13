namespace MoviesApp.Common
{
    public interface IBaseEntity:INameable, 
        IDescription, IPoster, 
        IRating, ITrailer, ILink
    {
    }
}
