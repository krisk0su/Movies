namespace MoviesApp.Data.Models.Categories
{
    using Contracts;
    using System.Collections.Generic;
    
    public class Category:BaseModel<int>
    {
        public Category()
        {
            this.MoviesCategories = new HashSet<MoviesCategories>();
            
        }
       
        public string Name { get; set; }

        public virtual HashSet<MoviesCategories> MoviesCategories { get; set; }
    }
}

