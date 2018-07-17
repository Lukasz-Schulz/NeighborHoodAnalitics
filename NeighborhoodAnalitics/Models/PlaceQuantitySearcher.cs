namespace NeighborhoodAnalitics.Models
{
    public class PlaceQuantitySearcher
    {
        public RequestSender GoogleRequestSender = new RequestSender();
        public void FillPlaceQuantities(string placeName, AbstractRatingCategory ratingCategory)
        {
            Place placeToAnalize = GoogleRequestSender.GetLocalisationByName(placeName);

            for(int i = 0; i < ratingCategory.ListOfPlaceTypes.Count; i++)
            {
                ListOfResults listOfResults =  GoogleRequestSender.FindNear(placeToAnalize, ratingCategory.ListOfPlaceTypes[i].Name);
                ratingCategory.ListOfPlaceTypes[i].Quantity = listOfResults.results.Length;                
            }
        }
    }
}
