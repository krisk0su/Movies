namespace MoviesApp.Web.Helpers.Contracts
{
    using ViewModels.Render;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using MoviesApp.ViewModels.Contracts;


    public interface IRenderService
    {
        RenderViewModel GetViewModel(int currentIndex,
            string optionResult,
            ControllerContext controllerContext,
            IEnumerable<IDisplayable> entities);
    }
}
