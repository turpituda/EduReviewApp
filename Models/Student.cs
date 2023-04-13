using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models;

public partial class Student
{
    public Guid StudentId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    [ForeignKey("User")]
    public Guid user_id { get; set; }

    public virtual ICollection<Submission> Submissions { get; } = new List<Submission>();

    public virtual Users User { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; } = new List<Course>();
}
