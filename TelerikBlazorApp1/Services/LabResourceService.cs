using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TelerikBlazorApp1.Models;
using Innovator.Client;

namespace TelerikBlazorApp1.Services
{
  /// <summary>
  /// Used with the Lab Resource Grid to display the available Resources.
  /// </summary>
  public class LabResourceService
  {
    private NavigationManager navMgr;

    public LabResourceService(ArasConnectionService connectionService, NavigationManager navigationManager)
    {
      Aras = connectionService;
      navMgr = navigationManager;
    }

    /// <summary>
    /// The reference to the Aras DataBase
    /// </summary>
    public ArasConnectionService Aras { get; set; }

    /// <summary>
    /// List of Lab Test Resources.
    /// </summary>
    public ObservableCollection<LabTestResource> LabTestResources { get; } = new ObservableCollection<LabTestResource>();


    public async Task<int> GetLabTestResources()
    {
      if (string.IsNullOrEmpty(Aras.UserId))
      {
        //await Aras.Login("rex.visser", "rrr").ConfigureAwait(false);
        navMgr.NavigateTo("/login");
        return 0;
      }

      var conn = Aras.ArasConnection;
      var factory = conn.AmlContext;

      var resourceItems = factory.Item(factory.Type("Lab Test Resource"), factory.Action("get")).Apply(conn).AssertItems();
      LabTestResources.Clear();
      foreach (var item in resourceItems)
      {
        LabTestResources.Add(new LabTestResource(item));
      }

      return LabTestResources.Count;
    }
  }
}
