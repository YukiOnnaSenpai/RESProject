using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjekat.Model
{
    public class DumpingProperty
    {
        public Codes Code { get; set; }
        public int DumpingValue { get; set; }

        public DumpingProperty(Codes codes, int values) {
            this.Code = codes;
            this.DumpingValue = values;
        }

        public DumpingProperty() {

        }

        public override string ToString()
        {
            return Code + " " + DumpingValue;
        }
    }
}
