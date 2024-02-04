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

namespace EventAggregatorApi.Tests.EventTest {
    public class EventBriteServiceTest {

  
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        private readonly Mock<IEventBriteEventRepository> _mockRepo = new Mock<IEventBriteEventRepository>();
        private HttpClient _httpClient;
        private EventBriteEventService _service;

        // Constructor
        public EventBriteServiceTest() {

            // Create a mocked responseMessage that a typical API would return.
            var response = new HttpResponseMessage {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("[{\"name\":\"Event 1\"}, {\"name\":\"Event 2\"}]"),
            };

            // Setting up the Mocked SendAsync behavior. Any HttpRequestMessage and CancelationTokens should be handled.
            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(response);

            // Setting up the HttpClient to use the Mocked MessageHandler we created above so that we do not make any real network request for testing with this httpClient.
            _httpClient = new HttpClient(_mockHttpMessageHandler.Object) {
                BaseAddress = new Uri("https://www.eventbriteapi.com/v3/")
            };

            _service = new EventBriteEventService(_httpClient, _mockRepo.Object);
        }// end constructor

        [Fact]
        public async Task GetAllEventsAsync_ReturnsEvents() {

            // arrange done in the constructor

            // act
            var events = await _service.GetAllEventsAsync();


            // assert
            events.Should().HaveCount(2);


        }

    }// end class
}
