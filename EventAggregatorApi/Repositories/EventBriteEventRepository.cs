using Microsoft.EntityFrameworkCore;
using EventAggregatorApi.Models;
using EventAggregatorApi.Interfaces;

namespace EventAggregatorApi.Repositories {
    public class EventBriteEventRepository : IEventBriteEventRepository{

        private DbContext _context;

        public EventBriteEventRepository(DbContext context) {
            _context = context;
        }


    }// end class
}
