namespace MoviesApp.ViewModels.Categories
{
    using System.Collections.Generic;
    using MoviesApp.Data.Models.Categories;


    public class DisplayCategoriesViewModel
    {
        public DisplayCategoriesViewModel()
        {
            this.FirstColumn = FirstColumn;
            this.SecondColumn = SecondColumn;
      
        }

        public IEnumerable<Category> FirstColumn { get; set; }

        public IEnumerable<Category> SecondColumn { get; set; }

    }
}
