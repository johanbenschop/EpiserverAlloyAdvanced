using System.Collections.Generic;
using System.Web.Mvc;
using AlloyAdvanced.Models.NorthwindEntities;
using AlloyAdvanced.Models.Pages;
using AlloyAdvanced.Models.ViewModels;
using EPiServer.Web.Routing;

namespace AlloyAdvanced.Controllers
{
    public class NorthwindPageController : PageControllerBase<NorthwindPage>
    {
        private readonly UrlResolver resolver;

        public NorthwindPageController(UrlResolver resolver)
        {
            this.resolver = resolver;
        }

        public ActionResult Index(NorthwindPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);

            // connect to the Northwind database through the domain model
            // to fetch a list of all categories and pass it to the Northwind page
            // instance to show a list of category names and links generated
            // by the partial router. 

            var db = new Northwind();

            // we do not need to track changes or 
            // automatically load related entities
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;

            model.CurrentPage.CategoryLinks = new Dictionary<string, string>();

            foreach (var category in db.Categories)
            {
                var name = category.CategoryName;

                var url = resolver.GetVirtualPathForNonContent(
                    partialRoutedObject: category, language: null,
                    virtualPathArguments: null).GetUrl();

                model.CurrentPage.CategoryLinks.Add(name, url);
            }

            return View(model);
        }
    }
}
