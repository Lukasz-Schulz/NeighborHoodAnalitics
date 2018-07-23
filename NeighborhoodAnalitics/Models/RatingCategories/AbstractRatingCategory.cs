using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborhoodAnalitics.Models
{
    public abstract class AbstractRatingCategory
    {
        public string SearchedPlaceName { get; private set; }
        public List<PlaceType> ListOfPlaceTypes { get; private set; } = new List<PlaceType>();
        public abstract decimal Rating();
        public string Lat { get; set; }
        public string Lng { get; set; }

        public void AddPlaceType(PlaceType place)
        {
            ListOfPlaceTypes.Add(place);
        }

        public void SetPlaceName(string name)
        {
            SearchedPlaceName = name;
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
