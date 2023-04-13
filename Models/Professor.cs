using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class Professor
{
    public Guid ProfessorId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Guid user_id { get; set; }

    public virtual ICollection<Course> Courses { get; } = new List<Course>();

    public virtual Users User { get; set; } = null!;
}
