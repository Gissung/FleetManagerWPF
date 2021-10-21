using FleetManager.Desktop.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Desktop.Data.Daos.REST
{
    // TODO: (Step 4) implement data access object for the Locations resource in the FleetManager WebAPI

    // 1. make the class inherit from the BaseDao class and use the relevant data context interface as type parameter
    // 2. implement the IDao interface in the class with the Location model class as type parameter

    class LocationDao : BaseDao<IDataContext<IRestClient>>, IDao<Location>
    {
        public LocationDao(IDataContext<IRestClient> dataContext) : base(dataContext)
        {
        }

        public Location Create(Location model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Location model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> Read()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> Read(Func<Location, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Location model)
        {
            throw new NotImplementedException();
        }
    }
}
