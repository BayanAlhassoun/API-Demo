using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheLearningHub.Core.Data;
using TheLearningHub.Core.DTO;
using TheLearningHub.Core.Service;
using TheLearningHub.Infra.Service;

namespace TheLearningHub.API.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
        {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
            {
            _studentService = studentService;
            }

        [HttpGet]
        public async Task<List<Student>> GetAllStudents()
        {
            return await _studentService.GetAllStudents();
        }

        [HttpGet]
        [Route ("GetByFirstName/{firstName}")]
        public async Task<List<Student>> GetStudentsByFirstName(string firstName)
            {
           return await _studentService.GetStudentsByFirstName(firstName);
            }

        [HttpGet]
        [Route ("Getstudentswithhighstmarks/{numOfStudents}")]
        public async Task<List<StudentsMarks>> Getstudentswithhighstmarks(int numOfStudents)
            {
            return await _studentService.Getstudentswithhighstmarks (numOfStudents);
            }

        [HttpGet]
        [Route("GetAllStudentsAndCourses")]
        public async Task<List<Stdcourse>> GetAllStudentsAndCourses()
        {
            return await _studentService.GetAllStudentsAndCourses();
        }

        [HttpGet]
        [Route("GetAllStudentsAndCourses2")]
        public async Task<List<StudentsAndCourses>> GetAllStudentsAndCourses2()
        {
            return await _studentService.GetAllStudentsAndCourses2();
        }


        [HttpPost]
        public void CreateStudent(Student student)
        {
              _studentService.CreateStudent(student);
        }
    }
    }
