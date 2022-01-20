using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Text.Json;

namespace ConsoleApp
{
    public class JWSTTrackingData
    {
        public float distanceEarthKm { get; set; }
        public string launchElapsedTime { get; set; }
        public float distanceL2Km { get; set; }
        public float percentageCompleted { get; set; }
        public float speedKmS { get; set; }
        public string deploymentImgURL { get; set; }
        public string currentDeploymentStep { get; set; }
        public Tempc tempC { get; set; }
        public DateTime timestamp { get; set; }
    }

    public class Tempc
    {
        public float tempWarmSide1C { get; set; }
        public float tempWarmSide2C { get; set; }
        public float tempCoolSide1C { get; set; }
        public float tempCoolSide2C { get; set; }
    }
    internal class JamesWebbClient
    {
        private readonly HttpClient _httpClient;

        public JamesWebbClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<byte[]> GetData(CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync("https://api.jwst-hub.com/track", cancellationToken);
            if((response == null) || (response.ReasonPhrase != "OK"))
            {
                throw new Exception("Error: response // " + (response.ReasonPhrase != null ? response.ReasonPhrase : " "));
            }
            string strResult = await response.Content.ReadAsStringAsync(cancellationToken);
            if ((strResult == null) || (strResult.Length == 0))
            {
                throw new Exception("Error: strResult!");
            }
           
            JWSTTrackingData  _jwst = JsonSerializer.Deserialize<JWSTTrackingData>(strResult);
            if ((_jwst != null) && (_jwst.deploymentImgURL != null))
            {
                ShowParsedData(_jwst);
            }
            else
            {
                throw new Exception("Error: Parse data!");
            }

            using var responseDeploymentImg = await _httpClient.GetAsync(_jwst.deploymentImgURL, cancellationToken);
            var strResultDeploymentImg = await responseDeploymentImg.Content.ReadAsByteArrayAsync(cancellationToken);

            return strResultDeploymentImg;
        }

        private static void ShowParsedData(JWSTTrackingData _jwst)
        {
            WriteLine($"\r\nLaunch Elapsed Time: {_jwst.launchElapsedTime}");
            WriteLine($"Distance from Earth: {_jwst.distanceEarthKm} Km");
            WriteLine($"Distance to L2 Orbit: {_jwst.distanceL2Km} Km");
            WriteLine($"Distance Complete: {_jwst.percentageCompleted} %");
            WriteLine($"Cruising Speed: {(_jwst.speedKmS * 1000.0).ToString("F1")} m/S");
            // WriteLine($"deploymentImgURL: {_jwst.deploymentImgURL}");
            WriteLine($"Current Deployment Step: {_jwst.currentDeploymentStep}");
            WriteLine($"Temperature WarmSide: 1C {_jwst.tempC.tempWarmSide1C}°C, 2C {_jwst.tempC.tempWarmSide2C}°C");
            WriteLine($"Temperature CoolSide: 1C {_jwst.tempC.tempCoolSide1C}°C, 2C {_jwst.tempC.tempCoolSide2C}°C");
            WriteLine($"timestamp: {_jwst.timestamp}\r\n");
            /*
            Response example data:
            LaunchElapsedTime: 24:08:47:13
            Distance from Earth: 1347301.5 Km
            Distance to L2 Orbit: 99030.1 Km
            Distance Complete: 93.1528 %
            Cruising Speed: 247.5 m/S
            currentDeploymentStep: Mirror Segment Deployment Tracker - undefined
            Temperature WarmSide: 1C 56°C, 2C 10°C
            Temperature CoolSide: 1C -207°C, 2C -201°C
            timestamp: 18-Jan-22 21:07:13
            */
        }

    }
}
/*
 string jsonString2 = "{" +
                "\"distanceEarthKm\":1345647.2," +
                "\"launchElapsedTime\":\"24:06:55:55\"," +
                "\"distanceL2Km\":100684.3," +
                "\"percentageCompleted\":93.0384," +
                "\"speedKmS\":0.2483," +
                "\"deploymentImgURL\":\"https://webb.nasa.gov/content/webbLaunch/assets/images/mirrorMoves/mirrorAlignmentTracker-1-18-22-1-1000px.png\"," +
                "\"currentDeploymentStep\":\"Mirror Segment Deployment Tracker - undefined\"," +
                "\"tempC\":{" +
                "\"tempWarmSide1C\":56," +
                "\"tempWarmSide2C\":10," +
                "\"tempCoolSide1C\":-207," +
                "\"tempCoolSide2C\":-201}," +
                "\"timestamp\":\"2022-01-18T19:15:55.975Z\"}";
            JWSTTrackingData _jwst = System.Text.Json.JsonSerializer.Deserialize<JWSTTrackingData>(jsonString2);
 */
