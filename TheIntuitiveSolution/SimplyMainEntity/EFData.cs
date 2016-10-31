using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Xunit;
//using Xunit.Abstractions;

namespace SimplyMainEntity
{
    public class EFData
    {

    private SchoolDBEntities sdb = new SchoolDBEntities();
    //private ITestOutputHelper output;

    //public EFData(ITestOutputHelper output)
    //{ this.output = output; }

    public EFData()
    {  }

    public List<Person> SearchPersonByName(string name)
    {
      var thepeople = sdb.People.Where(p => p.FirstName==name);   //.First()//.Single();//.Select();//.Where();//.Find(); 
      return thepeople.ToList<Person>();
    }

    public bool ModifyPerson(Person person, EntityState state) 
    {
      var entry = sdb.Entry<Person>(person); //enter this gender into the db entry. it will output a type entry.
      entry.State = state; //This gives it a state (ex. adding, modifying, deleting, etc). We can specify this in the method params.
      try
      { return sdb.SaveChanges() > 0; }
      catch (Exception ex)
      {
        //output.WriteLine("" + ex);
        return false;
      }
    }

    public Object AddNewPerson() //proc
    {
      string first = "Tonya",
             middle = "Trudy",
             last = "Freidzig";
      byte roleid = 1;
      var result = sdb.AddNewPerson(first,middle,last,roleid);
      //output.WriteLine("" + result);
      return result;

      //string sql = GetRunLogFilterSQLString("[dbo].[AddNewPerson] @first, @middle, @last, @roleid;", first,middle,last,roleid);

      //return sdb.AddNewPerson(first, middle, last, roleid);
    }
  }
}
