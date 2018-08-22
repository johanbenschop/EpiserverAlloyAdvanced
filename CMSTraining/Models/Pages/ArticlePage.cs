﻿using AlloyAdvanced.Business.EditorDescriptors;
using EPiServer.Core;
using EPiServer.Shell.ObjectEditing;

namespace AlloyAdvanced.Models.Pages
{
    /// <summary>
    /// Used primarily for publishing news articles on the website
    /// </summary>
    [SiteContentType(
        GroupName = Global.GroupNames.News,
        GUID = "AEECADF2-3E89-4117-ADEB-F8D43565D2F4")]
    [SiteImageUrl(Global.StaticGraphicsFolderPath + "page-type-thumbnail-article.png")]
    public class ArticlePage : StandardPage
    {
        [SelectOne(SelectionFactoryType = typeof(ContactPageSelectionFactory))]
        public virtual PageReference Author { get; set; }
    }
}
