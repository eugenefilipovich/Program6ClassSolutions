using FlickrNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace API_Access.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MapSearch()
        {
            // Get lat/lon from search term using OpenStreetMaps Nominatum
            string searchTerm = Request.Form["searchTerm"];
            if (searchTerm != null)
            {
                string reqURL = "http://nominatim.openstreetmap.org/search?q=" + searchTerm + "&format=json&polygon=0&addressdetails=0&limit=1";
                double[] coords = GetLocation(reqURL);

                // Connect to Flickr API
                Flickr flickrObj = new Flickr("40852f65c997ac5fd1128a360fcae04d", "15ab386cd8a20bf5");
                PhotoSearchOptions options = new PhotoSearchOptions();
                // set the search criteria using the results from Nominatum
                options.MediaType = MediaType.Photos; // Only get photos
                options.HasGeo = true; // needs to have geo coordinates
                options.ContentType = ContentTypeSearch.PhotosOnly; // only photos
                options.SafeSearch = SafetyLevel.Safe; // safe photos onl
                options.MinTakenDate = DateTime.Today.AddDays(-60); // pictures from the last 60 days
                options.Latitude = coords[0];
                options.Longitude = coords[1];
                options.Radius = 32; //max in km (default unit)
                options.Extras = PhotoSearchExtras.Geo; // need to get lat/lon
                options.Extras = PhotoSearchExtras.All; // Need to get all to get the photo dimensions
                // Get the photos in that bounding box
                PhotoCollection photos = flickrObj.PhotosSearch(options);
                ViewBag.CenterCoord = string.Join(",", coords); // pass the center lat/lon coords for the maps
                return View(photos);
            }
            else
            {
                // return generic review if no term is entered
                return View();
            }
        }
        /// <summary>
        /// A method used to get the lat and long of a common name string
        /// </summary>
        /// <param name="reqURI">Nominatum url with search term included</param>
        /// <returns>returns lat, long</returns>
        private double[] GetLocation(string reqURI)
        {
            // Store the coords for the bounding box that flickr will need
            double[] result = new double[2];
            // For more info:
            // https://msdn.microsoft.com/en-us/library/hh674188.aspx

            try
            {
                // make request
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(reqURI);
                // get response
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Bad request
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        // throw error
                        throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                    }
                    // Good request, get data from JSON response
                    string test = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                    // parse the JSON
                    JArray jsonResult = JArray.Parse(test);
                    // get the lat/lon values

                    result[0] = Convert.ToDouble((string)jsonResult[0]["lat"]);
                    result[1] = Convert.ToDouble((string)jsonResult[0]["lon"]);
                    // ***************************************
                    // ******** YOUR CODE GOES HERE **********
                    // ***************************************

                    // need to return double[] array with lat at [0] and lon at [1]
                    return result;
                }
            }
            catch (Exception e)
            {
                // request errored, return nothing
                return null;
            }
        }
    }
}