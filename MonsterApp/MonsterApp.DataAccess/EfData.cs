using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterApp.DataAccess
{
  public class EfData
  {
    //This was an entity data model generated utilizing Entity Framework, I believe.
    //This works much more effectively, safely and it much quicker/easier to write than alternative ways due to Microsoft 
    //streamlining this for us. (But note that it will be slower, due to Microsoft's overhead). 
    private MonsterDBEntities db = new MonsterDBEntities();

    //There are 2 Genders in db now. 
    //One is in MonsterApp.DataAccess.Models, and the other is in 
    //MonsterApp.DataAccess.Gender. Make sure we use the RIGHT one (NOT the models version).
    public List<MonsterApp.DataAccess.Gender> GetGenders()
    {
      return db.Genders.ToList();
    }

    public bool InsertGender(Gender gender) //ensure this 'Gender' is from MonsterApp.DataAccess.Gender and NOT MonsterApp.DataAccess.Models.Gender
    {
      db.Genders.Add(gender); //this 'add' ADDS it to the context of Entity Framework. (Not the db, directly). 
      
      try
      {
        return db.SaveChanges() > 0; //compare ret val to determine success level. (Returns true if greater than 0, which im not certain if I can assume is a success, necessarily). 
      }
      catch (Exception ex) { return false; }
    }

    public bool InsertMonster(Monster monster)   //HOMEWORK TEST METHOD TO INSERT MONSTER VIA EF
    {
      //this 'add' ADDS it to the context of Entity Framework. (Not the db, directly). 
      db.Monsters.Add(monster);
      try
      {
        return db.SaveChanges() > 0; //compare ret val to determine success level. (Returns true if greater than 0, which im not certain if I can assume is a success, necessarily). 
      }
      catch (Exception ex) { return false; }
    }

    public bool AddMonster(Monster monster, EntityState state)  //HOMEWORK TEST METHOD TO INSERT MONSTER VIA EF
    {
      var entry = db.Entry<Monster>(monster); //enter this gender into the db entry. it will output a type entry.
      entry.State = state; //This gives it a state (ex. adding, modifying, deleting, etc). We can specify this in the method params.
      try
      {
        return db.SaveChanges() > 0;
      }
      catch (Exception ex) { return false; }
    }

    //to get the update to work we may need to pass by reference rather than value?
    public bool ChangeGender(Gender gender, EntityState state)
    {
      var entry = db.Entry<Gender>(gender); //enter this gender into the db entry. it will output a type entry.
      entry.State = state; //This gives it a state (ex. adding, modifying, deleting, etc). We can specify this in the method params.
      try
      {
        return db.SaveChanges() > 0;
      }
      catch (Exception ex) { return false; }
    }

    public void SearchGender()
    {
      //note that while running through where, 
      //all searched stuff will be substituted inside of locally created a variable
      //during the search.

      //a 'implies' a is active?? (NOT to be confused with '>=' greater than or equal to)
      //find me all genders where active is true. 
      //The first part is our lamba expression
      //the other part, a.Active, is our conditional.
      var actives = db.Genders.Where(a => a.Active);   //.First()//.Single();//.Select();//.Where();//.Find(); 
      var inactives = db.Genders.Where(a => !a.Active);
      var ma = db.Genders.Where(m => m.GenderName.ToLower().Contains("ma"));
    }



  }
}
