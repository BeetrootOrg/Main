namespace ConsoleApp
{
    internal class HolidayResponse
    {
        public HolidayDescription Holiday { get; set; }
    }

    internal class HolidayDescription
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public string NameEn { get; set; }
        public string NameFr { get; set; }
        public string Federal { get; set; }
        public string ObservedDate { get; set; }
        public object Provinces { get; set; }

    }
   
}

