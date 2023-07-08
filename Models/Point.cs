using System;
using System.Collections.Generic;

namespace Points.Models
{
    public class Point
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }
        public Color Color { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
