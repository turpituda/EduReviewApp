using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class Assignment
{
    public int AssignmentId { get; set; }

    public string? AssignmentName { get; set; }

    public int? CourseId { get; set; }

    public string? Description { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Submission> Submissions { get; } = new List<Submission>();
}
