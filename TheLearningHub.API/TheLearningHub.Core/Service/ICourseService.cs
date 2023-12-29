﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.Core.Data;

namespace TheLearningHub.Core.Service
    {
    public interface ICourseService
        {

        Task<List<Course>> GetAllCourses();
        Task<Course> GetCourseById(int id);

        void CreateCourse(Course course);  // coursename = c# , categoriId = 1 , ImageName = img.png

        void UpdateCourse(Course course);
        void DeleteCourse(int id);
        Task<List<Category>> GetAllCategories();
        Task<List<Course>> GetCoursesByCategoryId(int id);
    }
    }
