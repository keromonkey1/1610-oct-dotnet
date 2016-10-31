using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyMain.Models
{
  public class TimeBlock
  {
    public int CourseID { get; set; }
    public int Day_ { get; set; }
    public int StartTime { get; set; }
    public int EndTime { get; set; }
    public int TermID { get; set; }
    public int RoomID { get; set; }
  }
}
