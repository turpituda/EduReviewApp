using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Models;

public partial class Submission
{
    public Guid SubmissionId { get; set; }

    public DateTime? SubmissionDate { get; set; }
    [EnumDataType(typeof(StatusValues))]
    public string? SubmissionStatus { get; set; }
    public string? FileName { get; set; }

    public string? SubmissionComment { get; set; }
    public IFormFile files { get; set; }

    public Guid? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
    public enum StatusValues
    {
        returned,
        rejected,
        accepted,
        pending
    }