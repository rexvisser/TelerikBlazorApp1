using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Innovator.Client;

namespace TelerikBlazorApp1.Models
{
  public class LabTestResource
  {
    public LabTestResource(IReadOnlyItem item)
    {
      Item = item;
    }

    /// <summary>
    /// The Aras ID of the resource.
    /// </summary>
    public string Id
    {
      get => Item.Id();
    }

    /// <summary>
    /// The item from Aras.
    /// </summary>
    public IReadOnlyItem Item { get; }

    /// <summary>
    /// The unique name of the resource.
    /// </summary>
    public string Name
    {
      get => Item.Property("resource_name").Value;
    }
    
    /// <summary>
    /// The type of the resource.
    /// </summary>
    public string Type
    {
      get => Item.Property("resource_type").Value;
    }


  }
}
