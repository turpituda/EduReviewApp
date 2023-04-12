using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public virtual ICollection<Professor> Professors { get; } = new List<Professor>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
