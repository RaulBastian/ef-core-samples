using MultiLingualConsoleDB.model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MultiLingualConsoleDB
{
    public class Course
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public ICollection<Course_T> Course_Ts { get; set; }
    }

    public class Course_T
    {
        public int Id { get; set; }

        public Language Language { get; set; }

        public Course Course { get; set; }

        public string Name { get; set; }

    }
}
