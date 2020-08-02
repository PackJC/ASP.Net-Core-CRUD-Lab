using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabW06StudentGrades.Models.Entities
{
   public class Student
   {
      [Key]
      [StringLength(9, MinimumLength = 9)]
      public string ENumber { get; set; }
      [Required, StringLength(50)]
      public string FirstName { get; set; }
      [Required, StringLength(50)]
      public string LastName { get; set; }
      public ICollection<StudentCourseGrade> Grades { get; set; }

      public Student()
      {
         Grades = new List<StudentCourseGrade>();
      }

      public bool HasCourseRecord(Course course)
      {
         var check = Grades
               .FirstOrDefault(
                  scg => scg.Course.Code == course.Code &&
                     scg.Course.Number == course.Number);
         return check != null;
      }
   }
}
