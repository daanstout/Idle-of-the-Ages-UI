using IdleOfTheAgesLib.Services;
using IdleOfTheAgesLib.UI.Parsing;
using System.Collections.Generic;

namespace IdleOfTheAges.Scripts.UI.Models;

[UIModel]
public class PageListModel {
    private readonly IPageService pageService;

    public PageListModel(IPageService pageService) {
        this.pageService = pageService;
    }

    public IEnumerable<string> GetPageGroups() {
        foreach(var pageGroup in pageService.GetAllPageGroups()) {
            yield return pageGroup.NamespacedID;
        }
    }
}
