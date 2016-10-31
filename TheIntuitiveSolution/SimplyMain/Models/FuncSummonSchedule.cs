﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyMain.Models
{
  public class FuncSummonSchedule
  {
    public string CourseTitle { get; set; }
    public int CourseID { get; set; }
    public string Days { get; set; }


    public string Full_Name { get; set; }
    public int PersonID { get; set; }
    public int RoleID { get; set; }
    public string Role { get; set; }

    public int StartTime { get; set; }
    public int EndTime { get; set; }
    public int Credit { get; set; }
    
    public int Enrolled { get; set; }
    public int Capacity { get; set; }

    public string BuildingName { get; set; }

    public string RoomLocation { get; set; }
    public int RoomCap { get; set; }
    public string TermName { get; set; }
    public int TermID { get; set; }
    public string Dept { get; set; }
    
  }
}