﻿using System;
using System.Collections.Generic;

namespace VerticalSlice.Domain.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
