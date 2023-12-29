using System;
using System.Collections.Generic;

namespace TheLearningHub.Core.Data
{
    public partial class Login
    {
        public decimal Loginid { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public decimal? Roleid { get; set; }
        public decimal? Stdid { get; set; }

        public virtual Role? Rold { get; set; }
        public virtual Student? Std { get; set; }
    }
}
