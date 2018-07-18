namespace NeighborhoodAnalitics.Models
{
    public class Place
    {
        public Candidates[] candidates = { new Candidates()};
        public string Name
        {
            get
            {
                 return candidates[0].name;
            }
        }
        public string Coordinates
        {
            get
            {
                if(candidates.Length > 0)
                {
                    string coordinates = string.Empty;
                    coordinates += candidates[0].geometry.location.lat.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    coordinates += ", ";
                    coordinates += candidates[0].geometry.location.lng.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    return coordinates;
                }
                else
                {
                    return "0,0";
                }
            }
        }
    }
}
