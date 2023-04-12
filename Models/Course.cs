using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public int ProfessorId { get; set; }

    public virtual ICollection<Assignment> Assignments { get; } = new List<Assignment>();

    public virtual Professor Professor { get; set; } = null!;

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
