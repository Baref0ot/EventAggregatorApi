using Microsoft.EntityFrameworkCore;
using EventAggregatorApi.Models;
using EventAggregatorApi.Interfaces;
using EventAggregatorApi.Data;

namespace EventAggregatorApi.Repositories {
    public class EventBriteEventRepository : IEventBriteEventRepository{

        private AppDbContext _context;

        public EventBriteEventRepository(AppDbContext context) {
            _context = context;
        }


    }// end class
}
