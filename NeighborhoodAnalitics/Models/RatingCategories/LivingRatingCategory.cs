namespace NeighborhoodAnalitics.Models
{
    public class LivingRatingCategory : AbstractRatingCategory
    {
        public LivingRatingCategory()
        {
            AddPlaceType(new PlaceType("bakery"));
            AddPlaceType(new PlaceType("church"));
            AddPlaceType(new PlaceType("doctor"));
            AddPlaceType(new PlaceType("pharmacy"));
            AddPlaceType(new PlaceType("school"));
            AddPlaceType(new PlaceType("store"));

            //AddPlaceType(new PlaceType("gas_station"));
            //AddPlaceType(new PlaceType("library"));
            //AddPlaceType(new PlaceType("park"));
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
        //    for(int i = 0; i < 5; i++)
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
        //    for(int i = 6; i < 8; i++)
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
