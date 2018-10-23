using ResProjekat.Model;

namespace ResProjekat.Interfaces
{
    public interface IDumpingBuffer
    {
        void ReceiveDataFromWritter(Codes code, int value);
        //void FillUpCD(DumpingProperty dp);

        //DumpingProperty[] CheckBuffer(Codes c1, Codes c2);
        void GetReadyForHistorical();
        //void SendDataToHistorical();
    }
}
