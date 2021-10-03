using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMI_APR3.Model
{
    class L1_Data
    {
        public static Sheet[] TranspSheet { get; set; }
        public static Sheet[] Lu1Sheets { get; set; }
        public static Sheet[] Lu2Sheets { get; set; }
        public static Sheet[] Lu3Sheets { get; set; }
        public static Sheet[] Lu1Throws { get; set; }
        public static Sheet[] Lu2Throws { get; set; }
        public static Sheet[] Lu3Throws { get; set; }
        public static double[] Speeds { get; set; }
        public static int[] Counters { get; set; }
        public static int ActSheetNumber { get; set; }
        public static bool[] BFS { get; set; }
        public static int ID_Coil { get; set; }
        public static int[] InPacket { get; set; }

        static L1_Data()
        {
            TranspSheet = new Sheet[15];
            Lu1Sheets = new Sheet[7];
            Lu2Sheets = new Sheet[7];
            Lu3Sheets = new Sheet[7];
            Lu1Throws = new Sheet[10];
            Lu2Throws = new Sheet[10];
            Lu3Throws = new Sheet[10];
            Speeds = new double[4];
            Counters = new int[4];
            BFS = new bool[4];
            ID_Coil = 1;
            InPacket = new int[3];
        }
    }
}
