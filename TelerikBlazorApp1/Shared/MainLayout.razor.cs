using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;

namespace TelerikBlazorApp1.Shared
{
  public partial class MainLayout
  {
    private DrawerItem selectedItem;

    private bool DrawerExpanded { get; set; }

    IEnumerable<DrawerItem> Data { get; set; } =
        new List<DrawerItem>
        {
          new DrawerItem {Text="Home", Icon="home", Url="MainPage"},
          new DrawerItem {Text = " LIMS", ImageUrl="./images/TestRound32.png", Url="/lims"},
          new DrawerItem {Text = " Proto +", ImageUrl="./images/ProtoOrder32.png", Url="/protoplus",},
          new DrawerItem {Text = " Resources", Icon="grid-layout", Url = "/LabTestResources"},
          new DrawerItem {Text = " Lab Test", ImageUrl="./images/LabTest32.png", Url ="/labtest"}
        };

    TelerikDrawer<DrawerItem> DrawerRef { get; set; }

    private bool IsMenuVisible { get; set; } = false;

    private DrawerItem SelectedItem
    {
      get => selectedItem;
      set
      {
        selectedItem = value;
      }
    }
  }

  /// <summary>
  /// A menu item in the Drawer.
  /// </summary>
  public class DrawerItem
  {
    public string Icon { get; set; }
    public string ImageUrl { get; set; }
    public bool IsSeparator { get; set; }
    public string Text { get; set; }
    public string Url { get; set; }
  }
}
