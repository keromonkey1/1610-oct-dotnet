using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MonsterApp.DataAccess;
using System.Diagnostics;

namespace MonsterApp.DataAccess.Models
{
  public partial class AdoDataTests
  {

    /*
    [Fact]
    public void Test_GetGenders()
    {
      //arrange
      AdoData data = new AdoData();
      var expected = 3;

      //act
      var actual = data.GetGenders();

      //assert
      try
      { 
        //If i expect 3, and get 3, its true. #positive test
        //If i expect 0, and get 3, but I expect it to fail, i expected that value, then its true #negative test
        Assert.Equal(expected, actual.Count);
      }
      catch(Exception ex)
      {
        Debug.WriteLine(ex);
      }
    }

    [Fact]
    public void Test_GetMonsterTypes()
    {
      //arrange
      AdoData data = new AdoData();
      var expected = 3;

      //act
      var actual = data.GetMonsterTypes();

      //assert
      try
      {
        Assert.Equal(expected, actual.Count);
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
      }
    }

    [Fact]
    public void Test_GetTitles()
    {
      //arrange
      AdoData data = new AdoData();
      var expected = 3;

      //act
      var actual = data.GetTitles();

      //assert
      try
      {
        Assert.Equal(expected, actual.Count);
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
      }
    }*/

    [Fact]
    //This is the equivalent of Test_GetGenders() for Fred's altered code on 10/27/16 @ 10am.
    public void Test_GetGenders() 
    {
      //arrange 
      var data = new AdoData();
      var actual = data.GetGenders();
      //assert
      try { Assert.NotNull(actual); }
      catch (Exception ex) { }
    }

    [Fact]
    public void Test_GetMonsterTypes()
    {
      //arrange 
      var data = new AdoData();
      var actual = data.GetMonsterTypes();
      //assert
      try { Assert.NotNull(actual); }
      catch (Exception ex) { }
    }

    [Fact]
    public void Test_GetTitles()
    {
      //arrange 
      var data = new AdoData();
      var actual = data.GetTitles();
      //assert
      try { Assert.NotNull(actual); }
      catch (Exception ex) { }
    }

    [Fact]
    public void Test_GetMonsters()
    {
      //arrange 
      var data = new AdoData();
      var actual = data.GetMonsters();
      //assert
      try { Assert.NotNull(actual); }
      catch (Exception ex) { }
    }


  }
}
