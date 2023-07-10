using System.Collections.Generic;

namespace Points.Models
{
    public class Point
    {
        public int PointId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }
        public string Color { get; set; }
        public List<Comment> Comments { get; set; }
    }
}