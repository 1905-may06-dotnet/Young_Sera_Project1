using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaBoxDomain;

namespace PizzaBoxData
{
    public class LocationRepository : ILocationRepository
    {
        private PizzaBoxContext _db;
        public LocationRepository(PizzaBoxContext db)
        {
            _db = db;
        }
        ~LocationRepository()
        {
            _db.Dispose();
        }
        public List<DomLocation> GetLocationList()
        {
            List<Location> inLocations = _db.Location.ToList();
            List<DomLocation> outLocations = new List<DomLocation>();
            foreach(var l in inLocations)
            {
                outLocations.Add(DataDomainMapper.Location2DomLocation(l));
            }
            return outLocations;
        }

        public DomLocation GetLocation(int id)
        {
            return DataDomainMapper.Location2DomLocation(_db.Location.Where(l => l.Id == id).First());
        }
        public void DisposeInstance()
        {
            
        }
    }
}
