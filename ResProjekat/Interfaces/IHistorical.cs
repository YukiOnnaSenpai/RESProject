using ResProjekat.Model;

namespace ResProjekat.Interfaces
{
    public interface IHistorical
    {
        void ReceiveDataFromWritter(Codes code, int value);
        void ReceiveDataFromDumpingBuffer(DeltaCD dcd);
    }
}
