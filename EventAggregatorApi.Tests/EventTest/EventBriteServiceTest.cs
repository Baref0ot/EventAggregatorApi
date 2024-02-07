using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventAggregatorApi.Controllers;
using Moq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using EventAggregatorApi.Data;
using EventAggregatorApi.Repositories;
using System.Drawing.Text;
using EventAggregatorApi.Interfaces;
using EventAggregatorApi.Services;
using Moq.Protected;
using System.Net;
using EventAggregatorApi.Models;

namespace EventAggregatorApi.Tests.EventTest {
    public class EventBriteServiceTest {

        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock = new Mock<IHttpClientFactory>();
        private readonly Mock<IEventBriteEventRepository> _eventBriteRepositoryMock = new Mock<IEventBriteEventRepository>();
        private readonly EventBriteEventService _eventBriteService;
         
        public EventBriteServiceTest() {

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            // dummy JSON 
            var jsonContent = @"{
              ""categories"": [
                {
                  ""id"": ""103"",
                  ""name"": ""Music"",
                  ""name_localized"": ""Music"",
                  ""short_name"": ""Music"",
                  ""short_name_localized"": ""Music""
                }
              ]
            }";

            // Mocked http request and response
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
                });

            // create an httpClient Object
            var client = new HttpClient(mockHttpMessageHandler.Object) {
                BaseAddress = new Uri("https://www.eventbriteapi.com/v3/")
            };

            // Sets up the mocked HttpClientFactory to return a pre-configured HttpClient instance whenever CreateClient is called with any string argument.
            // This ensures that all HTTP requests made through this factory within the test context use the mocked HttpClient,
            // allowing for controlled testing of HTTP interactions without actual network calls.
            _httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            // EventBriteEventService constructor accepts an HttpClientFactory and IEventBriteEventRepository
            _eventBriteService = new EventBriteEventService(_httpClientFactoryMock.Object, _eventBriteRepositoryMock.Object);
        
        }// end construnctor


                 

        [Fact]
        public async Task EventService_GetEventCategoriesAsync_ReturnsCategoryList() {

            // arrange done in the constructor

            // act
            var result = await _eventBriteService.GetEventCategoriesAsync();

            // assert
            result.Should().BeOfType<List<Category>>();

        }

    }// end class
}
