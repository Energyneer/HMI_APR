using HMI_APR3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace HMI_APR3.Simulation
{
    class Simul
    {
        private Random rnd = new Random();
        private int reqSheetNumber;
        private int reqSheetLenght;
        private int reqSheetCoil;
        private double dxShears;
        private int rndThrow = 1;
        private Canvas Canvas;

        public Simul(Canvas canvas)
        {
            Canvas = canvas;
            
        }

        public void Cycle20ms(object sender, EventArgs e)
        {
            GenSpeeds();
            ReqSheets();
            GenerateSheet();
            Moving();
            Transfer();
            ThrowSheets();
        }

        private void GenSpeeds()
        {
            double tmp = L1_Data.Speeds[0] + rnd.Next(-25, 25);
            L1_Data.Speeds[0] = tmp < 2000 ? 2000 : tmp > 2500 ? 2500 : tmp;

            for (int i = 1; i < L1_Data.Speeds.Length; i++)
            {
                tmp = L1_Data.Speeds[i] + rnd.Next(-25, 25);
                L1_Data.Speeds[i] = tmp < 2500 ? 2500 : tmp > 3000 ? 3000 : tmp;
            }
        }

        private void ReqSheets()
        {
            if (L1_Data.ActSheetNumber >= reqSheetCoil)
            {
                NewReqCoil();
            }
            if (L1_Data.ActSheetNumber >= reqSheetNumber)
            {
                NewReqSheet();

            }
        }

        private void NewReqSheet()
        {
            reqSheetNumber += rnd.Next(3, 6);
            reqSheetLenght = 2000 + rnd.Next(0, 8) * 500;
        }

        private void NewReqCoil()
        {
            reqSheetCoil = 150 + rnd.Next(0, 200);
            L1_Data.ActSheetNumber = 0;
        }

        private void GenerateSheet()
        {
            dxShears += L1_Data.Speeds[0] / 40.0;
            if (dxShears > reqSheetLenght)
            {
                if (L1_Data.Counters[0] >= 0 && L1_Data.Counters[0] < 14)
                    L1_Data.TranspSheet[L1_Data.Counters[0]++] = new Sheet(++L1_Data.ActSheetNumber, reqSheetLenght, 0, reqSheetLenght);
                dxShears = - 1500;
            }
        }

        private void Moving()
        {
            for (int i = 0; i < L1_Data.TranspSheet.Length; i++)
            {
                if (L1_Data.TranspSheet[i] != null)
                    L1_Data.TranspSheet[i].Position += L1_Data.Speeds[0] / 40.0;
            }

            for (int i = 0; i < L1_Data.Lu1Sheets.Length; i++)
            {
                if (L1_Data.Lu1Sheets[i] != null)
                    L1_Data.Lu1Sheets[i].Position += L1_Data.Speeds[1] / 40.0;

                if (L1_Data.Lu2Sheets[i] != null)
                    L1_Data.Lu2Sheets[i].Position += L1_Data.Speeds[2] / 40.0;

                if (L1_Data.Lu3Sheets[i] != null)
                    L1_Data.Lu3Sheets[i].Position += L1_Data.Speeds[3] / 40.0;
            }
        }

        private void Transfer()
        {
            for (int i = 0; i < L1_Data.TranspSheet.Length; i++)
            {
                if (L1_Data.TranspSheet[i] != null && L1_Data.TranspSheet[i].Position > 16000 && L1_Data.Counters[1] < L1_Data.Lu1Sheets.Length)
                    Transp(1);
            }

            for (int i = 0; i < L1_Data.Lu1Sheets.Length; i++)
            {
                if (L1_Data.Lu1Sheets[i] != null && L1_Data.Lu1Sheets[i].Position > 12500 && L1_Data.Counters[2] < L1_Data.Lu2Sheets.Length)
                    Transp(2);

                if (L1_Data.Lu2Sheets[i] != null && L1_Data.Lu2Sheets[i].Position > 12500 && L1_Data.Counters[3] < L1_Data.Lu3Sheets.Length)
                    Transp(3);
            }
        }

        private void Transp(int count)
        {
            switch (count)
            {
                case 1: 
                    L1_Data.Lu1Sheets[L1_Data.Counters[1]] = L1_Data.TranspSheet[0];
                    L1_Data.Lu1Sheets[L1_Data.Counters[1]++].Position = 0;
                    for (int i = 0; i < L1_Data.Counters[0]; i++)
                    {
                        L1_Data.TranspSheet[i] = L1_Data.TranspSheet[i + 1];
                    }
                    L1_Data.TranspSheet[L1_Data.Counters[0]--] = null;
                    break;

                case 2:
                    L1_Data.Lu2Sheets[L1_Data.Counters[2]] = L1_Data.Lu1Sheets[0];
                    L1_Data.Lu2Sheets[L1_Data.Counters[2]++].Position = 0;
                    for (int i = 0; i < L1_Data.Counters[1]; i++)
                    {
                        L1_Data.Lu1Sheets[i] = L1_Data.Lu1Sheets[i + 1];
                    }
                    L1_Data.Lu1Sheets[L1_Data.Counters[1]--] = null;
                    break;

                case 3:
                    L1_Data.Lu3Sheets[L1_Data.Counters[3]] = L1_Data.Lu2Sheets[0];
                    L1_Data.Lu3Sheets[L1_Data.Counters[3]++].Position = 0;
                    for (int i = 0; i < L1_Data.Counters[2]; i++)
                    {
                        L1_Data.Lu2Sheets[i] = L1_Data.Lu2Sheets[i + 1];
                    }
                    L1_Data.Lu2Sheets[L1_Data.Counters[2]--] = null;
                    break;
            }


            /*L1_Data.Lu1Sheets[0].Number = L1_Data.TranspSheet[0].Number;
            L1_Data.Lu1Sheets[0].Lenght = L1_Data.TranspSheet[0].Lenght;
            L1_Data.Lu1Sheets[0].Offset = L1_Data.TranspSheet[0].Offset;
            L1_Data.Lu1Sheets[0].Position = 0;
            L1_Data.TranspSheet[0].Position = 0;*/


        }

        private void ThrowSheets()
        {
            RandomThrow();

            for (int i = 0; i < L1_Data.Lu3Sheets.Length; i++)
            {
                if (L1_Data.Lu3Sheets[i] != null && L1_Data.Lu3Sheets[i].Position > 8000)
                {
                    Throw(3);
                    L1_Data.InPacket[2]++;
                }
            }
        }

        private void RandomThrow()
        {
            switch (rndThrow)
            {
                case 1:
                    if (L1_Data.Lu1Sheets[0] != null && L1_Data.Lu1Sheets[0].Position > 6000 && L1_Data.Lu1Sheets[0].Position < 7000)
                    {
                        Throw(1);
                        L1_Data.InPacket[0]++;
                        rndThrow = rnd.Next(1, 4);
                    }
                    break;

                case 2:
                    if (L1_Data.Lu2Sheets[0] != null && L1_Data.Lu2Sheets[0].Position > 6000 && L1_Data.Lu2Sheets[0].Position < 7000)
                    {
                        Throw(2);
                        L1_Data.InPacket[1]++;
                        rndThrow = rnd.Next(1, 4);
                    }
                    break;

                case 3:
                    if (L1_Data.Lu3Sheets[0] != null && L1_Data.Lu3Sheets[0].Position > 6000 && L1_Data.Lu3Sheets[0].Position < 7000)
                    {
                        Throw(3);
                        L1_Data.InPacket[2]++;
                        rndThrow = rnd.Next(1, 4);
                    }
                    break;
            }
        }

        private void Throw(int luNumber)
        {
            switch (luNumber)
            {
                case 1:
                    ThrowsMoving();
                    L1_Data.Lu1Throws[0] = L1_Data.Lu1Sheets[0];
                    for(int i = 0; i < L1_Data.Lu1Sheets.Length - 1; i++)
                    {
                        L1_Data.Lu1Sheets[i] = L1_Data.Lu1Sheets[i + 1];
                    }
                    L1_Data.Lu1Sheets[L1_Data.Counters[1]--] = null;
                    break;

                case 2:
                    ThrowsMoving();
                    L1_Data.Lu2Throws[0] = L1_Data.Lu2Sheets[0];
                    for (int i = 0; i < L1_Data.Lu2Sheets.Length - 1; i++)
                    {
                        L1_Data.Lu2Sheets[i] = L1_Data.Lu2Sheets[i + 1];
                    }
                    L1_Data.Lu2Sheets[L1_Data.Counters[2]--] = null;
                    break;

                case 3:
                    ThrowsMoving();
                    L1_Data.Lu3Throws[0] = L1_Data.Lu3Sheets[0];
                    for (int i = 0; i < L1_Data.Lu3Sheets.Length - 1; i++)
                    {
                        L1_Data.Lu3Sheets[i] = L1_Data.Lu3Sheets[i + 1];
                    }
                    L1_Data.Lu3Sheets[L1_Data.Counters[3]--] = null;
                    break;
            }
        }

        private void ThrowsMoving()
        {
            for (int i = L1_Data.Lu1Throws.Length - 1; i > 0; i--)
            {
                L1_Data.Lu1Throws[i] = L1_Data.Lu1Throws[i - 1];
                L1_Data.Lu2Throws[i] = L1_Data.Lu2Throws[i - 1];
                L1_Data.Lu3Throws[i] = L1_Data.Lu3Throws[i - 1];
            }
            L1_Data.Lu1Throws[0] = null;
            L1_Data.Lu2Throws[0] = null;
            L1_Data.Lu3Throws[0] = null;
        }
    }
}
