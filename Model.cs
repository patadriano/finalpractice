using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCRUD
{
    public class Dept
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Dept DeptID { get; set; }    

    }
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Team TeamID { get; set; }
    }
}