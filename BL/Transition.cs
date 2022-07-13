using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    //מחלקת מעבר
    public class Transition
    {
        public int codeTransition { get; set; }

        public List<Intersection> listIntersections;
        public Transition()
        {
            listIntersections = new List<Intersection>();
        }
    
    }
}
