using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.Core.Data;
using TheLearningHub.Core.Repository;
using TheLearningHub.Core.Service;

namespace TheLearningHub.Infra.Service
    {
    public class CourseService : ICourseService
        {

        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository) // courseRepository = new CourseRepository
            {
            _courseRepository= courseRepository; // _courseRepository  = new CourseRepository
            }
        public async void CreateCourse(Course course)
            {
             _courseRepository.CreateCourse(course);
            }

        public async void DeleteCourse(int id)
            {
            _courseRepository.DeleteCourse(id);
            }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _courseRepository.GetAllCategories();
        }

        public async Task<List<Course>> GetAllCourses()
            {
           return await _courseRepository.GetAllCourses();
            }

        public async Task<Course> GetCourseById(int id)
            {
           return await _courseRepository.GetCourseById(id);
            }

        public async Task<List<Course>> GetCoursesByCategoryId(int id)
        {
            return await _courseRepository.GetCoursesByCategoryId(id);
        }

        public async void UpdateCourse(Course course)
            {
            _courseRepository.UpdateCourse(course);
            }
        }
    }
