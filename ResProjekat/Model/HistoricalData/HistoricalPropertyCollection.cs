using ResProjekat.Model.HistoricalData;
using System.Collections.Generic;

namespace ResProjekat
{
    public class HistoricalPropertyCollection
    {
        public List<HistoricalProperty> listHistoricalProperty;

        public HistoricalPropertyCollection()
        {
            listHistoricalProperty = new List<HistoricalProperty>();
        }

        public void AddToList(HistoricalProperty hp)
        {
            listHistoricalProperty.Add(hp);
        }

        public void RemoveFromList(HistoricalProperty hp)
        {
            listHistoricalProperty.Remove(hp);
        }

        public List<HistoricalProperty> GetList()
        {
            if (listHistoricalProperty.Count == 0)
                return null;

            return listHistoricalProperty;
        }
    }
}
