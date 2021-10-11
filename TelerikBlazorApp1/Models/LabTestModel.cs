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

    public string Classification
    {
      get => Item?.Classification().AsString(string.Empty);
    }

    public DateTime? CreatedOn
    {
      get => Item?.CreatedOn().AsDateTime();
    }

    public bool? DocumentSpecLabCtrl
    {
      get => Item?.Property("document_spec_lab_ctrl").AsBoolean();
    }

    public string Id
    {
      get => Item?.Id();
    }

    public string KeyedName
    {
      get => Item?.KeyedName().AsString(string.Empty);
    }

    public IReadOnlyItem ManagedById
    {
      get => Item?.ManagedById().AsItem();
    }

    public IReadOnlyItem OwnedById
    {
      get => Item?.OwnedById().AsItem();
    }

    public string State
    {
      get => Item?.State().AsString(string.Empty);
    }

    public string TestAcceptanceCriteria
    {
      get => Item?.Property("test_acceptance_criteria").AsString(string.Empty);
    }

    public DateTime? TestActualComplete
    {
      get => Item?.Property("test_actual_complete").AsDateTime();
    }

    public DateTime? TestActualStart
    {
      get => Item?.Property("test_actual_start").AsDateTime();
    }

    public string TestCategory
    {
      get => Item?.Property("test_category").AsString(string.Empty);
    }

    public string TestComments
    {
      get => Item?.Property("test_comments").AsString(string.Empty);
    }

    public string TestDescription
    {
      get => Item?.Property("test_description").AsString(string.Empty);
    }

    public string TestId
    {
      get => Item?.Property("test_id").AsString(string.Empty);
    }

    public string TestLab
    {
      get => Item?.Property("test_lab").AsString(string.Empty);
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
