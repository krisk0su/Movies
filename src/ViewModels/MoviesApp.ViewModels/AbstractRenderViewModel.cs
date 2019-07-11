namespace MoviesApp.ViewModels
{
    using System.Collections.Generic;
    using Contracts;
    using Pager;
    using Render;


    public class AbstractRenderViewModel
    {
        public AbstractRenderViewModel(IEnumerable<IDisplayable> entities,
            RenderViewModel render,
            int totalItems
            )
        {
            this.Entities = entities;
            this.Pager = new PagerViewModel(render, totalItems);
        }
        public IEnumerable<IDisplayable> Entities { get; set; }
        public PagerViewModel Pager { get; set; }
}
}
