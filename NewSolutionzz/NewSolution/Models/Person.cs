using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSolution.Models
{
  public class Person
  {
    public int PersonID { get; set; }
    public int RoleID { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfCreation { get; set; } //public string DateOfCreation { get; set; }
  }
}
