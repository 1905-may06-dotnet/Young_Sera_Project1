using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxDomain
{
    public interface ILocationRepository
    {
        void DisposeInstance();
        List<DomLocation> GetLocationList();
        
        
    }
}
