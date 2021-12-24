using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYMSU
{
    class Global
    {
        
        public struct Student
        {
            public string sName;
            public string sNumber;
            public bool bDrawed;
        }

        public static Student[] stuList = new Student[400];
        internal static int iAmount = 0;
    }
}
