using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Innovator.Client;
using Microsoft.AspNetCore.Components;
using TelerikBlazorApp1.Services;

namespace TelerikBlazorApp1.Components
{
  public partial class ListComboBox
  {
    private string listId;

    public List<ListModel> ListValues { get; set; } = new List<ListModel>();

    public ListComboBox() : this(null) { }

    public ListComboBox(string listId)
    {
      ListId = listId;
    }

    [Inject]
    public ItemLookupService ItemLookupService { get; set; }

    /// <summary>
    /// The Item ID of the list in Aras to populate the drop down with.
    /// </summary>
    [Parameter]
    public string ListId
    {
      get => listId;
      set
      {
        if (listId != value)
        {
          listId = value;
          GetListValues(ListId);
        }
      }
    }

    /// <summary>
    /// Callback that fires when the Item property is updated.
    /// </summary>
    [Parameter]
    public EventCallback<IReadOnlyItem> OnItemUpdate { get; set; }

    private void GetListValues(string listId)
    {
      if (!string.IsNullOrEmpty(listId))
      {
        List<ListModel> newList = new List<ListModel>();
        var listItems = ItemLookupService.GetItems("Value", "source_id", listId).ToList<IReadOnlyItem>();
        foreach (var item in listItems)
        {
          newList.Add(new ListModel(item));
        }

        ListValues = newList;
      }
    }

    public class ListModel
    {
      public string Label { get; }
      public string Value { get; set; }
      public string FilterValue { get; set; }

      public ListModel(IReadOnlyItem listItem)
      {
        Label = listItem.Property("label").AsString(string.Empty);
        Value = listItem.Property("value").AsString(string.Empty);
      }
    }
  }
}
