using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyMain.Models
{
  public class FuncCourseInfo
  {
    public int CourseID { get; set; }
    public string CourseTitle { get; set; }
    public int Credit { get; set; }
    public string CourseDepartment { get; set; }
    public int Enrolled { get; set; }
    public int Capacity { get; set; }
    public int TermID { get; set; }
    public string TermName { get; set; }
    public int Day_ { get; set; }
    public string NameOfDay { get; set; }
    public int StartTime { get; set; }
    public int EndTime { get; set; }
    public int RoomID { get; set; }
    public string BuildingName { get; set; }
    public string RoomLocation { get; set; }
    public int RoomCap { get; set; }
  }
}
