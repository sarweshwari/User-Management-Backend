﻿using System;
using System.Collections.Generic;

namespace BackendDotNet.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Gender { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string? Address { get; set; }
}
