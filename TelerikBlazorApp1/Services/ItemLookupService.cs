using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TelerikBlazorApp1.Models;
using Innovator.Client;

namespace TelerikBlazorApp1.Services
{
  public class ItemLookupService
  {
    private NavigationManager navMgr;

    /// <summary>
    /// The reference to the Aras DataBase
    /// </summary>
    public ArasConnectionService Aras { get; set; }

    public ItemLookupService(ArasConnectionService connectionService, NavigationManager navigationManager)
    {
      Aras = connectionService;
      navMgr = navigationManager;
    }

    public IReadOnlyItem GetItem(string itemType, string propertyName, string propertyValue)
    {
      if (string.IsNullOrEmpty(Aras.UserId))
      {
        navMgr.NavigateTo("/login");
        return null;
      }

      var conn = Aras.ArasConnection;
      var factory = conn.AmlContext;
      if (!string.IsNullOrEmpty(itemType) && !string.IsNullOrEmpty(propertyName) && !string.IsNullOrEmpty(propertyValue))
      {
        return factory.Item(factory.Type(itemType), factory.Action("get"), factory.Property(propertyName, propertyValue)).Apply(conn).Items().FirstOrDefault();
      }

      return null;
    }

    public IEnumerable<IReadOnlyItem> GetItems(string itemType, string propertyName, string propertyValue)
    {
      if (string.IsNullOrEmpty(Aras.UserId))
      {
        navMgr.NavigateTo("/");
        return null;
      }

      var conn = Aras.ArasConnection;
      var factory = conn.AmlContext;
      if (!string.IsNullOrEmpty(itemType) && !string.IsNullOrEmpty(propertyName) && !string.IsNullOrEmpty(propertyValue))
      {
        return factory.Item(factory.Type(itemType), factory.Action("get"), factory.Property(propertyName, propertyValue)).Apply(conn).Items();
      }

      return null;
    }
  }
}
