namespace MoviesApp.Data.Models.Actors
{
    using Contracts;
    using System.Collections.Generic;

    public class Actor:BaseModel<int>
    {
        public Actor()
        {
            this.MoviesActors = new HashSet<MoviesActors>();
        }
        public string Name { get; set; }

        public virtual HashSet<MoviesActors> MoviesActors { get; set; }
    }
}
