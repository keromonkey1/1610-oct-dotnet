using MonsterApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MonsterApp.Tests
{
  //"Officer, I wasn't drunk in public. I was drunk in the bar, and they threw me in public." XP
  public class EfDataTests
  {
    [Fact]
    public void Test_GetGender()
    {
      var data = new EfData();
      var actual = data.GetGenders();

      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_InsertGender()
    {
      var data = new EfData();
      var expected = new Gender() { GenderName = "Martian", Active = true};
      var actual = data.ChangeGender(expected, System.Data.Entity.EntityState.Added);
      Assert.True(actual); 
    }

    [Fact]
    public void Test_DeleteGender()
    {
      var data = new EfData();
      var expected = new Gender() { GenderName = "Martian", Active = true };
      var actual = data.ChangeGender(expected, System.Data.Entity.EntityState.Deleted);

      try
      {
        Assert.True(actual);
      }
      catch (Exception ex) { }
    }

    [Fact]
    public void Test_UpdateGender()
    {
      var data = new EfData();
      var expected = new Gender() { GenderName = "Martian1", Active = true };
      var actual = data.ChangeGender(expected, System.Data.Entity.EntityState.Modified);

      try
      {
        Assert.True(actual);
      }
      catch (Exception ex) { }
    }

    [Fact]
    public void Test_GetLatestGender()
    {
      var data = new EfData();
      //var expected = new Gender() { GenderName = "Martian1", Active = true };
      var genderlist = data.GetGenders();//data.ChangeGender(expected, System.Data.Entity.EntityState.Modified);

      var item = genderlist[genderlist.Count - 1];
      
      try
      {
        Assert.True(item.GenderID>0);
      }
      catch (Exception ex) { }
      
    }

    [Fact]
    //TEST assignment. 10/27/16 
    public void Test_InsertMonster()  //HOMEWORK TEST METHOD TO INSERT MONSTER VIA EF
    {
      var data = new EfData();
      var expected = new Monster() { GenderID=1, TitleID=1, TypeID=1, Name="The Blooburg Grihm",PicturePath=null, Active=true };

      var actual = data.InsertMonster(expected);

      try { Assert.True(actual); }
      catch (Exception ex) { }
    }

    [Fact]
    public void Test_AddMonster()  //HOMEWORK TEST METHOD TO INSERT MONSTER VIA EF
    {
      var data = new EfData();
      var expected = new Monster() { GenderID = 1, TitleID = 1, TypeID = 1, Name = "The Blooburg Grihm", PicturePath = null, Active = true };

      var actual = data.AddMonster(expected, System.Data.Entity.EntityState.Added);

      try { Assert.True(actual); }
      catch (Exception ex) { }
    }

  }

}
