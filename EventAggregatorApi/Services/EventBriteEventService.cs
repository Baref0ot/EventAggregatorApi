using EventAggregatorApi.Models;
using EventAggregatorApi.Interfaces;
using EventAggregatorApi.Repositories;

namespace EventAggregatorApi.Services {
    public class EventBriteEventService : IEventBriteEventService{

        private readonly HttpClient _httpClient;
        private IEventBriteEventRepository _repository;

        public EventBriteEventService(HttpClient httpClient, IEventBriteEventRepository eventBriteEventRepository) {
            _httpClient = httpClient;
            _repository = eventBriteEventRepository;
        }// end constructor

        public Task<IEnumerable<EventBriteEvent>> GetAllEventsAsync() {
            throw new NotImplementedException();
        }

    }// end class
}
