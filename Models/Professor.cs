using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class Professor
{
    public int ProfessorId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<Course> Courses { get; } = new List<Course>();

    public virtual User User { get; set; } = null!;
}
