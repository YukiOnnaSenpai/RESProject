using ResProjekat.Interfaces;
using ResProjekat.Model;
using ResProjekat.Model.HistoricalData;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ResProjekat
{
    public class Writter : IWritter
    {
        public Codes Code { get; set; }
        public int Value { get; set; }

        public DumpingBuffer dp = new DumpingBuffer();
        private int i = 0;
        private List<Codes> buffer = new List<Codes>();

        public void WriteToDumpingBuffer()
        {
            while (true)
            {
                Array codes = Enum.GetValues(typeof(Codes));
                Random rnd = new Random();

                Code = (Codes)codes.GetValue(rnd.Next(codes.Length));
                Value = rnd.Next(1000);

                Console.WriteLine("Code - " + Code);
                Console.WriteLine("Value - " + Value + '\n');

                Logger l = new Logger();
                l.SentLog("WRITER", "DUMPINGBUFFER", new Tuple<Codes, int>(this.Code, this.Value));

                dp.ReceiveDataFromWritter(this.Code, Value);
                buffer.Add(Code);
                i++;

                if(i % 10 == 0)
                {
                    foreach (Codes c in buffer) {
                        if (buffer.Contains(c))
                        {
                            while (true)
                            {
                                Console.WriteLine("Da li zelite da rucno upisete podatke?(Da/Ne)\n");
                                string response = Console.ReadLine();
                                if (response.Equals("Da"))
                                {
                                    ManualWriteToHistory();
                                }
                                else if (response.Equals("Ne"))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Pogresan unos");
                                    break;
                                }
                                break;
                            }
                        }
                    }
                }

                Thread.Sleep(2000);
            }
        }

        public void ManualWriteToHistory()
        {
            Console.WriteLine("Unesite Code vrednost: ");
            object unosCode = Console.ReadLine().ToString();
            Console.WriteLine("Unesite Value vrednost: ");
            int unosValue = Int32.Parse(Console.ReadLine());

            if (unosCode.Equals((typeof(Codes))))
            {
                HistoricalProperty hd = new HistoricalProperty((Codes)unosCode,unosValue);      
            }
            else {
                Console.WriteLine("Uneti Code ne pripada listi validnih Code-ova");
            }
            Logger l = new Logger();
            l.SentLog("WRITER", "REPLICATORSENDER", new Tuple<Codes, int>((Codes)unosCode, unosValue));

        }
    }
}
