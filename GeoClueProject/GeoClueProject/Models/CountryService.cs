﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace GeoClueProject.Models
{
    public class CountryService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CountryService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<string[]> GetCountryList()
        {
            
            var url = $"https://restcountries.eu/rest/v2/all";

            // Make HTTP call
            var json = await httpClientFactory.CreateClient().GetStringAsync(url);

            // Deserialize JSON
            var countries = JsonConvert.DeserializeObject<List<Class1>>(json);

            return countries
                .Select(o => o.name)
                .ToArray();
        }

        public async Task<string> RandomCountryAsync()
        {
            var countryList = await GetCountryList();
            var rnd = new Random();
            var index = rnd.Next(0, 240);
            var country = countryList[index - 1];

            return country;
        }

        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public string name { get; set; }
            public string[] topLevelDomain { get; set; }
            public string alpha2Code { get; set; }
            public string alpha3Code { get; set; }
            public string[] callingCodes { get; set; }
            public string capital { get; set; }
            public string[] altSpellings { get; set; }
            public string region { get; set; }
            public string subregion { get; set; }
            public int population { get; set; }
            public float?[] latlng { get; set; }
            public string demonym { get; set; }
            public float? area { get; set; }
            public float? gini { get; set; }
            public string[] timezones { get; set; }
            public string[] borders { get; set; }
            public string nativeName { get; set; }
            public string numericCode { get; set; }
            public Currency[] currencies { get; set; }
            public Language[] languages { get; set; }
            public Translations translations { get; set; }
            public string flag { get; set; }
            public Regionalbloc[] regionalBlocs { get; set; }
            public string cioc { get; set; }
        }

        public class Translations
        {
            public string de { get; set; }
            public string es { get; set; }
            public string fr { get; set; }
            public string ja { get; set; }
            public string it { get; set; }
            public string br { get; set; }
            public string pt { get; set; }
            public string nl { get; set; }
            public string hr { get; set; }
            public string fa { get; set; }
        }

        public class Currency
        {
            public string code { get; set; }
            public string name { get; set; }
            public string symbol { get; set; }
        }

        public class Language
        {
            public string iso639_1 { get; set; }
            public string iso639_2 { get; set; }
            public string name { get; set; }
            public string nativeName { get; set; }
        }

        public class Regionalbloc
        {
            public string acronym { get; set; }
            public string name { get; set; }
            public string[] otherAcronyms { get; set; }
            public string[] otherNames { get; set; }
        }
    }
}
