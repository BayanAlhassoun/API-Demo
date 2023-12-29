using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.Core.Common;
using TheLearningHub.Core.Data;
using TheLearningHub.Core.Repository;

namespace TheLearningHub.Infra.Repository
    {
    public class CourseRepository : ICourseRepository
        {

        private readonly IDbContext _dbContext;

        public CourseRepository(IDbContext dbContext) // IDbContext dbContext = new DbContext();
            {
            _dbContext = dbContext; // _dbContext = new DbContext();
            }

        public async void CreateCourse(Course course)
            {
            var p = new DynamicParameters();
            p.Add("COURSENAME", course.Coursename , dbType: DbType.String , direction: ParameterDirection.Input);
            p.Add("CATID", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("image", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("Course_Package.CreateCourse", p, commandType: CommandType.StoredProcedure);
            }

        public async void DeleteCourse(int id)
            {
            var p = new DynamicParameters();
            p.Add("Id", id , dbType:DbType.Int32 , direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("Course_Package.DeleteCourse", p, commandType: CommandType.StoredProcedure);
            }

        public async Task<List<Category>> GetAllCategories()
        {
            var result = await _dbContext.Connection.QueryAsync<Category>("CATEGORY_PACKAGE.GETALLCATEGORIES",  commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Course>>GetAllCourses()
            {
            var result =await _dbContext.Connection.QueryAsync<Course, Category, Course>("Course_Package.GetAllCourses", (course, category) =>
            {
                course.Category = category;
                return course;
            } ,
            splitOn: "categoryid", commandType: CommandType.StoredProcedure);
            return result.ToList();
            }

        public async Task<Course> GetCourseById(int id)
            {
            var p = new DynamicParameters();
            p.Add("id", id , dbType: DbType.Int32 , direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Course>("Course_Package.GetCourseById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
            }

        public async Task<List<Course>> GetCoursesByCategoryId(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Course>("CATEGORY_PACKAGE.GETCoursesByCategoryID", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void UpdateCourse(Course course)
            {

                var p = new DynamicParameters();
                p.Add("id", course.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("CNAME", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add("CATID", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("image", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
                _dbContext.Connection.ExecuteAsync("Course_Package.UpdateCourse", p, commandType: CommandType.StoredProcedure);
                

                }
        }
    }
