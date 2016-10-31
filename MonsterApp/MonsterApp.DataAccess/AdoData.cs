using MonsterApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterApp.DataAccess 
{
  //this is a library. It needs to be used by something else. It CANNOT be executed/run by itself.
  public partial class AdoData
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
             GenderName = row[1].ToString(),
             Active = bool.Parse(row[2].ToString())
          });
        }
        return genders;
      }
      catch(Exception ex)
      {
        Debug.WriteLine(ex);
        return null;
      }
    }
    #endregion

    #region GetMonsterTypes
    public List<MonsterType> GetMonsterTypes()
    {
      try  
      {
        var ds = GetDataDisconnected("select * from Monster.MonsterType;");
        var monstertypes = new List<MonsterType>();

        foreach (DataRow row in ds.Tables[0].Rows)
        {
          monstertypes.Add(new MonsterType
          { 
            MonsterTypeID = int.Parse(row[0].ToString()),
            TypeName = row[1].ToString(),
            Active = bool.Parse(row[2].ToString())
          });
        }
        return monstertypes;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
        return null;
      }
    }
    #endregion

    #region GetMonsters
    public List<Monster> GetMonsters()
    {
      try
      {
        var ds = GetDataDisconnected("select * from Monster.Monster;");
        var monsters = new List<Monster>();

        foreach (DataRow row in ds.Tables[0].Rows)
        {
          monsters.Add(new Monster
          {
            MonsterID = int.Parse(row[0].ToString()),
            GenderID = int.Parse(row[1].ToString()),
            TitleID = int.Parse(row[2].ToString()),
            TypeID = int.Parse(row[3].ToString()),
            Name = row[4].ToString(),
            PicturePath = row[5].ToString(),
            Active = bool.Parse(row[6].ToString())
          });
        }
        return monsters;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
        return null;
      }
    }
    #endregion

    #region GetTitles
    public List<Title> GetTitles()
    {
      try
      {
        var ds = GetDataDisconnected("select * from Monster.Title;");
        var titles = new List<Title>();

        foreach (DataRow row in ds.Tables[0].Rows)
        {
          titles.Add(new Title
          {
            TitleID = int.Parse(row[0].ToString()),
            TitleName = row[1].ToString(),
            Active = bool.Parse(row[2].ToString())
          });
        }
        return titles;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
        return null;
      }
    }
    #endregion





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

    ///
    #region SetDataDisconnection MethodTests - possibly an obsolete backup
    private int SetDataDisconnectedMonster(string query, Monster mon)//Monster mon)  //HOMEWORK TEST METHOD TO INSERT MONSTER VIA ADO
    {
      SqlCommand cmd;
      int retval;
      using (var connection = new SqlConnection(connectionString)) 
      {
        cmd = new SqlCommand(query, connection);
        cmd.Parameters.Add("@genderid", SqlDbType.Int).Value = mon.GenderID;
        cmd.Parameters.Add("@titleid", SqlDbType.Int).Value = mon.TitleID;
        cmd.Parameters.Add("@typeid", SqlDbType.Int).Value = mon.TypeID;
        cmd.Parameters.Add("@name", SqlDbType.NVarChar, 250).Value = mon.Name;
        cmd.Parameters.Add("@picturepath", SqlDbType.NVarChar, 256).Value = mon.PicturePath;
        cmd.Parameters.Add("@active", SqlDbType.Bit).Value = mon.Active;
        connection.Open();
        retval=cmd.ExecuteNonQuery();
        connection.Close();
      }
      return retval;
    }

    private int SetDataDisconnectedMonsterType(string query, MonsterType mon)
    {
      SqlCommand cmd;
      int retval;
      using (var connection = new SqlConnection(connectionString))
      {
        cmd = new SqlCommand(query, connection);
        cmd.Parameters.Add("@typename", SqlDbType.NVarChar, 256).Value = mon.TypeName;
        cmd.Parameters.Add("@active", SqlDbType.Bit).Value = mon.Active;

        connection.Open();
        retval = cmd.ExecuteNonQuery();
        connection.Close();
      }
      return retval;
    }

    private int SetDataDisconnectedTitle(string query, Title ti)
    {
      SqlCommand cmd;
      int retval;
      using (var connection = new SqlConnection(connectionString))
      {
        cmd = new SqlCommand(query, connection);
        cmd.Parameters.Add("@titlename", SqlDbType.NVarChar, 256).Value = ti.TitleName;
        cmd.Parameters.Add("@active", SqlDbType.Bit).Value = ti.Active;

        connection.Open();
        retval = cmd.ExecuteNonQuery();
        connection.Close();
      }
      return retval;
    }
#endregion

  }
}
