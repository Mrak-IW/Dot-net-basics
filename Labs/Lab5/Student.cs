using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5
{
	class Student
	{
		string name;
		int course;
		bool hasScholarship;

		public Student(string name)
		{
			this.name = name;
			this.course = 1;
			this.hasScholarship = true;
		}

		public Student(string name, int course)
			:this(name)
		{
			this.course = course;
		}

		public Student(string name, int course, bool hasScholarship)
			:this(name, course)
		{
			this.hasScholarship = hasScholarship;
		}

		public override string ToString()
		{
			return "Имя:\t" + this.name + "\nКурс:\t" + this.course + "\nСтипендия:\t" + this.hasScholarship;
		}
	}
}
