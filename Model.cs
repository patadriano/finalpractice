using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCRUD
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Group group { get; set; }
    }
    public class Group 
    {
        public int ID { get; set; }
        public string Name { get; set; }
       
    }
}