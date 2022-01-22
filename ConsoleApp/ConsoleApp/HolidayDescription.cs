using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConsoleApp
{

    public class Rootobject
    {
        public Holiday[] holidays { get; set; }


    }

    public class Holiday
    {
        public int id { get; set; }
        public string date { get; set; }
        public string nameEn { get; set; }
        public string nameFr { get; set; }
        public int federal { get; set; }
        public string observedDate { get; set; }
        public Province[] provinces { get; set; }
    }

    public class Province
    {
        public string id { get; set; }
        public string nameEn { get; set; }
        public string nameFr { get; set; }
        public string sourceLink { get; set; }
        public string sourceEn { get; set; }
    }

}

