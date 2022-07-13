using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class Intersection
    {
        public int CodeIntersection { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public List<Transition> transitions;//רשימת מעברים

    }
}
