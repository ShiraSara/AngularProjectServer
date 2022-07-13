using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DAL.Models;

namespace BL
{
    public class Graph : Igrafh
    {
        //צמתים כללים
        public static List<Node> generalNodes = new List<Node>();
        //צמתים שנעבור בהם
        public static List<Node> enterNodes = new List<Node>();
        //רשימת סופית שנעבור בה
        public List<Node> finalNodes = new List<Node>();
        int count = 0;
        int codeOrder1;
        //הגדרת מטריצה מסוג קשת
        Rainbow[,] matRainbow;
        Node n;
        Rainbow[,] ezerRainbow;
        public static List<Storage> storages = new List<Storage>();
        int count_Intersection‏ = 0;
        int count_storage = 0;
        List<Node> ll = new List<Node>();
        MinHeap heap;
        public Graph()
        {
            generalNodes = new List<Node>();
            enterNodes = new List<Node>();
        }
        //פונקציה שמקבלת רישמה של מחסנים מעדכנת מטריצה חדשה + רשימת הenterNodes
        //*********לאתחל את כמות המחסנים שנרצה לעבור****************
        public void buildMat1(List<Storage> listStorage)
        {
            {
                count = listStorage.Count;//עדכון כמות המחסנים שרוצים לעבור בהם
                foreach (var item in listStorage)//אתחול enterNodes
                {
                    if (item != null)
                    {
                        Node n = new Node();
                        n.x = (double)item.X;
                        n.y = (double)item.Y;
                        n.Weight = double.MaxValue;
                        n.typeNode = new Storage();
                        n.codeNode = item.CodeStorage;
                        n.IsPass = false;
                        n.transitionsList = new List<Transition>();
                        int? v1 = item.transition;
                        int v2;
                        v2 = v1 ?? default(int);
                        Transition t = new Transition();
                        t.codeTransition = v2;
                        n.transitionsList.Add(t);
                        enterNodes.Add(n);
                    }
                }
                // הוספת הצטלביות
                foreach (var item in generalNodes)
                {
                    if (item.typeNode is Intersection && item != null)
                    {
                        enterNodes.Add(item);
                    }
                }
            }
        }
        //בנית המטריצה המתעדכנת
        public void buildMat2()
        {
            ezerRainbow = new Rainbow[enterNodes.Count, enterNodes.Count];
            //הקצאת מטריצה חדשה
            //עוברת על הליסט הקטן
            for (int k = 0; k < enterNodes.Count; k++)
            {
                enterNodes[k].Weight = double.MaxValue;//איתחול לאינסוף
                enterNodes[k].ListNodesPass = new List<Node>();//איתחול קודקודי האבא
                //בדיקה מה מספר השורה בליסט הגדול של השורה שאנחנו עומדים עליה
                int i = generalNodes.IndexOf(generalNodes.FirstOrDefault(x => x.codeNode == enterNodes[k].codeNode));
                //לולאה שעוברת על כל הליסט הקטן ומחפשת עבור כל אחד איפה הוא נמצא בליסט הגדול
                for (int j = 0; j < enterNodes.Count; j++)
                {
                    string o = enterNodes[j].typeNode.ToString();
                    var q = generalNodes.FirstOrDefault(x => x.typeNode.ToString() == o && x.codeNode == enterNodes[j].codeNode);
                    int z = generalNodes.IndexOf(q);
                    if (z != -1)
                    {
                        ezerRainbow[k, j] = new Rainbow();
                        ezerRainbow[k, j].distance = matRainbow[i, z].distance;
                    }
                }
            }
            enterNodes[0].Weight = 0;
        }
        //-- מחסנים-פונקציית מילוי צמתים כללים מקובץ אקסל
        public void ReadFromExcelToList1(string filaName)
        {
            Node n = new Node();
            StreamReader read = new StreamReader(filaName, Encoding.Default);
            string str = read.ReadToEnd();
            string[] arr = str.Split('\n');
            count_storage = arr.Length;
            n.typeNode = new Storage();
            n.x = 1371;
            n.y = 719;
            n.IsPass = false;
            n.transitionsList = new List<Transition>();
            Transition t = new Transition();
            t.codeTransition = 1;
            n.transitionsList.Add(t);
            generalNodes.Add(n);
            for (int i = 1; i < arr.Length - 1; i++)
            {
                int j = 0;
                n = new Node();
                string[] arr1 = arr[i].Split(',');
                n.codeNode = Convert.ToInt32(arr1[j++]);
                n.x = Convert.ToInt32(arr1[j++]);
                n.y = int.Parse(arr1[j++]);
                t = new Transition();
                t.codeTransition = int.Parse(arr1[j++]);
                n.typeNode = new Storage();
                t.listIntersections = new List<Intersection>();
                n.IsPass = false;
                n.transitionsList = new List<Transition>();
                n.transitionsList.Add(t);
                generalNodes.Add(n);
            }
        }
        //-- הצטלבויות-פונקציית מילוי צמתים כללים מקובץ אקסל
        public void ReadFromExcelToList2(string filaName)
        {
            Node n;
            StreamReader read = new StreamReader(filaName, Encoding.Default);

            string str = read.ReadToEnd();

            string[] arr = str.Split('\n');
            count_Intersection = arr.Length;
            for (int i = 1; i < arr.Length - 1; i++)
            {
                int j = 0;
                n = new Node();
                string[] arr1 = arr[i].Split(',');
                n.codeNode = Convert.ToInt32(arr1[j++]);
                n.x = Convert.ToInt32(arr1[j++]);
                n.y = int.Parse(arr1[j++]);
                n.typeNode = new Intersection();
                Transition t = new Transition();
                n.IsPass = false;
                n.transitionsList = new List<Transition>();
                for (int i1 = 0; i1 < 4; i1++)
                {
                    t = new Transition();
                    if (int.Parse(arr1[j]) != 0)
                    {
                        t.codeTransition = int.Parse(arr1[j++]);
                        n.transitionsList.Add(t);
                    }
                }
                generalNodes.Add(n);
                ll.Add(n);
            }

        }
        //פונקציה שמקבלת מספר מחסנים ומקצה את המטריצה
        public void InitMat()
        {
            matRainbow = new Rainbow[generalNodes.Count, generalNodes.Count];
        }
        public Transition t = new Transition();
        public Transitions t1 = new Transitions();
        //מילוי גרף המרחקים המלא
        public void FullMat()
        {
            for (int i = 0; i < generalNodes.Count; i++)
            {
                for (int j = 0; j < generalNodes.Count; j++)
                {
                    matRainbow[i, j] = new Rainbow();
                    //אם זה אותו אחד.. צריך לאפס-אלכסון ראשי
                    if (i == j)
                        matRainbow[i, j].distance = double.MaxValue;
                    else
                    //אם זה הצטלבות
                    if (generalNodes[i].typeNode is Intersection)
                    {
                        if (generalNodes[j].typeNode is Storage)
                        {
                            if (generalNodes[i].transitionsList.ToList().FirstOrDefault(x => x.codeTransition == generalNodes[j].transitionsList[0].codeTransition) != null)
                                matRainbow[i, j].distance = distanceStorage(generalNodes[i], generalNodes[j]);
                        }
                        else if (generalNodes[j].typeNode is Intersection)
                            foreach (var item in generalNodes[j].transitionsList)
                            {
                                if (generalNodes[i].transitionsList.ToList().FirstOrDefault(x => x.codeTransition == item.codeTransition) != null)
                                {
                                    matRainbow[i, j].distance = distanceStorage(generalNodes[i], generalNodes[j]);
                                    break;
                                }
                            }
                        if (matRainbow[i, j].distance == 0)
                            matRainbow[i, j].distance = double.MaxValue;
                    }

                    //צומת רגיל-מחסן
                    else
                    {
                        matRainbow[i, j].distance = double.MaxValue;
                        if (generalNodes[j].typeNode is Storage)
                        {
                            //אם הם באותו מעבר
                            if (generalNodes[i].transitionsList[0].codeTransition == generalNodes[j].transitionsList[0].codeTransition)
                            {
                                //עדכון המטריצה
                                matRainbow[i, j].distance = distanceStorage(generalNodes[i], generalNodes[j]);
                            }
                        }
                        else if (generalNodes[j].typeNode is Intersection)
                            foreach (var item in generalNodes[j].transitionsList)
                            {
                                if (generalNodes[i].transitionsList[0].codeTransition == item.codeTransition)
                                {
                                    matRainbow[i, j].distance = distanceStorage(generalNodes[i], generalNodes[j]);
                                    break;
                                }
                            }
                    }
                }
            }

        }

        //פונקציית מרחק בין 2 מחסנים שבאותו המעבר
        public double distanceStorage(Node s1, Node s2)
        {
            double d = Math.Pow((double)(s1.x - s2.x), 2) + Math.Pow((double)(s1.y - s2.y), 2);
            return Math.Round(Math.Sqrt(d), 2);
        }

        //פונקציית מילוי הליסט הסופי
        public string[] init()
        {
            enterNodes[0].Weight = 0;
            //הכנסת הכניסה לליסט הסופי
            finalNodes.Add(enterNodes[0]);
            //מחזיר אמת אם יש אחד שהוא מחסן
            while (enterNodes.Any(x => x.typeNode is Storage))
            {
                buildMat2();
                heap = new MinHeap(enterNodes.Count);
                //שליחה ל בניית ערימת מינימום
                //בונה מערימה ולכן nlogn
                for (int i = 0; i < enterNodes.Count; i++)
                {
                    heap.Add(i);
                }
                //שולח את הקודקוד הנוכחי שהוצאנו עכשיו מהערימה
                Dijkstra();
                //הוצאת המינימום
                Node nn = finalNodes[finalNodes.Count - 1];
                enterNodes.RemoveAt(0);
                if (enterNodes.Any(x => x.typeNode is Storage))
                {
                    double p = enterNodes.Where(p => p.typeNode is Storage).Min(x => x.Weight);
                    int indexMin = enterNodes.IndexOf(enterNodes.FirstOrDefault(x => x.Weight == p && x.typeNode is Storage));
                    int index = indexMin;
                    List<Node> l = new List<Node>();
                    while (enterNodes[index].codeNode != finalNodes[finalNodes.Count - 1].codeNode && enterNodes[index].typeNode.ToString() != finalNodes[finalNodes.Count - 1].typeNode.ToString())
                    {
                        l.Add(enterNodes[index]);
                        if (enterNodes[index].ListNodesPass.Count > 0)
                            index = enterNodes.IndexOf(enterNodes[index].ListNodesPass[0]);
                        if (index == -1)
                        {
                            break;
                        }
                    }
                    l.Reverse();
                    //יצירת אותו קודקוד והוספתו לליסט סופי
                    Node newNode = new Node();
                    newNode.ListNodesPass = l;
                    newNode.typeNode = enterNodes[indexMin].typeNode;
                    newNode.codeNode = enterNodes[indexMin].codeNode;
                    newNode.x = enterNodes[indexMin].x;
                    newNode.y = enterNodes[indexMin].y;
                    finalNodes.Add(newNode);
                }


            }
            drawMap d = new drawMap(finalNodes);
            return d.DrawLineInt(codeOrder1);
        }
        //פונקציית דייקסטרה- נקראת בעבור כל קודקוד
        public void Dijkstra()
        {
            int i = heap.Peek();
            //להפעיל ממנו את הדייקסטרה
            while (!heap.IsEmpty())//כל עוד הערימה אינה ריקה
            {
                for (int j = 0; j < enterNodes.Count; j++)
                    if (ezerRainbow[i, j].distance + enterNodes[i].Weight < enterNodes[j].Weight)
                    {
                        enterNodes[j].Weight = ezerRainbow[i, j].distance + enterNodes[i].Weight;
                        if (enterNodes[j].ListNodesPass.Count > 0)
                            enterNodes[j].ListNodesPass.RemoveAt(0);
                        //if(enterNodes[i].ListNodesPass.Count>0)
                        //    enterNodes[j].ListNodesPass.Add(enterNodes[i].ListNodesPass[0]);
                        enterNodes[j].ListNodesPass.Add(enterNodes[i]);
                    }
                //תיקון ערימה- מתקנת כבר ב שליפה pop
                enterNodes[i].IsPass = true;
                i = heap.Pop();
            }
        }

        //מקבלת קוד הזמנה בודקת באילו מחסנים היא צריכה לעבור , יוצרת רשימה ומתחילה למצוא מסלול קצר
        public string[] matt(List<Storage> storages)
        {
            InitMat();//אתחול הגרף המלא
            FullMat();//מילוי גרף המרחקים המלא
            buildMat1(storages);//שליחה לאיתחול רשימת המחסנים שנרצה לעבור בהם
            return init();
        }

        //+מציאת מסלול+מציאת רשימת המחסנים של הזמנה זו
        public string[] findStorage(int codeOrder)
        {
            codeOrder1 = codeOrder;
            ReadFromExcelToList1("wwwroot/Data/111.csv");
            ReadFromExcelToList2("wwwroot/Data/222.csv");
            using (var Data = new DataProject())
            {
                Storage nn = new Storage();
                nn.CodeStorage = 0;
                nn.NameStorage = "כניסה";
                nn.transition = 1;
                nn.X = 1371;
                nn.Y = 719;
                List<Storage> storagesList = new List<Storage>();
                storagesList.Add(nn);
                Orders o = Data.Orders.FirstOrDefault(p => p.CodeOrder == codeOrder);
                List<ProductsOnOrder> lp = Data.ProductsOnOrder.Where(p => p.CodeOrder == codeOrder).ToList();
                foreach (var item in lp)
                {
                    ProductModels pp = Data.ProductModels.FirstOrDefault(p => p.CodeModel == item.CodeModel);
                    Products p = Data.Products.FirstOrDefault(o => o.CodeProduct == pp.CodeProduct);
                    Storage s = Data.Storage.FirstOrDefault(p1 => p1.CodeStorage == p.CodeStorage);
                    if (storagesList.FirstOrDefault(s1 => s1.CodeStorage == s.CodeStorage) == null)
                    {
                        storagesList.Add(s);
                    }
                }
                return matt(storagesList); ;
            }
        }
    }
}
