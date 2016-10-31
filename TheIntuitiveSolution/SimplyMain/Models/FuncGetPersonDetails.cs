using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyMain.Models
{
  public class FuncGetPersonDetails
  {
    public string Full_Name { get; set; }
    public int PersonID { get; set; }
    public int RoleID { get; set; }

    public string Role { get; set; }
    public string Major { get; set; }
    public DateTime DateOfCreation { get; set; }
  }
}
