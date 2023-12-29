using Dapper;

using System;

using System.Collections.Generic;

using System.Data;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using TheLearningHub.Core.Common;

using TheLearningHub.Core.Data;
using TheLearningHub.Core.DTO;
using TheLearningHub.Core.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TheLearningHub.Infra.Repository

{

public class StudentReopsitory : IStudentRepository

    {

    private readonly IDbContext _dbContext;

    public StudentReopsitory(IDbContext dbContext)

        {

        _dbContext = dbContext;

        }

    public void CreateStudent(Student student)

        {

        var p = new DynamicParameters();

        p.Add("first_name", student.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);

        p.Add("last_name", student.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);

        p.Add("date_of_birth", student.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);

        _dbContext.Connection.ExecuteAsync("STUDENT_PACKAGE.CreateStudent", p, commandType: CommandType.StoredProcedure);

        }

    public void DeleteStudent(int id)

        {

        var p = new DynamicParameters();

        p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

        _dbContext.Connection.ExecuteAsync("STUDENT_PACKAGE.DeleteStudent", p, commandType: CommandType.StoredProcedure);

        }



    public async Task<List<Student>> GetAllStudents()

        {

        IEnumerable<Student> result = await _dbContext.Connection.QueryAsync<Student>("STUDENT_PACKAGE.GetAllStudent", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Stdcourse>> GetAllStudentsAndCourses()
        {

            IEnumerable<Stdcourse> result = await _dbContext.Connection.QueryAsync<Course, Stdcourse, Student , Category, Stdcourse>("category_package.getcoursesandstudents", (course, stdcourse, student, category) =>
            {
                stdcourse.Course = course;
                stdcourse.Std = student;
                course.Category = category;
                return stdcourse;
            },
            splitOn: "Courseid, Studentid, Categoryid", commandType: CommandType.StoredProcedure);

            return result.ToList();

            //IEnumerable<Stdcourse> result = await _dbContext.Connection.QueryAsync<Stdcourse>("category_package.getcoursesandstudents", commandType: CommandType.StoredProcedure);

            //return result.ToList();
        }

        public async Task<List<StudentsAndCourses>> GetAllStudentsAndCourses2()
        {
            IEnumerable<StudentsAndCourses> result = await _dbContext.Connection.QueryAsync<StudentsAndCourses>("category_package.getcoursesandstudents", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<Student> GetStudentById(int id)

        {

        var p = new DynamicParameters();

        p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

        var result = _dbContext.Connection.Query<Student>("STUDENT_PACKAGE.GetStudentById", p, commandType: CommandType.StoredProcedure);

        return result.FirstOrDefault();

        }

    public async Task<List<Student>> GetStudentsByFirstName(string firstName)
        {
        var p = new DynamicParameters();
        p.Add("Name", firstName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result =await _dbContext.Connection.QueryAsync<Student>("STUDENT_PACKAGE.GetStudentByFname", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<StudentsMarks>> Getstudentswithhighstmarks(int numOfStudents)
            {
            var p = new DynamicParameters();
            p.Add("NumOfStudens", numOfStudents, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result =await _dbContext.Connection.QueryAsync<StudentsMarks>("STUDENT_PACKAGE.GetStudentsWithHighstMarks", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
            }

        public async void UpdateStudent(Student student)

        {

        var p = new DynamicParameters();

        p.Add("ID", student.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);

        p.Add("first_name", student.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);

        p.Add("last_name", student.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);

        p.Add("date_of_birth", student.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);

        _dbContext.Connection.ExecuteAsync("STUDENT_PACKAGE.UpdateStudent", p, commandType: CommandType.StoredProcedure);

        throw new NotImplementedException();

        }

    }

}
