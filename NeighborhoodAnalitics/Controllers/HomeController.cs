using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeighborhoodAnalitics.Models;
using Newtonsoft.Json;

namespace NeighborhoodAnalitics.Controllers
{
    public class HomeController : Controller
    {
        public PlaceQuantitySearcher quantitySearcher;


        public IActionResult Index()
        {
            return View(new LivingRatingCategory());
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            quantitySearcher = new PlaceQuantitySearcher();

            AbstractRatingCategory live = new LivingRatingCategory();
            AbstractRatingCategory travel = new TouristicRatingCategory();
            AbstractRatingCategory chosenCategory;
            string category = form["category"];
            if (category == "live")
            {
                chosenCategory = live;
            }
            else if (category == "travel")
            {
                chosenCategory = travel;
            }
            else
            {
                chosenCategory = travel;
            }
            quantitySearcher.FillPlaceQuantities(form["placeInput"], chosenCategory);
            chosenCategory.SetPlaceName(form["placeInput"]);
            return View(chosenCategory);
        }
    }
}
