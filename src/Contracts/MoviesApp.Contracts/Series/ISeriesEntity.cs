namespace MoviesApp.Common.Series
{
    public interface ISeriesEntity: INameable, 
        ISeasonEpisode, 
        ITrailer, 
        IPoster,
        ILink
    {
       
    }
}
