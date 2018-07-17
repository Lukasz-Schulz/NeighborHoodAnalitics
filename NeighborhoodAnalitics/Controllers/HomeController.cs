using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeighborhoodAnalitics.Models;

namespace NeighborhoodAnalitics.Controllers
{
    public class HomeController : Controller
    {
        public PlaceQuantitySearcher quantitySearcher;


        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Map(string placeName, string ratingCategory)
        {
            AbstractRatingCategory live = new LivingRatingCategory();
            AbstractRatingCategory travel = new TouristicRatingCategory();
            AbstractRatingCategory chosenCategory;

            if (ratingCategory == "live")
            {
                chosenCategory = live;
            }
            else if (ratingCategory == "travel")
            {
                chosenCategory = travel;
            }
            else
            {
                chosenCategory = travel;
            }

            quantitySearcher = new PlaceQuantitySearcher();
            quantitySearcher.FillPlaceQuantities(placeName, chosenCategory);

            return View(chosenCategory);
        }
        

    }
}
