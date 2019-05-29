using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaBoxDomain;

namespace PizzaBoxData
{
    public class LocationRepository : ILocationRepository
    {
        public List<DomLocation> GetLocationList()
        {
            List<Location> inLocations = DBSingle.Instance.dbInstance.Location.ToList();
            List<DomLocation> outLocations = new List<DomLocation>();
            foreach(var l in inLocations)
            {
                outLocations.Add(DataDomainMapper.Location2DomLocation(l));
            }
            return outLocations;
        }

        public void DisposeInstance()
        {
            DBSingle.Instance.ResetInstance();
        }
    }
}
