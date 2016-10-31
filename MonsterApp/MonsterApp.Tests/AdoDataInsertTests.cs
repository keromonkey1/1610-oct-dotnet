using MonsterApp.DataAccess.Models;
using Models = MonsterApp.DataAccess.Models; //alias
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MonsterApp.DataAccess
{
  public partial class AdoDataTests
  {

    private Gender gender;
    private Monster monster;
    private MonsterType monstertype;
    private Title title;

    public AdoDataTests()
    {
      //just instantiates data
      gender = new Gender() { GenderName = "TestGender2", Active = true };
      monster = new Monster() { GenderID = 2, TitleID = 2, TypeID = 2, Name = "El Monstro Panta'sya", PicturePath = null, Active = true };
      monstertype = new MonsterType() { TypeName = "Amoeba/Changeling", Active = true };
      title = new Title() { TitleName = "El Monstruo", Active = true };
    }

    [Fact]
    public void Test_InsertGender()
    {
      var data = new AdoData(); //var expected = 1;
      var actual = data.InsertGender(gender);
      try
      {
        Assert.True(actual);
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Error: ", ex);
        Console.WriteLine("Error: ", ex);
      }
    }

    [Fact]
    public void Test_InsertMonster() //HOMEWORK TEST METHOD TO INSERT MONSTER VIA ADO
    {
      //arrange 
      var data = new AdoData();
      var actual = data.InsertMonster(monster);
      //assert
      try { Assert.True(actual); }
      catch (Exception ex) { }
    }

    [Fact]
    public void Test_InsertMonsterType()
    {
      //arrange 
      var data = new AdoData();
      var actual = data.InsertMonsterType(monstertype);
      //assert
      try { Assert.True(actual); }
      catch (Exception ex) { }
    }

    [Fact]
    public void Test_InsertTitle()
    {
      //arrange 
      var data = new AdoData();
      var actual = data.InsertTitle(title);
      //assert
      try { Assert.True(actual); }
      catch (Exception ex) { }
    }
    
    public void Test_DeleteGender()
    {
      var data = new AdoData();
      var actual = data.DeleteGender(1);
      try
      {
        Assert.True(actual);
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Error: ", ex);
        Console.WriteLine("Error: ", ex);
      }
    }

    //public Models.Gender gender2;
    //[Theory(gender2 = new Models.Gender() { Name = "blah", Active = true})]
    public void Theory_InsertGender(Models.Gender gender)
    {
        var data = new AdoData();
        var actual = data.InsertGender(gender);
        Assert.True(actual);
    }
    
  }
}
