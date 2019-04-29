using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace GeoClueProject.Models
{
    public class ApiImage
    {
        const string ApiKey = "12337311-1f9f60b3e0fe189a322c3a724";

        public async Task<string> Search(string searchPhrase)
        {
            var encodedSearchPhrase = HttpUtility.UrlEncode(searchPhrase);

            var httpClient = new HttpClient();
            var url = $"https://pixabay.com/api/?key={ApiKey}&q={encodedSearchPhrase}&image_type=photo";

            // Make HTTP call
            var json = await httpClient.GetStringAsync(url);

            // Deserialize JSON
            var root = JsonConvert.DeserializeObject<Rootobject>(json);

            return root.hits[0].largeImageURL;


        }


        public class Rootobject
        {
            public int totalHits { get; set; }
            public Hit[] hits { get; set; }
            public int total { get; set; }
        }

        public class Hit
        {
            public string largeImageURL { get; set; }
            public int webformatHeight { get; set; }
            public int webformatWidth { get; set; }
            public int likes { get; set; }
            public int imageWidth { get; set; }
            public int id { get; set; }
            public int user_id { get; set; }
            public int views { get; set; }
            public int comments { get; set; }
            public string pageURL { get; set; }
            public int imageHeight { get; set; }
            public string webformatURL { get; set; }
            public string type { get; set; }
            public int previewHeight { get; set; }
            public string tags { get; set; }
            public int downloads { get; set; }
            public string user { get; set; }
            public int favorites { get; set; }
            public int imageSize { get; set; }
            public int previewWidth { get; set; }
            public string userImageURL { get; set; }
            public string previewURL { get; set; }
        }




    }
}

