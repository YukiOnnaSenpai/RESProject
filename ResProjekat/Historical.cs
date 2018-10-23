using ResProjekat.Interfaces;
using ResProjekat.Model;
using ResProjekat.Model.HistoricalData;
using System;
using System.Collections.Generic;
using System.Xml;

namespace ResProjekat
{

    public class Historical : IHistorical
    {
        public List<Tuple<Codes, int>> buffer;
        public List<Tuple<Codes, int, string>> manualBuffer;
        public HistoricalDescription HD;
        public List<HistoricalDescription> LD;
        public string manual = "manual";
        public bool upisano = false;

        public Historical()
        {
            buffer = new List<Tuple<Codes, int>>();
            LD = new List<HistoricalDescription>();
        }

        public virtual void ReceiveDataFromWritter(Codes code, int value)
        {
            Object locker = new Object();
            lock (locker)
            {
                manualBuffer.Add(new Tuple<Codes, int, string>(code, value, manual));
            }

            //SendDataToReader();

            if (!upisano)
            {
                if (DeltaCD.Add.DataSetBuffer1[0] != null && DeltaCD.Add.DataSetBuffer1[1] != null)
                {
                    WriteToXml1();
                    upisano = true;
                }

            }
        }


            public void WriteToXml1()
            {
                XmlWriter xmlText1 = XmlWriter.Create(@"C:\Users\Wicked Witch\Downloads\Projekat\Projekat\ResProjekat\Xml\DataSet1.xml");

                xmlText1.WriteStartDocument();
                xmlText1.WriteStartElement("DataSetBuffer1");
                xmlText1.WriteStartElement("DataSetBuffer1_0");

                xmlText1.WriteStartElement("Code");
                xmlText1.WriteString(DeltaCD.Add.DataSetBuffer1[0].Code.ToString());
                xmlText1.WriteEndElement();

                xmlText1.WriteStartElement("Value");
                xmlText1.WriteString(DeltaCD.Add.DataSetBuffer1[0].DumpingValue.ToString());
                xmlText1.WriteEndElement();
                xmlText1.WriteEndElement();

                xmlText1.WriteStartElement("DataSetBufffer1_1");

                xmlText1.WriteStartElement("Code");
                xmlText1.WriteString(DeltaCD.Add.DataSetBuffer1[1].Code.ToString());
                xmlText1.WriteEndElement();

                xmlText1.WriteStartElement("Value");
                xmlText1.WriteString(DeltaCD.Add.DataSetBuffer1[1].DumpingValue.ToString());
                xmlText1.WriteEndElement();

                xmlText1.WriteEndDocument();
                xmlText1.Close();
            }

        public void ReceiveDataFromDumpingBuffer(DeltaCD dcd)
                {
                    HistoricalDescription hd = new HistoricalDescription();
                    HistoricalProperty hp1 = new HistoricalProperty();
                    HistoricalProperty hp2 = new HistoricalProperty();
                    HistoricalProperty hp3 = new HistoricalProperty();
                    HistoricalProperty hp4 = new HistoricalProperty();
                    HistoricalProperty hp5 = new HistoricalProperty();

                    HistoricalProperty hp6 = new HistoricalProperty();



                    hd.ID = dcd.TransactionID;


                    foreach (DumpingProperty dp in dcd.collectionDescription.DataSetBuffer1) {
                        hp1.Code = dp.Code;
                        hp1.HistoricalValue = dp.DumpingValue;
                        hd.historicalProperties1.Add(hp1);
                    }


                    foreach (DumpingProperty dp in dcd.collectionDescription.DataSetBuffer2)
                    {
                        hp2.Code = dp.Code;
                        hp2.HistoricalValue = dp.DumpingValue;
                        hd.historicalProperties2.Add(hp2);
                    }


                    foreach (DumpingProperty dp in dcd.collectionDescription.DataSetBuffer3)
                    {
                        hp3.Code = dp.Code;
                        hp3.HistoricalValue = dp.DumpingValue;
                        hd.historicalProperties3.Add(hp3);
                    }


                    foreach (DumpingProperty dp in dcd.collectionDescription.DataSetBuffer4)
                    {
                        hp4.Code = dp.Code;
                        hp4.HistoricalValue = dp.DumpingValue;
                        hd.historicalProperties4.Add(hp4);
                    }


                    foreach (DumpingProperty dp in dcd.collectionDescription.DataSetBuffer5)
                    {
                        hp5.Code = dp.Code;
                        hp5.HistoricalValue = dp.DumpingValue;
                        hd.historicalProperties5.Add(hp5);
                    }
                    foreach (DumpingProperty dp in dcd.collectionDescription.DCollection)
                    {
                        hp6.Code = dp.Code;
                        hp6.HistoricalValue = dp.DumpingValue;
                        hd.HProperties.Add(hp6);
                    }

        }
    }
}
