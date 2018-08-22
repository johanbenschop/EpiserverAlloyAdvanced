using System.Collections.Generic;
using AlloyAdvanced.Models.NorthwindEntities;
using EPiServer.DataAnnotations;

namespace AlloyAdvanced.Models.Pages
{
    [SiteContentType(DisplayName = "NorthwindPage",
        GUID = "ba557e27-433f-4cf8-8eb7-c7b58f761d74",
        Description = "A page that lists categories from the Northwind database.")]
    [SiteImageUrl]
    [AvailableContentTypes(IncludeOn = new[] { typeof(StartPage) })]
    public class NorthwindPage : SitePageData
    {
        // this property is used for showing a list of categories
        // in ~/Views/NorthwindPage/Index.cshtml
        [Ignore] // not stored in CMS database
        public Dictionary<string, string> CategoryLinks { get; set; }

        // this property is used for showing details of a category
        // in ~/Views/Category/Index.cshtml
        [Ignore] // not stored in CMS database
        public Category NorthwindCategory { get; set; }
    }
}