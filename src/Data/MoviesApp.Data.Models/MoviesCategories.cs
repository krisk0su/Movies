namespace MoviesApp.Data.Models
{
   
    using Contracts;
    using Categories;
    using Movies;
    using System;

    public class MoviesCategories:BaseModel<int>
    {
        
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }

}

