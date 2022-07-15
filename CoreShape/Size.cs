﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape;
public record struct Size
{
    public float Width { get; init; }
    public float Height { get; init; }

    public Size(float width, float height) => (Width, Height) = (width, height);
}
