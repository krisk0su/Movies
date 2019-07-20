namespace MoviesApp.Web.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using MoviesApp.ViewModels.Contracts;
    using ViewModels.Render;
    using Contracts;


    public class RenderService : IRenderService
    {

        public const int PageSize = 18;

        public RenderViewModel GetViewModel(int currentIndex,
            string optionResult,
            ControllerContext controllerContext,
            IEnumerable<IDisplayable> entities)
        {
            if (optionResult == null) optionResult = "";

            var controllerName = controllerContext.ActionDescriptor.ControllerName
                .Split("Controller").First();

            var actionName = controllerContext.ActionDescriptor.ActionName;

            return new RenderViewModel(
                currentIndex,
                PageSize,
                controllerName,
                actionName,
                entities,
                optionResult);
        }
    }
}
