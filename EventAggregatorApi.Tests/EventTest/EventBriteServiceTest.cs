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

namespace EventAggregatorApi.Tests.EventTest {
    public class EventBriteServiceTest {

        [Fact]
        public async Task GetAllEvents_ReturnsEmptyList_WhenNoEventsArePresent() {

            // arrange 
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;
            using var context = new AppDbContext(options);
            var repository = new EventBriteEventRepository(context);

            // act
            

            // assert
           

        }// end GetAllEventsTest

    }// end class
}
