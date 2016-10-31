using SimplyMain.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace SimplyMain
{
  public class Program //Ado Data //??
  {
    private ITestOutputHelper output; //for outputting

    //The equivalent of ADO data, maybe?
    //But I also want to include Entity-related capacities...
    private string connectionString = ConfigurationManager.ConnectionStrings["SchoolDB"].ConnectionString;
    static void Main(string[] args)
    {

    }

    public Program(ITestOutputHelper output)
    {
      this.output = output;
    }

    #region GetCourses
    [Fact]
    public List<Course> GetCourses()
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program.GetCourses() : Start of Try Block");
        var ds = GetDataDisconnected("select * from Course;");
        var courses = new List<Course>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          courses.Add(new Course
          { 
            CourseID = int.Parse(row[0].ToString()),
            CourseTitle = row[1].ToString(),
            Credit = int.Parse(row[2].ToString()),
            CourseDepartment = row[3].ToString(),
            Enrolled = int.Parse(row[4].ToString()),
            Capacity = int.Parse(row[5].ToString()),
            TermID = int.Parse(row[6].ToString())
          });
          output.WriteLine("Course ------> CourseID: "+ courses.Last<Course>().CourseID + ", CourseTitle: "+courses.Last<Course>().CourseTitle+", Credit: "+ courses.Last<Course>().Credit+", CourseDepartment: "+ courses.Last<Course>().CourseDepartment +", Enrolled: "+ courses.Last<Course>().Enrolled+", Capacity: "+ courses.Last<Course>().Capacity+", TermID: "+ courses.Last<Course>().TermID);
        }
        return courses;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetCourses: "+ ex);
        return null;
      }
    }
    #endregion

    #region GetDayTables
    [Fact]
    public List<DayTable> GetDayTables() //Day tables is a domain table
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program.GetDayTables() : Start of Try Block");
        var ds = GetDataDisconnected("select * from DayTable;");
        var daytables = new List<DayTable>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          daytables.Add(new DayTable
          {
            Day_ = int.Parse(row[0].ToString()),
            NameOfDay = row[1].ToString()
          });
          output.WriteLine("DayTable (Domain Table) ------> Day_: " + +daytables.Last<DayTable>().Day_+", NameOfDay (domain): "+daytables.Last<DayTable>().NameOfDay);
        }
        return daytables;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetDayTables: "+ ex);
        return null;
      }
    }
    #endregion

    #region GetHolds
    [Fact]
    public List<Holding> GetHolds()
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program.GetHolds() : Start of Try Block");
        var ds = GetDataDisconnected("select * from Holding;");
        var holds = new List<Holding>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          holds.Add(new Holding
          {
            PersonID = int.Parse(row[0].ToString()),
            CourseID = int.Parse(row[1].ToString())
          });
          output.WriteLine("Holding --> CourseID: "+holds.Last<Holding>().CourseID + ", PersonID: "+holds.Last<Holding>().PersonID);
        }
        return holds;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetHolds: "+ ex);
        return null;
      }
    }
    #endregion

    #region GetInstructors
    [Fact]
    public List<Instructors> GetInstructors()
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program.GetInstructors() --> Start of Try Block");
        var ds = GetDataDisconnected("select * from Instructors;");
        var instructors = new List<Instructors>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          instructors.Add(new Instructors
          {
            CourseID = int.Parse(row[0].ToString()),
            PersonID = int.Parse(row[1].ToString())
          });
          output.WriteLine("Instructors ---> CourseID: "+ instructors.Last<Instructors>().CourseID+", PersonID (Teacher): "+ instructors.Last<Instructors>().PersonID);
        }
        return instructors;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetInstructors: "+ ex);
        return null;
      }
    }
    #endregion

    #region GetMajors
    [Fact]
    public List<Major> GetMajors()
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program.GetMajors() : Start of Try Block");
        var ds = GetDataDisconnected("select * from Major;");
        var majors = new List<Major>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          majors.Add(new Major
          {
            MajorID = int.Parse(row[0].ToString()),
            MajorTitle = row[1].ToString()
          });
          output.WriteLine("Major --> MajorID: " + majors.Last<Major>().MajorID + ", MajorTitle: " + majors.Last<Major>().MajorTitle);
        }
        return majors;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetMajors: "+ ex);
        return null;
      }
    }
    #endregion

    #region GetMajorJunctions
    [Fact]
    public List<MajorJunction> GetMajorJunctions()
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program.GetMajorJunctions() : Start of Try Block");
        var ds = GetDataDisconnected("select * from MajorJunction;");
        var majorjunctions = new List<MajorJunction>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          majorjunctions.Add(new MajorJunction
          {
            MajorID = int.Parse(row[0].ToString()),
            PersonID = int.Parse(row[1].ToString())
          });
          output.WriteLine("MajorJunction --> MajorID: " + majorjunctions.Last<MajorJunction>().MajorID + ", PersonID: " + majorjunctions.Last<MajorJunction>().PersonID);
        }
        return majorjunctions;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetMajorJunctions: "+ ex);
        return null;
      }
    }
    #endregion

    #region GetPersons
    [Fact]
    public List<Person> GetPersons()
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program.GetPersons() : Start of Try Block");
        var ds = GetDataDisconnected("select * from Person;");
        var persons = new List<Person>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          persons.Add(new Person
          { //parsing the retrieved query into an int, string or bool 
            //if doing ADO, this is needed. 
            //But if doing Entity, it will handle it for you.
            PersonID = int.Parse(row[0].ToString()),
            RoleID = int.Parse(row[1].ToString()),
            FirstName = row[2].ToString(),
            MiddleName = row[3].ToString(),
            LastName = row[4].ToString(),
            DateOfCreation = DateTime.Parse(row[5].ToString())
          });
          output.WriteLine("Persons -----> PersonID: "+ persons.Last<Person>().PersonID+", RoleID: "+ persons.Last<Person>().RoleID+ ", Full Name: "+persons.Last<Person>().FirstName+' '+ persons.Last<Person>().MiddleName+' '+ persons.Last<Person>().LastName+", ---------> DateOfCreation: "+ persons.Last<Person>().DateOfCreation);
        }
        return persons;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetPersons: "+ex);
        return null;
      }
    }
    #endregion

    #region GetRoles
    [Fact]
    public List<Role> GetRoles()
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program.GetRoles() : Start of Try Block");
        var ds = GetDataDisconnected("select * from Role;");
        var roles = new List<Role>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          roles.Add(new Role
          {
            RoleID = int.Parse(row[0].ToString()),
            RoleTitle = row[1].ToString()
          });
          output.WriteLine("Roles ---> RoleID: "+roles.Last<Role>().RoleID+", roleTitle: "+roles.Last<Role>().RoleTitle);
        }
        return roles;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetRoles: "+ ex);
        return null;
      }
    }
    #endregion

    #region GetRooms
    [Fact]
    public List<Rooms> GetRooms()
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program.GetRooms() : Start of Try Block");
        var ds = GetDataDisconnected("select * from Rooms;");
        var rooms = new List<Rooms>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          rooms.Add(new Rooms
          {
            CourseID = int.Parse(row[0].ToString()),
            RoomID = int.Parse(row[1].ToString()),
            RoomLocation = row[2].ToString(),
            BuildingName = row[3].ToString(),
            RoomCap = int.Parse(row[4].ToString())
          });
          output.WriteLine("Rooms ---> CourseID: "+rooms.Last<Rooms>().CourseID+", RoomID: " + rooms.Last<Rooms>().RoomID +", RoomLocation: " + rooms.Last<Rooms>().RoomLocation+", BuildingName: " + rooms.Last<Rooms>().BuildingName+", RoomCap: " + rooms.Last<Rooms>().RoomCap);
        }
        return rooms;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetRooms: "+ ex);
        return null;
      }
    }
    #endregion

    #region GetSchedules
    [Fact]
    public List<Schedule> GetSchedules()
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program.GetSchedules() : Start of Try Block");
        var ds = GetDataDisconnected("select * from Schedule;");
        var schedules = new List<Schedule>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          schedules.Add(new Schedule
          {
            ScheduleID = int.Parse(row[0].ToString()),
            TermID = int.Parse(row[1].ToString()),
            PersonID = int.Parse(row[2].ToString())
          });
          output.WriteLine("Schedules ---> ScheduleID: " + schedules.Last<Schedule>().ScheduleID + ", TermID: " + schedules.Last<Schedule>().TermID+ ", PersonID: "+ schedules.Last<Schedule>().PersonID);
        }
        return schedules;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetSchedules: "+ ex);
        return null;
      }
    }
    #endregion

    #region GetScheduleJunctions
    [Fact]
    public List<ScheduleJunction> GetScheduleJunctions()
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program.GetScheduleJunctions() : Start of Try Block");
        var ds = GetDataDisconnected("select * from ScheduleJunction;");
        var schedulejunctions = new List<ScheduleJunction>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          schedulejunctions.Add(new ScheduleJunction
          {
            ScheduleID = int.Parse(row[0].ToString()),
            CourseID = int.Parse(row[1].ToString())
          });
          output.WriteLine("ScheduleJunctions ---> ScheduleID: " + schedulejunctions.Last<ScheduleJunction>().ScheduleID + ", CourseID: " + schedulejunctions.Last<ScheduleJunction>().CourseID);
        }
        return schedulejunctions;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetScheduleJunctions: "+ ex);
        return null;
      }
    }
    #endregion

    #region GetTerms
    [Fact]
    public List<Term> GetTerms()
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program.GetTerms() : Start of Try Block");
        var ds = GetDataDisconnected("select * from Term;");
        var terms = new List<Term>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          terms.Add(new Term
          {
            TermID = int.Parse(row[0].ToString()),
            TermName = row[1].ToString()
          });
          output.WriteLine("Terms ---> TermID: " + terms.Last<Term>().TermID + ", TermName: " + terms.Last<Term>().TermName);
        }
        return terms;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetTerms: "+ ex);
        return null;
      }
    }
    #endregion

    #region GetTimeBlocks
    [Fact]
    public List<TimeBlock> GetTimeBlocks()
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program.GetTimeBlocks() : Start of Try Block");
        var ds = GetDataDisconnected("select * from TimeBlock;");
        var timeblocks = new List<TimeBlock>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          timeblocks.Add(new TimeBlock
          {
            CourseID = int.Parse(row[0].ToString()),
            Day_ = int.Parse(row[1].ToString()),
            StartTime = int.Parse(row[2].ToString()),
            EndTime = int.Parse(row[3].ToString()),
            TermID = int.Parse(row[4].ToString()),
            RoomID = int.Parse(row[5].ToString()),
          });
          output.WriteLine("TimeBlocks ---> CourseID: " + timeblocks.Last<TimeBlock>().CourseID + ", Day_: " + timeblocks.Last<TimeBlock>().Day_ + ", StartTime: "+ timeblocks.Last<TimeBlock>().StartTime+", EndTime: "+ timeblocks.Last<TimeBlock>().EndTime +", TermID: "+ timeblocks.Last<TimeBlock>().TermID+", RoomID: "+ timeblocks.Last<TimeBlock>().RoomID);
        }
        return timeblocks;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetTimeBlocks: "+ ex);
        return null;
      }
    }
    #endregion


    #region Func : AllCourseInfo()
    [Fact]
    public List<FuncCourseInfo> AllCourseInfo() //gets all the course info currently stored in the db inner joined on other sections with relevant data.
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program : Func : AllCourseInfo() : Start of Try Block");
        var ds = GetDataDisconnected("select * from AllCourseInfo();");

        var allcourseinfo = new List<FuncCourseInfo>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          allcourseinfo.Add(new FuncCourseInfo
          {
            CourseID = int.Parse(row[0].ToString()),
            CourseTitle = row[1].ToString(),
            Credit = int.Parse(row[2].ToString()),
            CourseDepartment = row[3].ToString(),
            Enrolled = int.Parse(row[4].ToString()),
            Capacity = int.Parse(row[5].ToString()),
            TermID = int.Parse(row[6].ToString()),
            TermName = row[7].ToString(),
            Day_ = int.Parse(row[8].ToString()),
            NameOfDay = row[9].ToString(),
            StartTime = int.Parse(row[10].ToString()),
            EndTime = int.Parse(row[11].ToString()),
            RoomID = int.Parse(row[12].ToString()),
            BuildingName = row[13].ToString(),
            RoomLocation = row[14].ToString(),
            RoomCap = int.Parse(row[15].ToString())
          });
          output.WriteLine(""+allcourseinfo.Last<FuncCourseInfo>().CourseTitle);
        }
        return allcourseinfo;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.AllCourseInfo: " + ex);
        return null;
      }
    }
    #endregion

    #region Func : SingleCourseInfo()
    [Fact]
    public List<FuncCourseInfo> SingleCourseInfo(int course) //gets all the course info currently stored in the db inner joined on other sections with relevant data.
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program : Func : SingleCourseInfo() : Start of Try Block");
        var ds = GetDataDisconnected("select * from CourseInfo("+course+");");

        var courseinfo = new List<FuncCourseInfo>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          courseinfo.Add(new FuncCourseInfo
          {
            CourseID = int.Parse(row[0].ToString()),
            CourseTitle = row[1].ToString(),
            Credit = int.Parse(row[2].ToString()),
            CourseDepartment = row[3].ToString(),
            Enrolled = int.Parse(row[4].ToString()),
            Capacity = int.Parse(row[5].ToString()),
            TermID = int.Parse(row[6].ToString()),
            TermName = row[7].ToString(),
            Day_ = int.Parse(row[8].ToString()),
            NameOfDay = row[9].ToString(),
            StartTime = int.Parse(row[10].ToString()),
            EndTime = int.Parse(row[11].ToString()),
            RoomID = int.Parse(row[12].ToString()),
            BuildingName = row[13].ToString(),
            RoomLocation = row[14].ToString(),
            RoomCap = int.Parse(row[15].ToString())
          });
          output.WriteLine("" + courseinfo.Last<FuncCourseInfo>().CourseTitle); 
        }
        return courseinfo;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.AllCourseInfo: " + ex);
        return null;
      }
    }
    #endregion

    #region Func : GetAllEnrolled()
    [Fact]
    public List<FuncGetEnrolledStudent> GetAllEnrolled() //gets all students enrolled in any course. 
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program : Func : GetAllEnrolled() : Start of Try Block");
        var ds = GetDataDisconnected("select * from GetAllEnrolled();");

        var allenrolled = new List<FuncGetEnrolledStudent>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          allenrolled.Add(new FuncGetEnrolledStudent
          {
            CourseTitle = row[0].ToString(),
            CourseID = int.Parse(row[1].ToString()),
            Full_Name = row[2].ToString(),
            PersonID = int.Parse(row[3].ToString()),
            ScheduleID = int.Parse(row[4].ToString()),
            TermName = row[5].ToString()
          });
          output.WriteLine("" + allenrolled.Last<FuncGetEnrolledStudent>().Full_Name);
        }
        return allenrolled;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetAllEnrolled: " + ex);
        return null;
      }
    }
    #endregion

    #region Func : GetEnrolledStudents()
    [Fact]
    public List<FuncGetEnrolledStudent> GetEnrolledStudents(int course) //gets all student enrolled in a SINGLE/GIVEN course. 
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program : Func : GetEnrolledStudents() : Start of Try Block");
        var ds = GetDataDisconnected("select * from GetEnrolledStudents("+course+");");

        var enrolledstudents = new List<FuncGetEnrolledStudent>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          enrolledstudents.Add(new FuncGetEnrolledStudent
          {
            CourseTitle = row[0].ToString(),
            CourseID = int.Parse(row[1].ToString()),
            Full_Name = row[2].ToString(),
            PersonID = int.Parse(row[3].ToString()),
            ScheduleID = int.Parse(row[4].ToString()),
            TermName = row[5].ToString()
          });
          output.WriteLine("" + enrolledstudents.Last<FuncGetEnrolledStudent>().Full_Name);
        }
        return enrolledstudents;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetEnrolledStudents: " + ex);
        return null;
      }
    }
    #endregion

    #region Func : GetAllStudents()
    [Fact]
    public List<FuncGetAllStudents> GetAllStudents() //gets all student enrolled in a SINGLE/GIVEN course. 
    {
      try 
      {
        output.WriteLine("Program : Func : GetAllStudents() : Start of Try Block");
        var ds = GetDataDisconnected("select * from GetAllStudents();");

        var allstudents = new List<FuncGetAllStudents>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          allstudents.Add(new FuncGetAllStudents
          {
            FirstName = row[0].ToString(),
            MiddleName = row[1].ToString(),
            LastName = row[2].ToString(),
            Role_Title = row[3].ToString(),
            Major = row[4].ToString(),
            PersonID = int.Parse(row[5].ToString()),
            DateOfCreation = DateTime.Parse(row[6].ToString())
          });
          output.WriteLine("" + allstudents.Last<FuncGetAllStudents>().DateOfCreation);
        }
        return allstudents;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetAllStudents: " + ex);
        return null;
      }
    }
    #endregion ////gets all student types, from regular students to TAs to Grad Students

    #region Func : GetCourseInstructors()
    [Fact]
    public List<FuncGetCourseInstructors> GetCourseInstructors(int courseID) //gets all instructors for a SINGLE/GIVEN course. 
    {
      try
      {
        output.WriteLine("Program : Func : GetCourseInstructors() : Start of Try Block");
        var ds = GetDataDisconnected("select * from GetInstructors(" + courseID + ");");

        var instructors = new List<FuncGetCourseInstructors>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          instructors.Add(new FuncGetCourseInstructors
          {
            FirstName = row[0].ToString(),
            MiddleName = row[1].ToString(),
            LastName = row[2].ToString(),
            PersonID = int.Parse(row[3].ToString()),
            CourseID = int.Parse(row[4].ToString()),
            CourseTitle = row[5].ToString(),
            Credit = int.Parse(row[6].ToString()),
            CourseDepartment = row[7].ToString(),
            Enrolled = int.Parse(row[8].ToString()),
            Capacity = int.Parse(row[9].ToString()),
            TermID = int.Parse(row[10].ToString())
          });
          output.WriteLine("" + instructors.Last<FuncGetCourseInstructors>().CourseTitle);
        }
        return instructors;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetCourseInstructors: " + ex);
        return null;
      }
    }
    #endregion

    #region Func : GetPersonDetails()
    [Fact]
    public List<FuncGetPersonDetails> GetPersonDetails(int personID) //gets all instructors for a SINGLE/GIVEN course. 
    {
      try
      {
        output.WriteLine("Program : Func : GetPersonDetails() : Start of Try Block");
        var ds = GetDataDisconnected("select * from GetPersonDetails(" + personID + ");");

        var details = new List<FuncGetPersonDetails>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          details.Add(new FuncGetPersonDetails
          {
            Full_Name = row[0].ToString(),
            PersonID = int.Parse(row[1].ToString()),
            RoleID = int.Parse(row[2].ToString()),
            Role = row[3].ToString(),
            Major = row[4].ToString(),
            DateOfCreation = DateTime.Parse(row[5].ToString())
          });
          output.WriteLine("" + details.Last<FuncGetPersonDetails>().PersonID);
        }
        return details;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetPersonDetails: " + ex);
        return null;
      }
    }
    #endregion 

    #region Func : GrabSchedule()
    [Fact]
    public List<FuncGrabSchedule> GrabSchedule(int personID) //gets class schedule for person id (shows more than summon schedule)
    {
      try
      {
        output.WriteLine("Program : Func : GrabSchedule() : Start of Try Block");
        var ds = GetDataDisconnected("select * from GrabSchedule(" + personID + ");");

        var scheddetails = new List<FuncGrabSchedule>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          scheddetails.Add(new FuncGrabSchedule
          {
            Full_Name = row[0].ToString(),
            PersonID = int.Parse(row[1].ToString()),
            RoleID = int.Parse(row[2].ToString()),
            Role = row[3].ToString(),
            CourseTitle = row[4].ToString(),
            CourseID = int.Parse(row[5].ToString()),
            Credit = int.Parse(row[6].ToString()),
            Days = row[7].ToString(),
            Enrolled = int.Parse(row[8].ToString()),
            Capacity = int.Parse(row[9].ToString()),
            RoomCap = int.Parse(row[10].ToString()),
            Dept = row[11].ToString(),
            StartTime = int.Parse(row[12].ToString()),
            EndTime = int.Parse(row[13].ToString()),
            RoomID = int.Parse(row[14].ToString()),
            RoomLocation = row[15].ToString(),
            BuildingName = row[16].ToString(),
            TermName = row[17].ToString()
          });
          output.WriteLine("" + scheddetails.Last<FuncGrabSchedule>().BuildingName);
        }
        return scheddetails;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GrabSchedule: " + ex);
        return null;
      }
    }
    #endregion 

    #region Func : SummonSchedule()
    [Fact]
    public List<FuncSummonSchedule> SummonSchedule(int personID) //gets class schedule for person id : student-side
    {
      try
      {
        output.WriteLine("Program : Func : SummonSchedule() : Start of Try Block");
        var ds = GetDataDisconnected("select * from SummonSchedule(" + personID + ");");

        var summoning = new List<FuncSummonSchedule>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          summoning.Add(new FuncSummonSchedule
          {
            CourseTitle = row[0].ToString(),
            CourseID = int.Parse(row[1].ToString()),
            Days = row[2].ToString(),
            StartTime = int.Parse(row[3].ToString()),
            EndTime = int.Parse(row[4].ToString()),
            Credit = int.Parse(row[5].ToString()),
            Enrolled = int.Parse(row[6].ToString()),
            Capacity = int.Parse(row[7].ToString()),
            BuildingName = row[8].ToString(),
            RoomLocation = row[9].ToString(),
            RoomCap = int.Parse(row[10].ToString()),
            TermName = row[11].ToString(),
            TermID = int.Parse(row[12].ToString()),
            Dept = row[13].ToString()
          });
          output.WriteLine("" + summoning.Last<FuncSummonSchedule>().CourseTitle);
        }
        return summoning;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.SummonSchedule: " + ex);
        return null;
      }
    }
    #endregion

    #region Func : SummonHoldList()
    [Fact]
    public List<FuncSummonHoldList> SummonHoldList(int personID) //gets list of held classes for a student id
    {
      try
      {
        output.WriteLine("Program : Func : SummonHoldList() : Start of Try Block");
        var ds = GetDataDisconnected("select * from SummonHoldList(" + personID + ");");

        var summonedlist = new List<FuncSummonHoldList>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          summonedlist.Add(new FuncSummonHoldList
          {
            Full_Name = row[0].ToString(),
            PersonID = int.Parse(row[1].ToString()),
            CourseID = int.Parse(row[2].ToString()),
            CourseTitle = row[3].ToString(),
            Credit = int.Parse(row[4].ToString()),
            Days = row[5].ToString(),
            StartTime = int.Parse(row[6].ToString()),
            EndTime = int.Parse(row[7].ToString()),
            BuildingName = row[8].ToString(),
            RoomLocation = row[9].ToString(),
            Enrolled = int.Parse(row[10].ToString()),
            Capacity = int.Parse(row[11].ToString()),
            RoomCap = int.Parse(row[12].ToString())
          });
          output.WriteLine("" + summonedlist.Last<FuncSummonHoldList>().BuildingName);
        }
        return summonedlist;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.SummonHoldList: " + ex);
        return null;
      }
    }
    #endregion 



    private DataSet GetDataDisconnected(string query)
    {
      output.WriteLine("Program.GetDataDisconnected : START");
      SqlDataAdapter da;
      DataSet ds;
      SqlCommand cmd;

      using (var connection = new SqlConnection(connectionString)) //var is a polymorphic variable.
      {
        cmd = new SqlCommand(query, connection);
        //output.WriteLine("Program.GetDataDisconnected --> cmd: ", cmd.ToString());
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();

        da.Fill(ds); //<-- This appears to be the point where the connection fails
        
      }
      output.WriteLine("Program.GetDataDisconnected : END");
      return ds;
    }


  }
}
