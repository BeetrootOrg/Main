using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ConsoleApp.UnitTests
{
    public class JamesWebbClientUnitTests
    {
        private JamesWebbClient jameWebbClient;
        public JamesWebbClientUnitTests()
        {
            jameWebbClient = new JamesWebbClient(new HttpClient { Timeout = TimeSpan.FromSeconds(10) });
        }
        [Fact]
        public void NotNullObject()
        {
            Assert.NotNull(jameWebbClient);
        }

        [Fact]
        public void Deserialize()
        {
            // Arrange
            var jsonTestString = "{" +
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
            // Act
            JWSTTrackingData _jwst = System.Text.Json.JsonSerializer.Deserialize<JWSTTrackingData>(jsonTestString);

            Assert.NotNull(_jwst);
            Assert.NotNull(_jwst.deploymentImgURL);
            Assert.NotNull(_jwst.currentDeploymentStep);
            Assert.NotNull(_jwst.tempC);
            Assert.NotNull(_jwst.timestamp);
        }
    }
}
