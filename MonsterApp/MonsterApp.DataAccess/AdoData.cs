using MonsterApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterApp.DataAccess 
{
  //this is a library. It needs to be used by something else. It CANNOT be executed/run by itself.
  public class AdoData
  {                                   //@"data source=kerosql.cibv2cszqcim.us-west-2.rds.amazonaws.com";
                                      //@"data source=sqltraining.c8xdjhpxfhp5.us-east-1.rds.amazonaws.com; initial catalog=AdventureWorks2014; user id=sqlnew; password=123456;"; 
    private string connectionString = ConfigurationManager.ConnectionStrings["MonsterDB"].ConnectionString;

    #region Methods

    #region GetGender
    public List<Gender> GetGenders() 
    {
      try //In case the dataset is closed, this helps us avoid program crashing. 
      {
        var ds = GetDataDisconnected("select * from Monster.Gender;");
        var genders = new List<Gender>();
        foreach(DataRow row in ds.Tables[0].Rows)
        {
          genders.Add(new Gender
          { //parsing the retrieved query into an int, string or bool 
            //if doing ADO, this is needed. 
            //But if doing Entity, it will handle it for you.
             GenderID = int.Parse(row[0].ToString()),
             Name = row[1].ToString(),
             Active = bool.Parse(row[2].ToString())
          });
        }
        return genders;
      }
      catch(Exception)
      {
        return null;
      }
    }
    #endregion

    public List<MonsterType> GetMonsterTypes()
    {
      var ds = GetDataDisconnected("select * from Monster.MonsterType;");
      throw new NotImplementedException("todo");
    }

    public List<Title> GetTitles()
    {
      var ds = GetDataDisconnected("select * from Monster.Title;");
      return new List<Title>();
    }

    #endregion


    private DataSet GetDataDisconnected(string query)
    {
      SqlDataAdapter da;
      DataSet ds;
      SqlCommand cmd;

      using (var connection = new SqlConnection(connectionString)) //var is a polymorphic variable.
      {
        cmd = new SqlCommand(query, connection);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();

        da.Fill(ds);
      }

      return ds; 
    }
  }
}
