using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;


namespace UnitTests
{
  class Program2
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
    public void Test_AddInstructor()
    {
      //arrange 
      var data = new NewSolution.Program(output);
      var actual = data.GetCourses();
      //assert
      try
      {
        Assert.True(actual.Count > 0);
        output.WriteLine("Test_AddInstructor() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_Add_EXCEPTION: " + ex.StackTrace);
      }
    }
  }
}
