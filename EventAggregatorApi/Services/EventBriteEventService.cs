using EventAggregatorApi.Models;
using EventAggregatorApi.Interfaces;
using EventAggregatorApi.Repositories;

namespace EventAggregatorApi.Services {
    public class EventBriteEventService : IEventBriteEventService{

        private readonly IHttpClientFactory _httpClientFactory;
        private IEventBriteEventRepository _repository;

        public EventBriteEventService(IHttpClientFactory httpClientFactory, IEventBriteEventRepository eventBriteEventRepository) {
            _httpClientFactory = httpClientFactory;
            _repository = eventBriteEventRepository;
        }// end constructor

        public Task<IEnumerable<EventBriteEvent>> GetAllEventsAsync() {
            throw new NotImplementedException();
        }

    }// end class
}
