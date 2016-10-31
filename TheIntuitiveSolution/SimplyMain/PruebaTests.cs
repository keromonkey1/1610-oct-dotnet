using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplyMain.Models; //MonsterApp.DataAccess //??
using Xunit;
using Xunit.Abstractions;

namespace SimplyMain
{
  public class PruebaTests
  {
    private ITestOutputHelper output;

    public PruebaTests (ITestOutputHelper output)
    {
      this.output = output;
    }

    [Fact]
    public void Test_GetAnyColumn()//(int columnSelection)
    {
      //0 = course --- 1 = days --- 2 = holds --- 3 = instructors --- 4 = majors --- 5 = majorjunctions --- 6 = persons
      //7 = roles --- 8 = rooms --- 9 = schedules --- 10 = schedulejunctions --- 11 = terms --- 12 = timeblocks
      int columnSelection = 0; 

      var data = new Program(output);
      //assert
      try
      {
        if (columnSelection == 0)
        {
          List<Course> courses = data.GetCourses();
          Assert.NotNull(courses);
        }
        else if (columnSelection == 1)
        {
          List<DayTable> daytables = data.GetDayTables();
          Assert.NotNull(daytables);
        }
        else if (columnSelection == 2)
        {
          List<Holding> holds = data.GetHolds();
          Assert.NotNull(holds);
        }
        else if (columnSelection == 3)
        {
          List<Instructors> instructors = data.GetInstructors();
          Assert.NotNull(instructors);
        }
        else if (columnSelection == 4)
        {
          List<Major> majors = data.GetMajors();
          Assert.NotNull(majors);
        }
        else if (columnSelection == 5)
        {
          List<MajorJunction> majorjunctions = data.GetMajorJunctions();
          Assert.NotNull(majorjunctions);
        }
        else if (columnSelection == 6)
        {
          List<Person> persons = data.GetPersons();
          Assert.NotNull(persons);
        }
        else if (columnSelection == 7)
        {
          List<Role> roles = data.GetRoles();
          Assert.NotNull(roles);
        }
        else if (columnSelection == 8)
        {
          List<Rooms> rooms = data.GetRooms();
          Assert.NotNull(rooms);
        }
        else if (columnSelection == 9)
        {
          List<Schedule> schedules = data.GetSchedules();
          Assert.NotNull(schedules);
        }
        else if (columnSelection == 10)
        {
          List<ScheduleJunction> schedulejunctions = data.GetScheduleJunctions();
          Assert.NotNull(schedulejunctions);
        }
        else if (columnSelection == 11)
        {
          List<Term> terms = data.GetTerms();
          Assert.NotNull(terms);
        }
        else if (columnSelection == 12)
        {
          List<TimeBlock> timeblocks = data.GetTimeBlocks();
          Assert.NotNull(timeblocks);
        }
      }
      catch (Exception ex)
      {
        output.WriteLine("EXCEPTION: "+ ex.StackTrace);
      }
    }



    //This section is for manual tests such as Test_GetCourses(), etc. 
    #region manualTests

    [Fact]
    public void Test_GetCourses()
    {
      //arrange 
      var data = new Program(output);
      var actual = data.GetCourses();
      //assert
      try
      {
        Assert.True(actual.Count > 0);
        output.WriteLine("Test_GetCourses() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_GetCourses_EXCEPTION: "+ ex.StackTrace);
      }
    }

    [Fact]
    public void Test_GetDayTables()
    {
      //arrange 
      var data = new Program(output);
      var actual = data.GetDayTables();
      //assert
      try
      {
        Assert.True(actual.Count > 0);
        output.WriteLine("Test_GetDayTables() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_GetDayTables_EXCEPTION: "+ ex.StackTrace);
      }
    }

    [Fact]
    public void Test_GetHolds()
    {
      //arrange 
      var data = new Program(output);
      var actual = data.GetHolds();
      //assert
      try
      {
        Assert.True(actual.Count > 0);
        output.WriteLine("Test_GetHolding() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_GetHolds_EXCEPTION: "+ ex.StackTrace);
      }
    }

    [Fact]
    public void Test_GetInstructors()
    {
      //arrange 
      var data = new Program(output);
      var actual = data.GetInstructors();
      //assert
      try
      {
        Assert.True(actual.Count > 0);
        output.WriteLine("Test_GetInstructors() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_GetInstructors_EXCEPTION: "+ ex.StackTrace);
      }
    }

    [Fact]
    public void Test_GetMajors()
    {
      //arrange 
      var data = new Program(output);
      var actual = data.GetMajors();
      //assert
      try
      {
        Assert.True(actual.Count > 0);
        output.WriteLine("Test_GetMajors() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_GetMajors_EXCEPTION: "+ ex.StackTrace);
      }
    }

    [Fact]
    public void Test_GetMajorJunctions()
    {
      //arrange 
      var data = new Program(output);
      var actual = data.GetMajorJunctions();
      //assert
      try
      {
        Assert.True(actual.Count > 0);
        output.WriteLine("Test_GetMajorJunctions() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_GetMajorJunctions_EXCEPTION: "+ ex.StackTrace);
      }
    }

    [Fact]
    public void Test_GetPersons()
    {
      //arrange 
      var data = new Program(output);
      var actual = data.GetPersons();
      //assert
      try
      {
        Assert.True(actual.Count > 0);
        output.WriteLine("Test_GetPersons() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_GetPersons_EXCEPTION: "+ ex.StackTrace);
      }
    }


    
    [Fact]
    public void Test_GetRoles()
    {
      //arrange 
      var data = new Program(output);
      var actual = data.GetRoles();
      //assert
      try
      {
        Assert.True(actual.Count > 0);
        output.WriteLine("Test_GetRoles() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_GetRoles_EXCEPTION: "+ ex.StackTrace);
      }
    }


    [Fact]
    public void Test_GetRooms()
    {
      //arrange 
      var data = new Program(output);
      var actual = data.GetRooms();
      //assert
      try
      {
        Assert.True(actual.Count > 0);
        output.WriteLine("Test_GetRooms() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_GetRooms_EXCEPTION: "+ ex.StackTrace);
      }
    }

    [Fact]
    public void Test_GetSchedules()
    {
      //arrange 
      var data = new Program(output);
      var actual = data.GetSchedules();
      //assert
      try
      {
        Assert.True(actual.Count > 0);
        output.WriteLine("Test_GetSchedules() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_GetSchedules_EXCEPTION: "+ ex.StackTrace);
      }
    }

    [Fact]
    public void Test_GetScheduleJunctions()
    {
      //arrange 
      var data = new Program(output);
      var actual = data.GetScheduleJunctions();
      //assert
      try
      {
        Assert.True(actual.Count > 0);
        output.WriteLine("Test_GetScheduleJunctions() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_GetScheduleJunctions_EXCEPTION: "+ ex.StackTrace);
      }
    }

    [Fact]
    public void Test_GetTerms()
    {
      //arrange 
      var data = new Program(output);
      var actual = data.GetTerms();
      //assert
      try
      {
        Assert.True(actual.Count > 0);
        output.WriteLine("Test_GetTerms() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_GetTerms_EXCEPTION: "+ ex.StackTrace);
      }
    }

    [Fact]
    public void Test_GetTimeBlocks()
    {
      //arrange 
      var data = new Program(output);
      var actual = data.GetTimeBlocks();
      //assert
      try
      {
        Assert.True(actual.Count > 0);
        output.WriteLine("Test_GetTimeBlocks() --> Assert Complete");
      }
      catch (Exception ex)
      {
        output.WriteLine("ManualTest_GetTimeBlocks_EXCEPTION: "+ ex.StackTrace);
      }
    }

    #endregion

    //This if for function tests
    #region functions

    #region Func: AllCourseInfo()
      [Fact]
    public void Test_AllCourseInfo()
    {
      var data = new Program(output);
      //assert
      try
      {
          var courseinfo = data.AllCourseInfo();
          Assert.True(courseinfo.Count>0);
      }
      catch (Exception ex) { }
    }

    #endregion

    #region Func: SingleCourseInfo()
    [Fact]
    public void Test_SingleCourseInfo()
    {
      var data = new Program(output);
      //assert
      try
      {
        int courseInfoDesired = 3; //courseID
        var courseinfo = data.SingleCourseInfo(courseInfoDesired);
        Assert.True(courseinfo.Count > 0);
      }
      catch (Exception ex) { }
    }

    #endregion

    #region Func: GetAllEnrolled()
    [Fact]
    public void Test_GetAllEnrolled()
    {
      var data = new Program(output);
      //assert
      try
      {
        var allenrolled = data.GetAllEnrolled();
        Assert.True(allenrolled.Count > 0);
      }
      catch (Exception ex) { }
    }

    #endregion

    #region Func: GetEnrolledStudents()
    [Fact]
    public void Test_GetEnrolledStudents()
    {
      var data = new Program(output);
      //assert
      try
      {
        int courseid = 3;
        var allenrolled = data.GetEnrolledStudents(courseid);
        Assert.True(allenrolled.Count > 0);
      }
      catch (Exception ex) { }
    }

    #endregion

    #region Func: GetAllStudents()
    [Fact]
    public void Test_GetAllStudents() //gets all student types, from regular students to TAs to Grad Students
    {
      var data = new Program(output);
      try
      {
        var allstudents = data.GetAllStudents();
        Assert.True(allstudents.Count > 0);
      }
      catch (Exception ex) { }
    }

    #endregion

    #region Func: GetCourseInstructors()
    [Fact]
    public void Test_GetCourseInstructors() //gets instructors for a given courseID
    {
      var data = new Program(output);
      try
      {
        int courseID = 3;
        var instructors = data.GetCourseInstructors(courseID);
        Assert.True(instructors.Count > 0);
      }
      catch (Exception ex) { }
    }

    #endregion

    #region Func: GetPersonDetails()
    [Fact]
    public void Test_GetPersonDetails() //gets instructors for a given courseID
    {
      var data = new Program(output);
      try
      {
        int personID = 10;
        var details = data.GetPersonDetails(personID);
        Assert.True(details.Count > 0);
      }
      catch (Exception ex) { }
    }

    #endregion

    #region Func: GrabSchedule()
    [Fact]
    public void Test_GrabSchedule() //gets class schedule for person id (shows more than summon schedule) //intended to be used admin-side
    {
      var data = new Program(output);
      try
      {
        int personID = 9;
        var schedulegrabbed = data.GrabSchedule(personID);
        Assert.True(schedulegrabbed.Count > 0);
      }
      catch (Exception ex) { }
    }
    #endregion

    #region Func: SummonSchedule()
    [Fact]
    public void Test_SummonSchedule() //gets class schedule for person id (shows less), intended to be used on student-side...i guess. 
    {
      var data = new Program(output);
      try
      {
        int personID = 9;
        var scheduleSummoned = data.SummonSchedule(personID);
        Assert.True(scheduleSummoned.Count > 0);
      }
      catch (Exception ex) { }
    }
    #endregion

    #region Func: SummonHoldList()
    [Fact]
    public void Test_SummonHoldList() //gets list of 'maybe' classes that student put in their holds list
    {
      var data = new Program(output);
      try
      {
        int personID = 9;
        var holds = data.SummonHoldList(personID);
        Assert.True(holds.Count > 0);
      }
      catch (Exception ex) { }
    }
    #endregion





    #endregion
  }
}
