﻿using CoreShape.Graphics;
using CoreShape.Shapes.ResizeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Shapes.Interfaces;
public interface IShape : IDrawable, IDraggable, IHitTest
{
    bool IsSelected { get; set; }
}
