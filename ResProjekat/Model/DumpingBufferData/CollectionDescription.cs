using ResProjekat.Model;
using System.Collections.Generic;

namespace ResProjekat
{
    public class CollectionDescription
    {

        public int? ID {get; set;}
        public List<DumpingProperty> DCollection { get; set; }
        //public DumpingProperty[] DumpingProperties { get; set; }
       // public int[] Id { get; set; }

        public DumpingProperty[] DataSetBuffer1;
        public DumpingProperty[] DataSetBuffer2;
        public DumpingProperty[] DataSetBuffer3;
        public DumpingProperty[] DataSetBuffer4;
        public DumpingProperty[] DataSetBuffer5;

        //public DumpingPropertyCollection DCollection { get; set; }

        public CollectionDescription()
        {
            //Id = new int[5];

            DataSetBuffer1 = new DumpingProperty[] { null, null };
            DataSetBuffer2 = new DumpingProperty[] { null, null };
            DataSetBuffer3 = new DumpingProperty[] { null, null };
            DataSetBuffer4 = new DumpingProperty[] { null, null };
            DataSetBuffer5 = new DumpingProperty[] { null, null };
            DCollection = new List<DumpingProperty>();
        }
    }
}
