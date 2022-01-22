using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class FoodClient
    {
        private readonly HttpClient _httpClient;

        public FoodClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<object> GetRandomImage(CancellationToken cancellationToken = default)
        {
            //using var response = await _httpClient.GetAsync("https://foodish-api.herokuapp.com/api", cancellationToken);
            using var response = await _httpClient.GetAsync("https://canada-holidays.ca/api/v1/holidays/1", cancellationToken);

            var strResult = await response.Content.ReadAsStringAsync(cancellationToken);




            //var jsonobj = JsonConvert.DeserializeObject<ImageResult>(strResult);
            //var jsonobj = JsonConvert.DeserializeObject(strResult);

            //var jsonobj= JsonConvert.DeserializeObject<List<HolidayDescription>>(strResult);
            //var jsonobj = JsonConvert.DeserializeObject<IList<HolidayDescription>>(strResult);
            //JsonConvert.
            //var query = from p in jsonobj.MyProperty
            //            select new MyObject() { MyProperty = new List<AnotherObject>() { p } };
            //var jobj = JsonConvert.DeserializeObject(jsonobj);
            //var result = ((IEnumerable)jsonobj).Cast<object>().ToList();
            //var jsonobj = strResult;
            //< Dictionary<string, Course> >
            //var jsonobj = JsonConvert.DeserializeObject< Dictionary<string, HolidayDescription> >(strResult);
            //var jsonobj = JsonConvert.DeserializeObject<List<List<HolidayDescription>>>(strResult);
            //var jsonobj = JsonConvert.DeserializeObject<HolidayResponse>(strResult);
            //var strResult2 = JsonConvert.DeserializeObject(strResult);
            //var jsonobj2 = JsonConvert.DeserializeObject(strResult);
            //var jsonobj = JsonConvert.DeserializeObject<HolidayResponse>(jsonobj2.ToString());
            //var jsonobj = JsonConvert.DeserializeObject<HolidayResponse>(strResult);
            var jsonobj = JsonConvert.DeserializeObject<Rootobject>(strResult);
            //<ImageResult>(strResult);
            return jsonobj;
        }

        //public async Task<byte[]> GetImage(ImageResult imageResult, CancellationToken cancellationToken = default)
        //{
        //    using var response = await _httpClient.GetAsync(imageResult.Image, cancellationToken);
        //    return await response.Content.ReadAsByteArrayAsync(cancellationToken);
        //}
    }
}
