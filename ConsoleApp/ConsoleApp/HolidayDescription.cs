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

    //internal class HolidayResponse
    //{
    //    //public Result Holiday { get; set; }
    //    //public List<string,HolidayDescription> Holiday { get; set; }
    //    public List<HolidayDescription> Holiday { get; set; }
    //}
    ////internal class Result
    ////{
    ////    public Dictionary<string, HolidayDescription> Documents { get; set; }
    ////}

    ////internal class Result
    ////{
    ////    //[JsonConverter(typeof(DocumentListConverter))]
    ////    public List<HolidayDescription> Documents { get; set; }
    ////}

    //internal class HolidayDescription
    //{
    //    public string Id { get; set; }
    //    public string Date { get; set; }
    //    public string NameEn { get; set; }
    //    public string NameFr { get; set; }
    //    public string Federal { get; set; }
    //    public string ObservedDate { get; set; }
    //    public object Provinces { get; set; }

    //}



    //public class Rootobject
    //{
    //    public Holiday[] holidays { get; set; }
    //}

    //public class Holiday
    //{
    //    public int id { get; set; }
    //    public string date { get; set; }
    //    public string nameEn { get; set; }
    //    public string nameFr { get; set; }
    //    public int federal { get; set; }
    //    public string observedDate { get; set; }
    //    //public Province[] provinces { get; set; }
    //    public object provinces { get; set; }
    //}

    //public class Province
    //{
    //    public string id { get; set; }
    //    public string nameEn { get; set; }
    //    public string nameFr { get; set; }
    //    public string sourceLink { get; set; }
    //    public string sourceEn { get; set; }
    //}





}

