using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSolution.Models
{
  public class Course
  {
    public int CourseID { get; set; }
    public string CourseTitle { get; set; }
    public int Credit { get; set; }
    public string CourseDepartment { get; set; }
    public int Enrolled { get; set; }
    public int Capacity { get; set; }
    public int TermID { get; set; }
  }
}
