﻿using ConsoleApp3;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _17bangTests
{
    class BinarySeekTest
    {
        Student student, student1, student2, student3, student4;
        IList<Student> Students;
        int a;
        [SetUp]
        public void SetUp()
        {
            student = new Student(12);
            student1 = new Student(19);
            student2 = new Student(15);
            student3 = new Student(10);
            student4 = new Student();

            Students = new List<Student>
            {
                student,student1,student2,student3
            };

        }

        [Test]
        public void SeekStudent()
        {
            a = DataStucture<Student>.BinaryWhile(Students, student);

            Assert.AreEqual(a, 0);
        }

        [Test]
        public void SeekStudent1()
        {
            a = DataStucture<Student>.BinaryWhile(Students, student1);

            Assert.AreEqual(a, 1);

        }

        [Test]
        public void SeekStudent2()
        {
            a = DataStucture<Student>.BinaryWhile(Students, student2);

            Assert.AreEqual(a, 2);

        }

    }
}
