using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterApp.DataAccess.Models
{
  /// <summary>
  /// the type of monsters you can have in movies.
  /// </summary>
  public class MonsterType
  {
    public int MonsterTypeID { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }
    public string TypeName { get; internal set; }
  }
}
