using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class File
{
    public int FileId { get; set; }

    public string? FileName { get; set; }

    public Guid? SubmissionId { get; set; }

    public virtual Submission? Submission { get; set; }
}
