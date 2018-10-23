using ResProjekat.Model.HistoricalData;
using System.Collections.Generic;

namespace ResProjekat
{
    public class HistoricalDescription
    {
        public int ID { get; set; }

        public List<HistoricalProperty> HProperties { get; set; }

        public List<HistoricalProperty> historicalProperties1;
        public List<HistoricalProperty> historicalProperties2;
        public List<HistoricalProperty> historicalProperties3;
        public List<HistoricalProperty> historicalProperties4;
        public List<HistoricalProperty> historicalProperties5;


        // public HistoricalPropertyCollection HCollection { get; set; }

        public HistoricalDescription()
        {
            historicalProperties1 = new List<HistoricalProperty>();
            historicalProperties2 = new List<HistoricalProperty>();
            historicalProperties3 = new List<HistoricalProperty>();
            historicalProperties4 = new List<HistoricalProperty>();
            historicalProperties5 = new List<HistoricalProperty>();

            HProperties = new List<HistoricalProperty>();

           // HCollection = new HistoricalPropertyCollection();
        }
    }
}
