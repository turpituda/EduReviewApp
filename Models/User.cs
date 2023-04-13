using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Models;

public partial class Users
{
    public Guid user_id { get; set; }

    public string username { get; set; }

    public string password { get; set; }

    public string email { get; set; }
    [EnumDataType(typeof(MyValues))]
    public string user_type { get; set; }

    public virtual ICollection<Professor> Professors { get; } = new List<Professor>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
    public enum MyValues
    {
        a,
        s,
        p
    }