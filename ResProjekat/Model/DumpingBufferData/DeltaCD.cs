using ResProjekat.Model;
using System.Collections.Generic;

namespace ResProjekat
{
    public class DeltaCD
    {
        public int TransactionID { get; set; }
        public CollectionDescription collectionDescription { get; set; }

        /*public CollectionDescription Add { get; set; }
        public CollectionDescription Update { get; set; }
        public CollectionDescription Remove { get; set; }
        */

        public DeltaCD()
        {
            collectionDescription = new CollectionDescription();
           /* Add = new List<CollectionDescription>();
            Update = new List<CollectionDescription>();
            Remove = new List<CollectionDescription>();*/
        }
    }
}
