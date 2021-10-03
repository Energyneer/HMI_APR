using HMI_APR3.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMI_APR3.Model
{
    class ViewRefreshLogic
    {
        private ArmViewModel arl;
        private int ddd;

        public ViewRefreshLogic(ArmViewModel arl)
        {
            this.arl = arl;
        }

        public void ViewRefresh(object sender, EventArgs e)
        {
            Speeds();
            TranspSheets();
            SectionSheets();
            ThrowsSheets();
        }

        private void Speeds()
        {
            arl.Status.TranspCounter = L1_Data.Counters[0].ToString();
            arl.Status.Lu1Counter = L1_Data.Counters[1].ToString();
            arl.Status.Lu2Counter = L1_Data.Counters[2].ToString();
            arl.Status.Lu3Counter = L1_Data.Counters[3].ToString();
            arl.Status.ShSpeed = L1_Data.Speeds[0].ToString();
            arl.Status.Lu1Speed = L1_Data.Speeds[1].ToString();
            arl.Status.Lu2Speed = L1_Data.Speeds[2].ToString();
            arl.Status.Lu3Speed = L1_Data.Speeds[3].ToString();
        }

        private void TranspSheets()
        {
            for (int i = 0; i < arl.TranspSheets.Length; i++)
            {
                if (L1_Data.TranspSheet[i] != null)
                {
                    int lenght = L1_Data.TranspSheet[i].Lenght < 1250 ? 50 :
                        L1_Data.TranspSheet[i].Lenght > 6000 ? 240 : (int)L1_Data.TranspSheet[i].Lenght / 25;
                    int offset = 1150 + (lenght - 40) / 2;

                    arl.TranspSheets[i].Number = L1_Data.TranspSheet[i].Number.ToString();
                    arl.TranspSheets[i].Offset = ((int)L1_Data.TranspSheet[i].Lenght).ToString();
                    arl.TranspSheets[i].Lenght = lenght;
                    arl.TranspSheets[i].PosLenght = offset;
                }
                else
                {
                    arl.TranspSheets[i].Number = "";
                    arl.TranspSheets[i].Offset = "";
                    arl.TranspSheets[i].Lenght = 0;
                    arl.TranspSheets[i].PosLenght = 0;
                }
            }
        }

        private void SectionSheets()
        {
            for (int i = 0; i < arl.Lu1Sheets.Length; i++)
            {
                // Lu1
                if (L1_Data.Lu1Sheets[i] == null)
                {
                    arl.Lu1Sheets[i].Number = "";
                    arl.Lu1Sheets[i].Offset = "";
                    arl.Lu1Sheets[i].Lenght = 0;
                    arl.Lu1Sheets[i].Position = 0;
                }
                else
                {
                    arl.Lu1Sheets[i].Number = L1_Data.Lu1Sheets[i].Number.ToString();
                    arl.Lu1Sheets[i].Offset = ((int)L1_Data.Lu1Sheets[i].Position).ToString();
                    int lenght = (int)(L1_Data.Lu1Sheets[i].Lenght / 34.0);
                    int position = L1_Data.Lu1Sheets[i].Position < 0 ? 0 :
                        L1_Data.Lu1Sheets[i].Position > 12240 ? 360 : (int)(L1_Data.Lu1Sheets[i].Position / 34.0);
                    arl.Lu1Sheets[i].Position = 1090 - position;
                    arl.Lu1Sheets[i].Lenght = lenght > position ? position : lenght;
                }

                // Lu2
                if (L1_Data.Lu2Sheets[i] == null)
                {
                    arl.Lu2Sheets[i].Number = "";
                    arl.Lu2Sheets[i].Offset = "";
                    arl.Lu2Sheets[i].Lenght = 0;
                    arl.Lu2Sheets[i].Position = 0;
                }
                else
                {
                    arl.Lu2Sheets[i].Number = L1_Data.Lu2Sheets[i].Number.ToString();
                    arl.Lu2Sheets[i].Offset = ((int)L1_Data.Lu2Sheets[i].Position).ToString();
                    int lenght = (int)(L1_Data.Lu2Sheets[i].Lenght / 34.0);
                    int position = L1_Data.Lu2Sheets[i].Position < 0 ? 0 :
                        L1_Data.Lu2Sheets[i].Position > 12240 ? 360 : (int)(L1_Data.Lu2Sheets[i].Position / 34.0);
                    arl.Lu2Sheets[i].Position = 730 - position;
                    arl.Lu2Sheets[i].Lenght = lenght;// lenght > position ? position : lenght;
                }

                // Lu3
                if (L1_Data.Lu3Sheets[i] == null)
                {
                    arl.Lu3Sheets[i].Number = "";
                    arl.Lu3Sheets[i].Offset = "";
                    arl.Lu3Sheets[i].Lenght = 0;
                    arl.Lu3Sheets[i].Position = 0;
                }
                else
                {
                    arl.Lu3Sheets[i].Number = L1_Data.Lu3Sheets[i].Number.ToString();
                    arl.Lu3Sheets[i].Offset = ((int)L1_Data.Lu3Sheets[i].Position).ToString();
                    int lenght = (int)(L1_Data.Lu3Sheets[i].Lenght / 34.0);
                    int position = L1_Data.Lu3Sheets[i].Position < 0 ? 0 :
                        L1_Data.Lu3Sheets[i].Position > 12240 ? 360 : (int)(L1_Data.Lu3Sheets[i].Position / 34.0);
                    arl.Lu3Sheets[i].Position = 370 - position;
                    arl.Lu3Sheets[i].Lenght = lenght;// > position ? position : lenght;
                }
            }
        }

        private void ThrowsSheets()
        {
            for (int i = 0; i < arl.Throws.Length; i ++)
            {
                if (L1_Data.Lu1Throws[i] != null)
                {
                    arl.Throws[i].Number = L1_Data.Lu1Throws[i].Number.ToString();
                    arl.Throws[i].Offset = ((int) L1_Data.Lu1Throws[i].Lenght).ToString();
                    int lenght = (int) (L1_Data.Lu1Throws[i].Lenght / 20.0);
                    arl.Throws[i].Lenght = lenght < 50 ? 50 : lenght > 300 ? 300 : lenght;
                    arl.Throws[i].Position = 770;
                    arl.Throws[i].PosNumber = 735;
                    arl.Throws[i].PosLenght = (arl.Throws[i].Lenght - 40) / 2 + 770;
                    continue;
                }

                if (L1_Data.Lu2Throws[i] != null)
                {
                    arl.Throws[i].Number = L1_Data.Lu2Throws[i].Number.ToString();
                    arl.Throws[i].Offset = ((int)L1_Data.Lu2Throws[i].Lenght).ToString();
                    int lenght = (int)(L1_Data.Lu2Throws[i].Lenght / 20.0);
                    arl.Throws[i].Lenght = lenght < 50 ? 50 : lenght > 300 ? 300 : lenght;
                    arl.Throws[i].Position = 410;
                    arl.Throws[i].PosNumber = 375;
                    arl.Throws[i].PosLenght = (arl.Throws[i].Lenght - 40) / 2 + 410;
                    continue;
                }

                if (L1_Data.Lu3Throws[i] != null)
                {
                    arl.Throws[i].Number = L1_Data.Lu3Throws[i].Number.ToString();
                    arl.Throws[i].Offset = ((int)L1_Data.Lu3Throws[i].Lenght).ToString();
                    int lenght = (int)(L1_Data.Lu3Throws[i].Lenght / 20.0);
                    arl.Throws[i].Lenght = lenght < 50 ? 50 : lenght > 300 ? 300 : lenght;
                    arl.Throws[i].Position = 50;
                    arl.Throws[i].PosNumber = 15;
                    arl.Throws[i].PosLenght = (arl.Throws[i].Lenght - 40) / 2 + 50;
                    continue;
                }

                arl.Throws[i].Number = "";
                arl.Throws[i].Offset = "";
                arl.Throws[i].Lenght = 0;
                arl.Throws[i].Position = 0;
                arl.Throws[i].PosLenght = 0;
                arl.Throws[i].PosNumber = 0;
            }

            arl.Status.InPacket1 = L1_Data.InPacket[0].ToString();
            arl.Status.InPacket2 = L1_Data.InPacket[1].ToString();
            arl.Status.InPacket3 = L1_Data.InPacket[2].ToString();
            arl.Status.ActSheetNumber = L1_Data.ActSheetNumber.ToString();
            
            
        }
    }
}
