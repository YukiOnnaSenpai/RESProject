using ResProjekat.Model;
using System;

namespace ResProjekat.Interfaces
{
    public interface ILogger
    {
        void SentLog(string from, string to, Tuple<Codes, int> data);
        void ReceiveLog(string from, string to, Tuple<Codes, int> data);
    }
}
