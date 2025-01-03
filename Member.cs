using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatExam
{

	public class Employee
	{
		public string Name { get; set; }
		public string Address { get; set; }
	}

	public class Team
	{
		public string Name { get; set; }
		public int NumEmployees { get; set; }
		public Employee TeamLead { get; set; }
		public List<Employee> Employees { get; set; }
	}

	public class Department
	{
		public List<Team> Teams { get; set; }
		public Employee DeptHead { get; set; }
		public string Name { get; set; }
		public int NumTeams { get; set; }
	}

	public class Person
	{
		public string Name { get; set; }
	}
	public class Subject
	{
		public List<Person> Students { get; set; }
		public string Classroomname { get; set; }
	}
	public class Teacher
	{
		public Person Me { get; set; }
		public List<Subject> Subjects { get; set; }
		public int Salary { get; set; }
	}

	public class BasicTeacher
	{
        public Person Me { get; set; }
        public Dictionary<int, List<string>> Subjects { get; set; }
	}


}
