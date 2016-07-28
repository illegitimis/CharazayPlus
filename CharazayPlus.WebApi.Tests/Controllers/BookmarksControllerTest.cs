
namespace CharazayPlus.WebApi.Tests.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using CharazayPlus.WebApi.Controllers;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
   
  [TestClass]
  public class BookmarksControllerTest
  {
    [TestMethod]
    public void Delete()
    {
      // Arrange
      BookmarksController controller = new BookmarksController();

      // Act
      controller.Delete(0);

      // Assert
    }
  }
}
