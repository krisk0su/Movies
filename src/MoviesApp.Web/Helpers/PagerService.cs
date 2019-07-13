namespace MoviesApp.Web.Helpers
{
    using Contracts;

    public class PagerService:IPagerService
    {
        public string GetViewName(string actionName)
        {
            if (actionName == "MoviesByCategory") return "Search";
            if (actionName == "Search") return "Search";

            return "Default";
        }
    }
}
