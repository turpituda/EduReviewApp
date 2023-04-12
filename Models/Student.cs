using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<Submission> Submissions { get; } = new List<Submission>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; } = new List<Course>();
}
