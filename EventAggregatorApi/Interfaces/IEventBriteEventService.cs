using EventAggregatorApi.Models;

namespace EventAggregatorApi.Interfaces {
    public interface IEventBriteEventService {

        public Task<IEnumerable<EventBriteEvent>> GetAllEventsAsync();

    }// end interface
}
