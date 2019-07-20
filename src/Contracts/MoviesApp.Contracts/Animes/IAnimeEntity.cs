using MoviesApp.Common.Series;

namespace MoviesApp.Common.Animes
{
    public interface IAnimeEntity: INameable, IPoster,
        ILink, ISeasonEpisode
    {
    }
}
