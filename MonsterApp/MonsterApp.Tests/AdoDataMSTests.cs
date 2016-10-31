using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterApp.Tests
{
  [TestClass]
  public class AdoDataMSTests
  {
    private DataAccess.Models.Gender gender;

    [TestInitialize]
    public void Initialize()
    {
      gender = new DataAccess.Models.Gender() { Name = "TestGender" };
    }

    [TestCleanup]
    public void Cleanup() //Destructor? 
    {
      GC.Collect();
    }

    [TestMethod]
    public void Test_InsertGender()
    {
      var data = new AdoData();
      var actual = data.InsertGender(gender);
    }

  }
}
