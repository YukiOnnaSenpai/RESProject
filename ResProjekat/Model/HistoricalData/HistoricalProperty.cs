using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjekat.Model.HistoricalData
{
    public class HistoricalProperty
    {
        private int value;
        public Codes Code { get; set; }
        public int HistoricalValue { get; set; }

        public HistoricalProperty(Codes code, int value)
        {
            Code = code;
            this.value = value;
        }

        public HistoricalProperty() { }
        public override string ToString()
        {
            return Code + " " + HistoricalValue;
        }
    }
}
