using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterApp.DataAccess.Models
{
  public class Title
  {
    public int TitleID { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }
    public string TitleName { get; internal set; }
  }
}
