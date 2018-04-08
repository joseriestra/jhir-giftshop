using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;

namespace Entities.Classes
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
        public bool Available { get; set; }
    }
}
