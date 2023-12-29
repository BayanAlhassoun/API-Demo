using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.Core.Data;
using TheLearningHub.Core.DTO;

namespace TheLearningHub.Core.Service
    {
    public interface IStudentService
        {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);

        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        Task<List<Student>> GetStudentsByFirstName(string firstName);
        Task<List<StudentsMarks>> Getstudentswithhighstmarks(int numOfStudents);
        Task<List<Stdcourse>> GetAllStudentsAndCourses();
        Task<List<StudentsAndCourses>> GetAllStudentsAndCourses2();



    }
}
