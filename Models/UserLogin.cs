using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Models;

public partial class UserLogin
{
    public string username { get; set; }

    public string password { get; set; }

}