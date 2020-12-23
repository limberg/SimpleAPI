using System;
using System.Text.Json;
using Xunit;
using SimpleAPI.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace SimpleAPI.Test
{
    [Collection("Integration Tests")]
    public class WeatherForecastControllerTests
    {

        private readonly WebApplicationFactory<Startup> _factory;

        public WeatherForecastControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Fact]
        public async Task GetRoot_ReturnSuccessAndWeatherListCount()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("/WeatherForecast");

            //Assert
            response.EnsureSuccessStatusCode();

            Assert.NotNull(response.Content);

            var responseObject = JsonSerializer.Deserialize<List<WeatherForecast>>(
                    await response.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions{PropertyNameCaseInsensitive = true});

            var firstObject = responseObject.FirstOrDefault();

            //Assert.Equal(5,responseObject?.Count);
            Assert.Equal(DateTime.Now.AddDays(1).ToShortDateString(), firstObject.Date.ToShortDateString());
        }
    }
}
