namespace NeighborhoodAnalitics.Models
{
    public class TouristicRatingCategory : AbstractRatingCategory
    {
        public TouristicRatingCategory()
        {
            AddPlaceType(new PlaceType("restaurant"));

            AddPlaceType(new PlaceType("train_station"));
            AddPlaceType(new PlaceType("embassy"));
            AddPlaceType(new PlaceType("art_gallery"));
            AddPlaceType(new PlaceType("spa"));
            AddPlaceType(new PlaceType("park"));
            //AddPlaceType(new PlaceType("pharmacy"));
            //AddPlaceType(new PlaceType("travel_agency"));
            //AddPlaceType(new PlaceType("museum"));            
        }
        public override decimal Rating()
        {
            decimal rating = 0;
            if (ListOfPlaceTypes[0].Quantity > 0 && ListOfPlaceTypes[0].Quantity < 3)
            {
                rating++;
            }
            if (ListOfPlaceTypes[0].Quantity >= 3)
            {
                rating += 2;
            }
            if (ListOfPlaceTypes[1].Quantity > 0)
            {
                rating++;
            }
            return rating;
        }

        //public override decimal Rating()
        //{
        //    decimal rating = 0;
        //    for(int i = 0; i < 1; i++)
        //    {
        //        if (ListOfPlaceTypes[i].Quantity > 0 && ListOfPlaceTypes[i].Quantity < 3)
        //        {
        //            rating++;
        //        }
        //        if (ListOfPlaceTypes[i].Quantity >= 3)
        //        {
        //            rating += 2;
        //        }
        //    }
        //    for(int i = 1; i < 8; i++)
        //    {
        //        if (ListOfPlaceTypes[1].Quantity > 0)
        //        {
        //            rating += 2;
        //        }
        //    }
        //    return rating;
        //}
    }
}