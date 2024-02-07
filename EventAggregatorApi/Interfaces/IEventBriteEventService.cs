using EventAggregatorApi.Models;

namespace EventAggregatorApi.Interfaces {
    public interface IEventBriteEventService {

        public Task<IEnumerable<Category>> GetEventCategoriesAsync();

    }// end interface
}
