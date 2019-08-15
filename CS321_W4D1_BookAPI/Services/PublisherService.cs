using System.Collections.Generic;
using System.Linq;
using CS321_W4D1_BookAPI.Data;
using CS321_W4D1_BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W4D1_BookAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly BookContext _bookContext;

        public PublisherService(BookContext bookcontext)
        {
            _bookContext = bookcontext;
        }

        public Publisher Add(Publisher publisher)
        {
            _bookContext.Publishers.Add(publisher);
            _bookContext.SaveChanges();
            return publisher;
        }

        public Publisher Get(int id)
        {
            return _bookContext.Publishers.Find(id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _bookContext.Publishers.ToList();
        }

        public Publisher Update(Publisher updatedPublisher)
        {
            Publisher currentPub = _bookContext.Publishers.Find(updatedPublisher.Id);
            _bookContext
                .Entry(currentPub)
                .CurrentValues
                .SetValues(updatedPublisher);
            _bookContext.Publishers.Update(currentPub);
            _bookContext.SaveChanges();
            return currentPub;
        }

        public void Remove(Publisher publisher)
        {
            _bookContext.Publishers.Remove(publisher);
            _bookContext.SaveChanges();

        }
    }
}
