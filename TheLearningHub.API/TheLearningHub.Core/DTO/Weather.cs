using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLearningHub.Core.DTO
    {

    public class Main
        {
        public string temp { get; set; }
        public string humidity { get; set; }
        }

    public class Wind
        {
        public string speed { get; set; }
        }

    public class Coord
        {
        public string lon { get; set; }
        public string lat { get; set; }
        }
    public class Weather
        {
        public string? Name { get; set; }
        public int? timezone { get; set; }
        public Main? main { get; set; }
        public Wind? wind { get; set; }

        public Coord? coord { get; set; }
        }

    }
