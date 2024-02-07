using EventAggregatorApi.Models;
using EventAggregatorApi.Interfaces;
using EventAggregatorApi.Repositories;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EventAggregatorApi.Services {
    public class EventBriteEventService : IEventBriteEventService{

        private readonly HttpClient _httpClient;
        private IEventBriteEventRepository _repository;

        public EventBriteEventService(IHttpClientFactory httpClientFactory, IEventBriteEventRepository eventBriteEventRepository) {
            _httpClient = httpClientFactory.CreateClient("EventBriteClient");
            _repository = eventBriteEventRepository;
        }// end constructor


        public async Task<IEnumerable<Category>> GetEventCategoriesAsync() {

            var response = await _httpClient.GetAsync("categories/");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<CategoryResponse>(content);

            return categories.Categories;

        }// GetEventsByVenueAsync

    }// end class
}
