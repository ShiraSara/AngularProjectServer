using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public static class sendEmail
    {
        public static void Func(string adressMail,string pas)
        {
            Email.SendEmail(adressMail, "שחזור סיסמת כניסה", "הסיסמא שלך היא:"+"    "+pas+"תודה ולהתראות");
        }


    }
}
