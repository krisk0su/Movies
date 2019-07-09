namespace MoviesApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public abstract class BaseController<VModel, TEntity>:Controller
    where VModel: class
    where TEntity: class
    {
    }
}
