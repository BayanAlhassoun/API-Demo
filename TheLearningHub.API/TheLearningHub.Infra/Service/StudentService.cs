using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.Core.Data;
using TheLearningHub.Core.DTO;
using TheLearningHub.Core.Repository;
using TheLearningHub.Core.Service;

namespace TheLearningHub.Infra.Service
    {
    public class StudentService : IStudentService
        {

        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository sourseRepository) // IStudentRepository sourseRepository = new StudentRepository()
            {
            _studentRepository= sourseRepository; // _studentRepository = new StudentRepository()
            }
        public async void CreateStudent(Student student)
            {
            _studentRepository.CreateStudent(student);

            }

        public async void DeleteStudent(int id)
            {
            _studentRepository.DeleteStudent(id);
            }

        public Task<List<Student>> GetAllStudents()
            {
           return _studentRepository.GetAllStudents();
            }

        public async Task<List<Stdcourse>> GetAllStudentsAndCourses()
        {
            return await _studentRepository.GetAllStudentsAndCourses();

        }

        public async Task<List<StudentsAndCourses>> GetAllStudentsAndCourses2()
        {
            return await _studentRepository.GetAllStudentsAndCourses2();
        }

        public Task<Student> GetStudentById(int id)
            {
            return _studentRepository.GetStudentById(id);
            }

        public async Task<List<Student>> GetStudentsByFirstName(string firstName)
            {
           return await _studentRepository.GetStudentsByFirstName(firstName);
            }

        public async Task<List<StudentsMarks>> Getstudentswithhighstmarks(int numOfStudents)
            {
            return await _studentRepository.Getstudentswithhighstmarks(numOfStudents);
            }

        public async void UpdateStudent(Student student)
            {
            _studentRepository.UpdateStudent(student);
            }
        }
    }
