using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace UnitTest
{
    public class ValuesControllerIntegrationTest : BaseIntegrationTest
    {
        private const string BaseUrl = "/api/values";

        public ValuesControllerIntegrationTest(BaseTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task GetShouldReturnValues()
        {
            var response = await Client.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();

            var dataString = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<string>>(dataString);

            Assert.Equal(data.Count, 4);
            Assert.Contains(data, x => x == "a");
            Assert.Contains(data, x => x == "b");
            Assert.Contains(data, x => x == "c");
            Assert.Contains(data, x => x == "d");
        }
    }
}