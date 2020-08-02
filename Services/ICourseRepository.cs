using LabW06StudentGrades.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabW06StudentGrades.Services
{
   public interface ICourseRepository
   {
      ICollection<Course> ReadAll();
      Course Read(string courseCode, string courseNumber);
   }
}
