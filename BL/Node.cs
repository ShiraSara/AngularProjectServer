using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class Node
    {
        public int codeNode { get; set; }
        public object typeNode { get; set; }
        public bool IsPass { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double Weight { get; set; }

        //רשימת המעברים הקורבים להצטלבות,נטען מהקובץ
        public List<Transition> transitionsList;

        //רשימת הקודקודים שעברנו בהם מהנקודה הקודמת ועד לנקודה הנוכחית, במהלך הריצה של הדייקסטרה
        public List<Node> ListNodesPass { get; set; }

 
    } 
}
