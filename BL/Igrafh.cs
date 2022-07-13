using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
   public interface Igrafh
    {
        //קריאת קובץ אקסל-מחסנים
        public void ReadFromExcelToList1(string fileName);
        //קריאת קובץ אקסל-הצטלבויות
        public void ReadFromExcelToList2(string fileName);

        //+מציאת מסלול+מציאת רשימת המחסנים של הזמנה זו
        public string[] findStorage(int codeOrder);
    }
}
