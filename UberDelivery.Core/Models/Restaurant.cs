using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberDelivery.Core.Enums;
using UberDelivery.Core.Models.Base;

namespace UberDelivery.Core.Models
{
    public class Restaurant : BaseModel
    {
        private static int _id;
        public string Name { get; set; }

        public RestaurantCategory RestaurantCategory { get; set; }

        public List<Product> Products;


        public Restaurant(RestaurantCategory restaurantCategory, string name)
        {
            _id++;
            Id = _id;
            Products = new List<Product>();
            Name = name;
            RestaurantCategory = restaurantCategory;


        }
    }
}
