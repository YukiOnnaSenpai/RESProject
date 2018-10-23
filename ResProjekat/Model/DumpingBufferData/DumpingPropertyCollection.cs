using ResProjekat.Model;
using System.Collections.Generic;

namespace ResProjekat
{
    public class DumpingPropertyCollection
    {
        public List<DumpingProperty> listBufferProperty;

        public List<DumpingProperty> GetList()
        {
            if (listBufferProperty.Count == 0)
                return null;

            return listBufferProperty;
        }
    }
}
