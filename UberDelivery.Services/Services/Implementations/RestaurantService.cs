using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberDelivery.Core.Enums;
using UberDelivery.Core.Models;
using UberDelivery.Core.Models.Repositories.RestaurantRepostory;
using UberDelivery.Data.Repositories.RestaurantRepository;
using UberDelivery.Services.Interfaces;

namespace UberDelivery.Services.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository = new RestaurantRepository();

        public async Task<string> CreateAsync(string name, RestaurantCategory restaurantCategory)
        {
            Restaurant restaurant = new Restaurant(restaurantCategory, name);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            await _restaurantRepository.AddAsync(restaurant);
            return "Succesfully Created";
            Console.Clear();
        }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            return await _restaurantRepository.GetAllAsync();
        }

        public async Task<Restaurant> GetAsync(int id)
        {
            Restaurant restaurant = await _restaurantRepository.GetAsync(x => x.Id == id);
            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restaurant is not found ");
                return null;
            }
            return restaurant;
        }

        public async Task<string> RemoveAsync(int id)
        {
            Restaurant restaurant = await _restaurantRepository.GetAsync(x => x.Id == id);
            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restaurant is not found ");
                return null;
            }
            await _restaurantRepository.RemoveAsync(restaurant);
            return "Succesfully Removed ";
        }


        public async Task<string> UpdateAsync(int id, string name)
        {
            Restaurant restaurant = await _restaurantRepository.GetAsync(x => x.Id == id);
            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restaurant is not found");
                return null;
            }
            restaurant.Name = name;

            await _restaurantRepository.UpdateAsync(restaurant);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Succesfully Updated";
        }
    }
}
