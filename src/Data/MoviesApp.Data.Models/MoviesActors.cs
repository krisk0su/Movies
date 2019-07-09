namespace MoviesApp.Data.Models
{
    using Actors;
    using Contracts;
    using Movies;
    using System;
    
    public class MoviesActors:BaseModel<int>
    {
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
