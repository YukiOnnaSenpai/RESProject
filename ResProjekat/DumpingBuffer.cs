using ResProjekat.Interfaces;
using ResProjekat.Model;
using System;
using System.Collections.Generic;

namespace ResProjekat
{
    public class DumpingBuffer : IDumpingBuffer
    {
        public List<Tuple<Codes, int>> buffer;
        public DumpingProperty dp;
        public CollectionDescription CD;
        private object locker = new object();
        private bool upisano1 = false;
        private DeltaCD DeltaCD;
        private int cameFromWritter;
        private int sentToHistorical;
        private int id = 0;
        private bool sending = false;
        private Historical h = new Historical();
        private List<DumpingProperty> propertiesUnmached;


        public DumpingBuffer()
        {
            buffer = new List<Tuple<Codes, int>>();
            dp = new DumpingProperty();
            CD = new CollectionDescription();
            DeltaCD = new DeltaCD();
        }


        public virtual void ReceiveDataFromWritter(Codes code, int value)
        {
            lock (locker)
            {
                buffer.Add(new Tuple<Codes, int>(code, value));
                dp.Code = code;
                dp.DumpingValue = value;
            }

            Logger l = new Logger();
            l.ReceiveLog("WRITTER", "DUMPINGBUFFER", new Tuple<Codes, int>(code, value));

            GetReadyForHistorical();
        }

        public void GetReadyForHistorical()
        {
            lock (locker)
            {
                if (buffer.Count != 0)
                {
                    CollectionDescriptionAdd(dp);
                    buffer.RemoveAt(0);
                }
            }
        }
        public void CollectionDescriptionUpdate(DumpingProperty dumpingProperty)
        {
            switch (dumpingProperty.Code)
            {
                case Codes.CODE_ANALOG:
                    CD.DataSetBuffer1[0].DumpingValue = dumpingProperty.DumpingValue;
                    break;
                case Codes.CODE_DIGITAL:
                    CD.DataSetBuffer1[1].DumpingValue = dumpingProperty.DumpingValue;
                    break;
                case Codes.CODE_CUSTOM:
                    CD.DataSetBuffer2[0].DumpingValue = dumpingProperty.DumpingValue;
                    break;
                case Codes.CODE_LIMITSET:
                    CD.DataSetBuffer2[1].DumpingValue = dumpingProperty.DumpingValue;
                    break;
                case Codes.CODE_SINGLENODE:
                    CD.DataSetBuffer3[0].DumpingValue = dumpingProperty.DumpingValue;
                    break;
                case Codes.CODE_MULTIPLENODE:
                    CD.DataSetBuffer3[1].DumpingValue = dumpingProperty.DumpingValue;
                    break;
                case Codes.CODE_CONSUMER:
                    CD.DataSetBuffer4[0].DumpingValue = dumpingProperty.DumpingValue;
                    break;
                case Codes.CODE_SOURCE:
                    CD.DataSetBuffer4[1].DumpingValue = dumpingProperty.DumpingValue;
                    break;
                case Codes.CODE_MOTION:
                    CD.DataSetBuffer5[0].DumpingValue = dumpingProperty.DumpingValue;
                    break;
                case Codes.CODE_SENSOR:
                    CD.DataSetBuffer5[1].DumpingValue = dumpingProperty.DumpingValue;
                    break;

            }
        }

        public void CollectionDescriptionRemoveIfAllAreSent(DumpingProperty dp)
        {
            CD.ID = null;
            CD.DataSetBuffer1[0] = null;
            CD.DataSetBuffer1[1] = null;
            CD.DataSetBuffer2[0] = null;
            CD.DataSetBuffer2[1] = null;
            CD.DataSetBuffer3[0] = null;
            CD.DataSetBuffer3[1] = null;
            CD.DataSetBuffer4[0] = null;
            CD.DataSetBuffer4[1] = null;
            CD.DataSetBuffer5[0] = null;
            CD.DataSetBuffer5[1] = null;
            if (propertiesUnmached[0] != null)
            {
                CD.DCollection.Clear();
            }
        }

        public void CollectionDescriptionRemoveIfDSIsFull(DumpingProperty dp)
        {
            CD.ID = null;
            if (dp.Code == Codes.CODE_ANALOG || dp.Code == Codes.CODE_DIGITAL)
            {
                CD.DataSetBuffer1 = null;
            }
            else if (dp.Code == Codes.CODE_CUSTOM || dp.Code == Codes.CODE_LIMITSET)
            {
                CD.DataSetBuffer2 = null;
            }
            else if (dp.Code == Codes.CODE_SINGLENODE || dp.Code == Codes.CODE_MULTIPLENODE)
            {
                CD.DataSetBuffer3 = null;
            }
            else if (dp.Code == Codes.CODE_CONSUMER || dp.Code == Codes.CODE_SOURCE)
            {
                CD.DataSetBuffer4 = null;
            }
            else if (dp.Code == Codes.CODE_MOTION || dp.Code == Codes.CODE_SENSOR)
            {
                CD.DataSetBuffer5 = null;
            }
            else
            {
                throw new FormatException();
            }
        }
        public void CollectionDescriptionAdd(DumpingProperty dumpingProperty)
        {
            if (sending == false)
            {
                checkFill(dumpingProperty);
                cameFromWritter++;
                switch (dumpingProperty.Code)
                {
                    case Codes.CODE_ANALOG:
                        if (CD.DataSetBuffer1[0] == null)
                        {
                            CD.DataSetBuffer1[0] = dumpingProperty;
                        }
                        else
                        {
                            CollectionDescriptionUpdate(dumpingProperty);
                        }
                        break;
                    case Codes.CODE_DIGITAL:
                        if (CD.DataSetBuffer1[1] == null)
                        {
                            CD.DataSetBuffer1[1] = dumpingProperty;
                        }
                        else
                        {
                            CollectionDescriptionUpdate(dumpingProperty);
                        }
                        break;
                    case Codes.CODE_CUSTOM:
                        if (CD.DataSetBuffer2[0] == null)
                        {
                            CD.DataSetBuffer2[0] = dumpingProperty;
                        }
                        else
                        {
                            CollectionDescriptionUpdate(dumpingProperty);
                        }
                        break;
                    case Codes.CODE_LIMITSET:
                        if (CD.DataSetBuffer2[1] == null)
                        {
                            CD.DataSetBuffer2[1] = dumpingProperty;
                        }
                        else
                        {
                            CollectionDescriptionUpdate(dumpingProperty);
                        }
                        break;
                    case Codes.CODE_SINGLENODE:
                        if (CD.DataSetBuffer3[0] == null)
                        {
                            CD.DataSetBuffer3[0] = dumpingProperty;
                        }
                        else
                        {
                            CollectionDescriptionUpdate(dumpingProperty);
                        }
                        break;
                    case Codes.CODE_MULTIPLENODE:
                        if (CD.DataSetBuffer3[1] == null)
                        {
                            CD.DataSetBuffer3[1] = dumpingProperty;
                        }
                        else
                        {
                            CollectionDescriptionUpdate(dumpingProperty);
                        }
                        break;
                    case Codes.CODE_CONSUMER:
                        if (CD.DataSetBuffer4[0] == null)
                        {
                            CD.DataSetBuffer4[0] = dumpingProperty;
                        }
                        else
                        {
                            CollectionDescriptionUpdate(dumpingProperty);
                        }
                        break;
                    case Codes.CODE_SOURCE:
                        if (CD.DataSetBuffer4[1] == null)
                        {
                            CD.DataSetBuffer4[1] = dumpingProperty;
                        }
                        else
                        {
                            CollectionDescriptionUpdate(dumpingProperty);
                        }
                        break;
                    case Codes.CODE_MOTION:
                        if (CD.DataSetBuffer5[0] == null)
                        {
                            CD.DataSetBuffer5[0] = dumpingProperty;
                        }
                        else
                        {
                            CollectionDescriptionUpdate(dumpingProperty);
                        }
                        break;
                    case Codes.CODE_SENSOR:
                        if (CD.DataSetBuffer5[1] == null)
                        {
                            CD.DataSetBuffer5[1] = dumpingProperty;
                        }
                        else
                        {
                            CollectionDescriptionUpdate(dumpingProperty);
                        }
                        break;
                }
            }
            else
            {
                propertiesUnmached.Add(dumpingProperty);
            }

        }

        public CollectionDescription CreateCDForDeltaCD(DumpingProperty dp)
        {
            CollectionDescription collectionDescription = new CollectionDescription();
            collectionDescription.ID = id;
            id++;
            if (propertiesUnmached[0] != null)
            {
                collectionDescription.DCollection.AddRange(propertiesUnmached);
            }
            propertiesUnmached.Clear();
            return collectionDescription;
        }

        public void checkFill(DumpingProperty dp)
        {
            if (CD.DataSetBuffer1[0] != null && CD.DataSetBuffer1[1] != null)
            {
                DeltaCD.TransactionID = id;
                DeltaCD.collectionDescription = CreateCDForDeltaCD(dp);
                h.ReceiveDataFromDumpingBuffer(DeltaCD);
                sending = true;
                cameFromWritter = 0;
            }
            else if (CD.DataSetBuffer2[0] != null && CD.DataSetBuffer2[1] != null)
            {
                DeltaCD.TransactionID = id;
                DeltaCD.collectionDescription = CreateCDForDeltaCD(dp);
                h.ReceiveDataFromDumpingBuffer(DeltaCD);
                sending = true;
                cameFromWritter = 0;
            }
            else if (CD.DataSetBuffer3[0] != null && CD.DataSetBuffer3[1] != null)
            {
                DeltaCD.TransactionID = id;
                DeltaCD.collectionDescription = CreateCDForDeltaCD(dp);
                h.ReceiveDataFromDumpingBuffer(DeltaCD);
                sending = true;
                cameFromWritter = 0;
            }
            else if (CD.DataSetBuffer4[0] != null && CD.DataSetBuffer4[1] != null)
            {
                DeltaCD.TransactionID = id;
                DeltaCD.collectionDescription = CreateCDForDeltaCD(dp);
                h.ReceiveDataFromDumpingBuffer(DeltaCD);
                sending = true;
                cameFromWritter = 0;
            }
            else if (CD.DataSetBuffer5[0] != null && CD.DataSetBuffer5[1] != null)
            {
                DeltaCD.TransactionID = id;
                DeltaCD.collectionDescription = CreateCDForDeltaCD(dp);
                h.ReceiveDataFromDumpingBuffer(DeltaCD);
                sending = true;
                cameFromWritter = 0;
            }
            else if(cameFromWritter == 10)
            {
                DeltaCD.TransactionID = id;
                DeltaCD.collectionDescription = CreateCDForDeltaCD(dp);
                h.ReceiveDataFromDumpingBuffer(DeltaCD);
                sending = true;
                cameFromWritter = 0;
            }
        }

    }
}
