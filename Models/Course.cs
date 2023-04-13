using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class Course
{
    public Guid CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public Guid ProfessorId { get; set; }


    public virtual Professor Professor { get; set; } = null!;

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
