using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using TheLearningHub.Core.Data;
using TheLearningHub.Core.Service;
using TheLearningHub.Infra.Service;

namespace TheLearningHub.API.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class CourseController : ControllerBase
        {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
            {
            _courseService = courseService;
            }

        [HttpGet]
        //[Route("GetCourses")]
        [CheckClaims("RoleId", "1")]
        public async Task<List<Course>> GetAllCourses()
            {
           return await _courseService.GetAllCourses();
            }

        [HttpPost]
        public async void CreateCourse(Course course)
            {
            _courseService.CreateCourse(course);
            }

        [HttpPut]
        public async void UpdateCourse(Course course )
            {
            _courseService.UpdateCourse(course);
            }
        [HttpDelete ("{id}")]
        public async void DeleteCourse(int id)
            {
            _courseService.DeleteCourse(id);
            }
        [HttpGet]
        [Route ("GetById/{id}")]
        [AllowAnonymous]
        public async Task<Course> GetCourseById(int id)
            {
           return await _courseService.GetCourseById(id);
            }
        [HttpPost]
        [Route ("UploadImage")]
        public Course UploadImage()
            {
            var file = Request.Form.Files[0];
            var fileName = $"{Guid.NewGuid().ToString()}_{file.FileName}" ;
            var fullPath = Path.Combine("C:\\Users\\b.alhassoun.ext\\Documents\\AngularTest\\AngularTest\\src\\assets\\Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                file.CopyTo(stream);
                }

            Course course = new Course();
            course.Imagename = fileName;
            return course;
            }

        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<List<Category>> GetAllCategories()
        {
            return await _courseService.GetAllCategories();
        }

        [HttpGet]
        [Route("GetCoursesByCategoryId/{id}")]
        public async Task<List<Course>> GetCoursesByCategoryId(int id)
        {
            return await _courseService.GetCoursesByCategoryId(id);
        }
    }
    }
