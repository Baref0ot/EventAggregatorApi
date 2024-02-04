using Microsoft.EntityFrameworkCore;
using EventAggregatorApi.Models;

namespace EventAggregatorApi.Repositories {
    public class EventBriteEventRepository {

        private DbContext _context;

        public EventBriteEventRepository(DbContext context) {
            _context = context;
        }


    }// end class
}
