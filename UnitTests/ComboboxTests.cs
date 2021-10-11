using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TelerikBlazorApp1.Components;

namespace UnitTests
{
  public class ComboboxTests
  {
    [Fact]
    public void LoadListTest()
    {
      // Arrange
      const string listId = "9810C04888A54B58AE965AD0F747340E";

      // Act
      var listCB = new ListComboBox(listId);

      // Assert
      Assert.Equal(11, listCB.ListValues.Count);
    }
  }
}
