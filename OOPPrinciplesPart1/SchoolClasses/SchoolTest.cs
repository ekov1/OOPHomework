﻿/*Problem 1. School classes

    We are given a school. In the school there are classes of students. Each class has a set of teachers. Each teacher teaches
    a set of disciplines. Students have name and unique class number. Classes have unique text identifier. Teachers have name.
    Disciplines have name, number of lectures and number of exercises. Both teachers and students are people. Students, classes,
    teachers and disciplines could have optional comments (free text block).
    Your task is to identify the classes (in terms of OOP) and their attributes and operations, encapsulate their fields, define
    the class hierarchy and create a class diagram with Visual Studio.
*/

namespace SchoolClasses
{
    using System;
    using System.Text;

    internal class SchoolTest
    {
        public static void Main()
        {
            School school = LoadSchool();
            Console.WriteLine(PrintSchoolInfo(school));
        }

        private static School LoadSchool()
        {
            School school = new School("Geo Milev");

            Class eightA = new Class("8a");
            eightA.Comment = "Will participate in the school project.";
            Class eightB = new Class("8b");

            Student pesho = new Student("Pesho");
            pesho.Comment = "Call the parents.";
            Student ivan = new Student("Ivan");

            Discipline math = new Discipline("Math", 8, 8);
            Discipline physics = new Discipline("Physics", 6, 6);

            Teacher petrova = new Teacher("Petrova");
            Teacher ivanova = new Teacher("Ivanova");
            ivanova.Comment = "Agreed to show the kids the NASA shuttle.";

            petrova.AddDiscipline(math);
            ivanova.AddDiscipline(physics);

            eightA.AddStudent(pesho);
            eightA.AddTeacher(petrova);
            eightB.AddStudent(ivan);
            eightB.AddTeacher(ivanova);

            school.AddClass(eightA);
            school.AddClass(eightB);

            return school;
        }

        private static string PrintSchoolInfo(School school)
        {
            StringBuilder builder = new StringBuilder(school.Name).AppendLine();
            foreach (Class @class in school.Classes)
            {
                builder.AppendLine(@class.TextID + " // " + @class.Comment);
                foreach (Teacher teacher in @class.Teachers)
                {
                    builder.AppendLine("  " + teacher.ToString() + " // " + teacher.Comment);
                }

                foreach (Student student in @class.Students)
                {
                    builder.AppendLine("  " + student.ToString() + " // " + student.Comment);
                }
            }

            return builder.ToString();
        }
    }
}
