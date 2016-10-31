using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;


namespace UnitTests
{
  public class Program2
  {
    static void Main(string[] args)
    {

    }

    private ITestOutputHelper output;

    public Program2(ITestOutputHelper output)
    {
      this.output = output;
    }


    [Fact]
    public void Test_AddAnItem()
    {
      //arrange 
      var data = new NewSolution.TheData(output);
      var actual = data.AddInstructor(1,9);
      output.WriteLine("4 -> "+actual );
      //assert
      try
      {
        Assert.True(actual);
        output.WriteLine("Test_AddInstructor() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_Add_EXCEPTION: " + ex.StackTrace);
      }
    }


    [Fact]
    public void Test_DeleteAnItem()
    {
      //arrange 
      var data = new NewSolution.TheData(output);
      var actual = data.RemoveInstructor(1, 9);
      //assert
      try
      {
        Assert.True(actual);
        output.WriteLine("Test_RemoveInstructor() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_Remove_EXCEPTION: " + ex.StackTrace);
      }
    }

    [Fact]
    public void Test_GetAlistofItems()
    {
      //arrange 
      var data = new NewSolution.TheData(output);
      var actual = data.GetCourses();
      //assert
      try
      {
        Assert.True(actual.Count>0);
        output.WriteLine("Test_GetCourses() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_Get_EXCEPTION: " + ex.StackTrace);
      }
    }

    [Fact]
    public void Test_GetAlistofIncompleteItems()
    {
      //arrange 
      var data = new NewSolution.TheData(output);
      var actual = data.GetPersonsIncomplete();
      //assert
      try
      {
        Assert.NotNull(actual);
        output.WriteLine("Test_GetPersonsIncomplete() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_Get_EXCEPTION: " + ex.StackTrace);
      }
    }

    [Fact]
    public void Test_GetAlistofCompleteItems()
    {
      //arrange 
      var data = new NewSolution.TheData(output);
      var actual = data.GetPersonsComplete();
      //assert
      try
      {
        Assert.True(actual.Count > 0);
        output.WriteLine("Test_GetPersonsComplete() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_Get_EXCEPTION: " + ex.StackTrace);
      }
    }

    [Fact]
    public void Test_UpdateAnItem()
    {
      //arrange 
      var data = new NewSolution.TheData(output);
      var actual = data.SwitchRoles(1,5);
      //assert
      try
      {
        Assert.True(actual);
        output.WriteLine("Test_Update --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_Update_EXCEPTION: " + ex.StackTrace);
      }
    }

  }
}
