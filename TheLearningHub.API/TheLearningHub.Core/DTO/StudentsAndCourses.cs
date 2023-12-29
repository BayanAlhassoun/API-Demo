using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLearningHub.Core.DTO
{
    public class StudentsAndCourses
    {
        public decimal Courseid { get; set; }
        public string? Coursename { get; set; }
        public decimal? Categoryid { get; set; }
        public string? Imagename { get; set; }
        public decimal Studentid { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public decimal Id { get; set; }
        public decimal? Stdid { get; set; }
        public decimal? Markofstd { get; set; }
        public DateTime? Dateofregister { get; set; }
        public string? Categoryname { get; set; }
    }
}
