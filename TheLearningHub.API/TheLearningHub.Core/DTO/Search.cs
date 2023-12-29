using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLearningHub.Core.DTO
    {
    public class Search
        {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Coursename { get; set; }
        public decimal? Markofstd { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set;}
        }
    }
