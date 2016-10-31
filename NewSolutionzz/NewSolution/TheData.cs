using NewSolution.Models;
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

namespace NewSolution
{
  public class TheData
  {
    //static void Main(string[] args)
    //{

    //}

    private ITestOutputHelper output;
    private string connectionString = ConfigurationManager.ConnectionStrings["testDB"].ConnectionString;

    public TheData(ITestOutputHelper output)
    {
      this.output = output;
    }

    public bool AddInstructor(int id1, int id2)
    {
      try
      {
        output.WriteLine("Program : Start of Try Block");
        string query = "exec AddInstructor " + id1 + "," + id2 + ";";
        output.WriteLine("QUERY: "+query);

        var ds = InsertData(query);
        output.WriteLine("4 --> ds: "+ds);
        return ds;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.Instructor: " + ex);
        return false;
      }
    }

    public bool RemoveInstructor(int id1, int id2) 
    {
      try
      {
        output.WriteLine("Program : Start of Try Block");
        var ds = InsertData("exec RemoveInstructor " + id1 + ", " + id2 + ";");
        return ds;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.Instructor: " + ex);
        return false;
      }
    }


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
          output.WriteLine("Course ------> CourseID: " + courses.Last<Course>().CourseID + ", CourseTitle: " + courses.Last<Course>().CourseTitle + ", Credit: " + courses.Last<Course>().Credit + ", CourseDepartment: " + courses.Last<Course>().CourseDepartment + ", Enrolled: " + courses.Last<Course>().Enrolled + ", Capacity: " + courses.Last<Course>().Capacity + ", TermID: " + courses.Last<Course>().TermID);
        }
        return courses;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetCourses: " + ex);
        return null;
      }
    }


    [Fact]
    public List<Person> GetPersonsIncomplete()
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program.GetPersons() : Start of Try Block");
        var ds = GetDataDisconnected("select * from Person where DateOfCreation is Null;");
        var persons = new List<Person>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          persons.Add(new Person
          {
            PersonID = int.Parse(row[0].ToString()),
            RoleID = int.Parse(row[1].ToString()),
            FirstName = row[2].ToString(),
            MiddleName = row[3].ToString(),
            LastName = row[4].ToString(),
            DateOfCreation = DateTime.Parse(row[5].ToString())
          });
        }
        return persons;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetPersons: " + ex);
        return null;
      }
    }


    [Fact]
    public List<Person> GetPersonsComplete()
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        output.WriteLine("Program.GetCourses() : Start of Try Block");
        var ds = GetDataDisconnected("select * from Person where DateOfCreation is not Null;");
        var persons = new List<Person>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
          persons.Add(new Person
          {
            PersonID = int.Parse(row[0].ToString()),
            RoleID = int.Parse(row[1].ToString()),
            FirstName = row[2].ToString(),
            MiddleName = row[3].ToString(),
            LastName = row[4].ToString(),
            DateOfCreation = DateTime.Parse(row[5].ToString())
          });
        }
        return persons;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.GetPersons-C: " + ex);
        return null;
      }
    }


    public bool SwitchRoles(int id1, int id2)
    {
      try
      {
        output.WriteLine("Program : Start of Try Block");
        var ds = InsertData("exec SwitchRoles " + id1 + ", " + id2 + ";");
        return ds;
      }
      catch (Exception ex)
      {
        output.WriteLine("Exception in Program.Instructor: " + ex);
        return false;
      }
    }


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

    private bool InsertData(string query, params SqlParameter[] parameters) //params is a variable number of arguments I can insert into it.
    {
      SqlCommand cmd;
      int result = 0;

      //This sql connection string is ACTUALLY in MonsterApp.DataAccess.AdoData class.
      //However, because they are both now named the same and are both partial classes, 
      //they can, in effect, see aspects of eachother. 
      //(Recall that classes created using the partial keyword...and w/the same name are merged into one class at runtime). 
      output.WriteLine("1");
      using (var connection = new SqlConnection(connectionString)) //ConfigurationManager.ConnectionStrings["MonsterDB"].ConnectionString
      {
        connection.Open();
        cmd = new SqlCommand(query, connection);  //sets the query
        output.WriteLine("2");
        //foreach (var value in parameters) //updates the query
       //   cmd.Parameters.Add(value);
        output.WriteLine("3");
        try
        { result = cmd.ExecuteNonQuery(); }
        catch (Exception ex) { }
      }
      output.WriteLine("4 --> Result:  "+result);
      return result > 0; //if result is 1, returns true, else false. 
    }

  }
}
