using System;
using System.Threading;

namespace ResProjekat
{
    class Program
    {
        public static Writter w = new Writter();
        public static DumpingBuffer dp = new DumpingBuffer();
        public static void Main(string[] args)
        {
            Thread t = new Thread(w.WriteToDumpingBuffer)
            {
                IsBackground = true
            };

            t.Start();

            //Console.ReadLine();

            /*XmlReader reader = XmlReader.Create(@"C:\Users\GornHunter\Desktop\IT_Engine\ResProjekat\Xml\DataSet1.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    Console.WriteLine(reader.Value);
                }
            }*/

            //Console.WriteLine("Hello world!");

            Console.ReadLine();
        }
    }
}
