using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Innovator.Client;

namespace TelerikBlazorApp1.Models
{
  /// <summary>
  /// Aras Lab Test item type.
  /// </summary>
  public class LabTestModel
  {
    public LabTestModel(IReadOnlyItem item)
    {
      Item = item;
    }

    public string TestName
    {
      get => Item?.Property("test_name").AsString(string.Empty);
    }

    /// <summary>
    /// The Item from Aras.
    /// </summary>
    public IReadOnlyItem Item { get; set; }
  }
}
