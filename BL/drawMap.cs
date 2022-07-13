using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using DAL.Models;
using System.Linq;

namespace BL
{
    public class drawMap
    {
        public static Bitmap b;
        public static List<Node> listNode;
        public static string ss = "";
        public drawMap(List<Node> listN)
        {
            b = new Bitmap("wwwroot/Images/‏‏mappp1.png");
            ss = "";
            listNode = new List<Node>();
            //בדיקת הצטלבויות-להוסיף לליסט
            using (var Data = new DataProject())
            {
                for (int i = 1; i <= listN.Count-1; i++)
                {
                    Storage s = new Storage();
                    s = Data.Storage.ToList().FirstOrDefault(p => p.CodeStorage == listN[i].codeNode && listN[i].typeNode is Storage);
                    if(!ss.Contains(s.CodeStorage.ToString()))
                    ss += s.NameStorage + " ,  ";
                }
            }

            foreach (var item in listN)
            {
                listNode.Add(item);
            }

        }

        public string[] DrawLineInt(int codeOrder)
        {
            Image i1 = Image.FromFile("wwwroot/Images/1.png");
            Pen blackPen = new Pen(Color.White, 5);

            for (int i = 0; i < listNode.Count - 1; i++)
            {
                using (var graphics = Graphics.FromImage(b))
                {
                    //graphics.DrawImage(i1, new Point(Convert.ToInt32(listNode[i].x), Convert.ToInt32(listNode[i].y)));
                    Point p = new Point(Convert.ToInt32(listNode[i].x), Convert.ToInt32(listNode[i].y));
                    Point p1 = new Point(Convert.ToInt32(listNode[i + 1].x), Convert.ToInt32(listNode[i + 1].y));
                    graphics.DrawLine(blackPen, p, p1);
                }
            }
            return saveNewMap(codeOrder);

        }
        public static string[] saveNewMap(int codeOrder)
        {
            string[] dd = new string[2];
            string name = "newMap" + codeOrder.ToString() + ".png";
            b.Save("wwwroot/routes/" + name, ImageFormat.Png);
            dd[0] = name;
            dd[1] = ss;
            return dd;
        }


    }
}
