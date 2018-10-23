using ResProjekat.Interfaces;
using ResProjekat.Model;
using System;
using System.IO;

namespace ResProjekat
{
    public class Logger : ILogger
    {
        private Object locker = new Object();

        public void ReceiveLog(string from, string to, Tuple<Codes, int> data)
        {
            lock (locker)
            {
                using (StreamWriter file = new StreamWriter(@"C:\Users\Wicked Witch\Downloads\Projekat\Projekat\ResProjekat\Loger\Log.txt", true))
                {
                    file.WriteLine("Data receive from: " + from + " to: " + to + " with content: CODE: " + data.Item1 + " ,VALUE: " + data.Item2 + " ,timestamp: " + DateTime.Now);
                }
            }
        }

        public void SentLog(string from, string to, Tuple<Codes, int> data)
        {
            lock (locker)
            {
                using (StreamWriter file = new StreamWriter(@"C:\Users\Wicked Witch\Downloads\Projekat\Projekat\ResProjekat\Loger\Log.txt", true))
                {
                    file.WriteLine("Data sent from: " + from + " to: " + to + " with content: CODE: " + data.Item1 + " ,VALUE: " + data.Item2 + " ,timestamp: " + DateTime.Now);
                }
            }
        }
    }
}
