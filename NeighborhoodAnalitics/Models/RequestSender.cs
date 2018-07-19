﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace NeighborhoodAnalitics.Controllers
{

    public class RequestSender
    {
        /// <summary>
        /// API KEY
        /// AIzaSyCIxaqwOzo2dsq8cUsKlkgQcjRH4w1LRRY
        /// ///////////
        /// API KEY 2
        /// AIzaSyCGJanHWRMRKJ1e4JDgDI1yjW2Tze_KtOs
        /// </summary>

        public Place GetLocalisationByName(string placeName)
        {
            string getLocalisationRequestString = 
                $"https://maps.googleapis.com/maps/api/place/findplacefromtext/json?input={placeName}&inputtype=textquery&fields=name,geometry&key=AIzaSyCGJanHWRMRKJ1e4JDgDI1yjW2Tze_KtOs";

            WebRequest Request = WebRequest.Create(getLocalisationRequestString);
            WebResponse response = Request.GetResponse();

            if (((HttpWebResponse)response).StatusDescription == "OK")
            {
                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                reader.Close();
                response.Close();
                return JsonConvert.DeserializeObject<Place>(responseFromServer);
            }
            else
            {
                return null;
            }
        }

        public ListOfResults FindNear(Place searchPlace, string type)
        {
            if (searchPlace != null)
            {

                string nearByRequestString = 
                    $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={searchPlace.Coordinates}&radius=700&type={type}&key=AIzaSyCGJanHWRMRKJ1e4JDgDI1yjW2Tze_KtOs";
                WebRequest Request = WebRequest.Create(nearByRequestString);
                WebResponse response = Request.GetResponse();
                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string jsonResponse = reader.ReadToEnd();

                ListOfResults listOfResults = JsonConvert.DeserializeObject<ListOfResults>(jsonResponse);

                return listOfResults;
            }
            else
            {
                return null;
            }
        }
    }
}
