using LabW06StudentGrades.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabW06StudentGrades.Services
{
   public interface IStudentRepository
   {
      ICollection<Student> ReadAll();
      Student Read(string id);
      void EnrollInCourse(string id, string courseCode, string courseNumber);
   }
}
