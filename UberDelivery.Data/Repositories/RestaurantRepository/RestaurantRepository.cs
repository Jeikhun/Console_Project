using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberDelivery.Core.Models;
using UberDelivery.Core.Models.Repositories.RestaurantRepostory;

namespace UberDelivery.Data.Repositories.RestaurantRepository
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
    }
}
