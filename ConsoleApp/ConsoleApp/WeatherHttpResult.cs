using System;

namespace ConsoleApp
{
    internal class WeatherHttpResult
    {
        public string Id { get; set; }
        public string Weather_state_name { get; set; }
        public string Weather_state_abbr { get; set; }
        public string Wind_direction_compass { get; set; }
        public DateTime Created { get; set; }
        public DateTime Applicable_date { get; set; }
        public string Min_temp { get; set; }
        public string Max_temp { get; set; }
        public string The_temp { get; set; }
        public string Wind_speed { get; set; }
        public string Wind_direction { get; set; }
        public string Air_pressure { get; set; }
        public string Humidity { get; set; }
        public string Visibility { get; set; }
        public string Predictability { get; set; }             
    } 
}
