using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        new DrawerItem {Text = "LIMS", Icon="plus", Url="/lims"},
        new DrawerItem {Text = "Proto +", Icon="grid-layout", Url="/login"}
        };

    TelerikDrawer<DrawerItem> DrawerRef { get; set; }

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
    public string Text { get; set; }
    public string Icon { get; set; }
    public string Url { get; set; }
    public bool IsSeparator { get; set; }
  }
}
