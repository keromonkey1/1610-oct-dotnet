using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace SimplyMainEntity
{
  class EntityTests
  {
    private ITestOutputHelper output;

    public EntityTests(ITestOutputHelper output)
    { this.output = output; }

    [Fact] 
    public void Test_SearchPerson()
    {
      var entity = new EFData();
      var name = "Kay";
      var returned = entity.SearchPersonByName(name);
      output.WriteLine(""+returned);
      Assert.True(returned.Count>0);
    }

    [Fact]
    public void Test_AddPerson()
    {
      var entity = new EFData();
      var newperson = new Person()
      {
        RoleID = 1,
        FirstName = "Kayra",
        MiddleName = "Nomus",
        LastName = "Nomenclature",
        DateOfCreation = DateTime.Now
      };
      var actual = entity.ModifyPerson(newperson, System.Data.Entity.EntityState.Added);
      Assert.True(actual);
    }

    [Fact]
    public void Test_AddNewPerson()
    {
      var entity = new EFData();
      var result = entity.AddNewPerson();
      //var newperson = new Person()
      //{
      //  RoleID = 1,
      //  FirstName = "Kayra",
      //  MiddleName = "Nomus",
      //  LastName = "Nomenclature",
      //  DateOfCreation = DateTime.Now
      //};
      //var actual = entity.ModifyPerson(newperson, System.Data.Entity.EntityState.Added);

      Assert.NotNull(result);
    }

    //public void Test_RemovePerson()
    //{
    //  var entity = new EFData();
    //  var expected = new Gender() { GenderName = "Martian", Active = true };
    //  var actual = entity.ChangeGender(expected, System.Data.Entity.EntityState.Added);
    //  Assert.True(actual);
    //}

    //public void Test_UpdatePerson()
    //{
    //  var entity = new EFData();
    //  var expected = new Gender() { GenderName = "Martian", Active = true };
    //  var actual = entity.ChangeGender(expected, System.Data.Entity.EntityState.Added);
    //  Assert.True(actual);
    //}
  }
}
