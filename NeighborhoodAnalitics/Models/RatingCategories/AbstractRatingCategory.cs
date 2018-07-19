using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborhoodAnalitics.Models
{
    public abstract class AbstractRatingCategory
    {
        public int Distance { get; set; }
        public List<PlaceType> ListOfPlaceTypes { get; private set; } = new List<PlaceType>();
        public abstract decimal Rating();

        public void AddPlaceType(PlaceType place)
        {
            ListOfPlaceTypes.Add(place);
        }
    }

    public class PlaceType
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Adress { get; set; }
        public PlaceType(string name)
        {
            Name = name;
        }
    }
}
