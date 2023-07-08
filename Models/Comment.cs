using System;

namespace Points.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Color BackgroundColor { get; set; }
        public Point Point { get; set; }
    }
}
