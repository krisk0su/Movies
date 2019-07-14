using System.Linq;

namespace MoviesApp.Web.Helpers.Contracts
{
    using ViewModels.Render;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using MoviesApp.ViewModels.Contracts;

    public class RenderService : IRenderService
    {

        public const int PageSize = 6;

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
