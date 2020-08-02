using LabW06StudentGrades.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabW06StudentGrades.Models.ViewModels
{
   public class NotEnrolledVM
   {
      public Student Student { get; set; }
      public List<Course> Courses { get; set; }
   }
}
