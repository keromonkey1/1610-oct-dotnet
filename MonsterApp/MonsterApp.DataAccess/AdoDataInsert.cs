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

    #region InsertionMethods (Gender, Monster, Title, MonsterType)
    public bool InsertGender(Gender gender)
    {
      //define query
      var query = "insert into Monster.Gender(GenderName, Active) values(@name, @num)";
      //define sql params to insert into query
      var name = new SqlParameter("name", gender.GenderName);
      var num = new SqlParameter("num", 1);
      //return the value returned by this function call. 
      return InsertData(query, name, num);
    }

    public bool InsertGender(Models.Gender gender)
    {
      //define query
      var query = "insert into Monster.Gender(GenderName, Active) values(@name, @num)";
      //define sql params to insert into query
      var name = new SqlParameter("name", gender.Name); //.GenderName);
      var num = new SqlParameter("num", 1);
      //return the value returned by this function call. 
      return InsertData(query, name, num);
    }

    #region InsertMonster
    public bool InsertMonster(Monster monster)  //HOMEWORK TEST METHOD TO INSERT MONSTER VIA ADO
    {
      try
      {
        var query = "insert into Monster.Monster(GenderID,TitleID,TypeID,Name,PicturePath,Active) values (@genderid, @titleid, @typeid, @name, @picturepath, @active)";

        var genderid = new SqlParameter("genderid", monster.GenderID);
        var titleid = new SqlParameter("titleid", monster.TitleID);
        var typeid = new SqlParameter("typeid", monster.TypeID);
        var name = new SqlParameter("named", monster.Name);
        var picturepath = new SqlParameter("picturepath", monster.PicturePath);
        var active = new SqlParameter("genderid", monster.Active);

        var retval = InsertData(query, genderid, titleid, typeid, name, picturepath, active);//SetDataDisconnectedMonster(query, monster);
        return retval; //true or false
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
        return false;
      }
    }
    #endregion

    #region InsertMonsterType
    public bool InsertMonsterType(MonsterType monstertype)  
    {
      try
      {
        var query = "insert into Monster.MonsterType(TypeName,Active) values (@typename, @active)";

        var typename = new SqlParameter("typename", monstertype.TypeName);
        var active = new SqlParameter("active", monstertype.Active);

        var retval = InsertData(query, typename, active) ;//SetDataDisconnectedMonsterType(query, monstertype);
        return retval; //true or false
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
        return false;
      }
    }
    #endregion

    #region InsertTitle
    public bool InsertTitle(Title title)  
    {
      try
      {
        var query = "insert into Monster.Title(TitleName, Active) values(@titlename,@active)";

        var titlename = new SqlParameter("titleename", title.TitleName);
        var active = new SqlParameter("active", title.Active);

        var retval = InsertData(query, titlename,active);// SetDataDisconnectedTitle(query, title);
        return retval;  //true or false
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
        return false;
      }
    }
    #endregion

#endregion 



    public bool DeleteGender(int id)
    {
      //Example Delete --> 
      //DELETE FROM Customers WHERE CustomerName = 'Alfreds Futterkiste' AND ContactName = 'Maria Anders'
      var query = "delete from Monster.Gender where GenderID = @id";
      var num = new SqlParameter("id", id);
      return InsertData(query, num);
    }



    //This is a flexible function that can insert, delete or alter data due to the way its writen. (i.e. ExecuteNonQuery)
    private bool InsertData(string query, params SqlParameter[] parameters) //params is a variable number of arguments I can insert into it.
    {
      SqlCommand cmd;
      int result=0;

      //This sql connection string is ACTUALLY in MonsterApp.DataAccess.AdoData class.
      //However, because they are both now named the same and are both partial classes, 
      //they can, in effect, see aspects of eachother. 
      //(Recall that classes created using the partial keyword...and w/the same name are merged into one class at runtime). 
      using (var connection = new SqlConnection(connectionString)) //ConfigurationManager.ConnectionStrings["MonsterDB"].ConnectionString
      {
        connection.Open();
        cmd = new SqlCommand(query, connection);  //sets the query

        foreach(var value in parameters) //updates the query
          cmd.Parameters.Add(value);

        try
        { result = cmd.ExecuteNonQuery(); }
        catch(Exception ex) { }
      }
      return result >0; //if result is 1, returns true, else false. 
    }

  }
}
