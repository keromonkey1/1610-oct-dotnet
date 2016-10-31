using MonsterApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterApp.DataAccess
{
  public partial class AdoData
  {
    public bool UpdateGender(Gender gender)
    {
      //BE careful with updates and deletes because sometimes the values can be lost or switched in translations.
      var query = "update Monster.Gender set GenderName = @name, Active = @active where GenderID = @id";

      var name = new SqlParameter("name", gender.GenderName); //replaces @name with name, etc
      //gender.active needs to be changed from bit to 1 or 0?
      //Turnary operator '?' = if true, then pass '1', else pass '0'. 
      var active = new SqlParameter("active", gender.Active ? 1 : 0); 
      var id = new SqlParameter("id", gender.GenderID);

      //return UpdateData(query, name, active, id);
      //return InsertData(query, name, active, id);
      //or the code below...

      int result;
      using (var connection = new SqlConnection(connectionString))
      {
        var cmd = new SqlCommand(query, connection);
        connection.Open();
        cmd.Parameters.AddRange(new SqlParameter[] { id, name, active });
        result = cmd.ExecuteNonQuery();
      }

      return result > 0; //<-- this is more universal than result==1, which would only return true of result exactly equaled one.
    }


    private bool UpdateData(string query, params SqlParameter[] parameters)
    {
      SqlCommand cmd;
      int result = 0;

      using (var connection = new SqlConnection(connectionString)) //ConfigurationManager.ConnectionStrings["MonsterDB"].ConnectionString
      {
        connection.Open();
        cmd = new SqlCommand(query, connection);  //sets the query

        foreach (var value in parameters) //updates the query
          cmd.Parameters.Add(value);

          try
          { result = cmd.ExecuteNonQuery(); }
          catch (Exception ex)
          {
            Debug.WriteLine("Error: ",ex);
            Console.WriteLine("Error: ", ex);
          }
      }

      Debug.WriteLine("The query is", query);
      Console.WriteLine("The query is", query);
      Debug.WriteLine("The result is: ", result);  
      Console.WriteLine("The result is: ", result);

      return result == 1; //if result is 1, returns true, else false. 
    }
  }
}
