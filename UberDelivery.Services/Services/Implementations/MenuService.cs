using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberDelivery.Core.Enums;
using UberDelivery.Core.Models;
using UberDelivery.Services.Interfaces;

namespace UberDelivery.Services.Services.Implementations
{
    public class MenuService : IMenuService

    {
        
        private readonly IRestaurantService _restaurantService = new RestaurantService();
        private readonly IProductService _productService = new ProductService();

        public async Task ShowMenuAsync()
        {
            Helper.PrintSlow("UberDelivery-e xosh gelmisiniz...", ConsoleColor.Green);
            Show();
            int.TryParse(Console.ReadLine(), out int result);
            while (result != 0)
            {
                switch (result)
                {
                    case 1:
                        Console.Clear();
                        await CreateRestaurant();
                        break;
                    case 2:
                        Console.Clear();
                        await ShowAllRestaurant();
                        break;
                    case 3:
                        Console.Clear();
                        await GetRestaurantById();
                        break;
                    case 4:
                        Console.Clear();
                        await UpdateRestaurant();
                        break;
                    case 5:
                        Console.Clear();
                        await RemoveRestaurant();
                        break;
                    case 6:
                        Console.Clear();
                        await CreateProduct();
                        break;
                    case 7:
                        Console.Clear();

                        await ShowAllProducts();
                        break;
                    case 8:
                        Console.Clear();

                        await GetProductById();
                        break;
                    case 9:
                        Console.Clear();
                        await UpdateProduct();
                        break;
                    case 10:
                        Console.Clear();
                        await RemoveProduct();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Helper.Print("Duzgun day daxil edin...", ConsoleColor.Red);
                        break;

                }
                Console.ForegroundColor = ConsoleColor.White;

                Show();
                int.TryParse(Console.ReadLine(), out result);
            }
        }

        private void Show()
        {
            
            Helper.PrintLine("1.Create Restaurant", ConsoleColor.DarkGray);
            Helper.PrintLine("2.Show All Restaurant", ConsoleColor.DarkGray);
            Helper.PrintLine("3.Get Restaurant By Id", ConsoleColor.DarkGray);
            Helper.PrintLine("4.Update Restaurant",ConsoleColor.DarkGray);
            Helper.PrintLine("5.Remove Restaurant", ConsoleColor.DarkGray);
            Helper.PrintLine("6.Create Product", ConsoleColor.DarkGray);
            Helper.PrintLine("7.Show All Product", ConsoleColor.DarkGray);
            Helper.PrintLine("8.Get Product By Id", ConsoleColor.DarkGray);
            Helper.PrintLine("9.Update Product", ConsoleColor.DarkGray);
            Helper.PrintLine("10.Remove Product", ConsoleColor.DarkGray);

        }
        private async Task CreateRestaurant()
        {
            

            await Console.Out.WriteAsync("Name: ");
            string Name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.Write("Please Enter the Name");
                return;
            }
            Helper.PrintLine("Enter Category: ", ConsoleColor.DarkYellow);


            var Enums = Enum.GetValues(typeof(RestaurantCategory));
            foreach (var item in Enums)
            {
                Console.WriteLine((int)item + "." + item);
            }
            int.TryParse(Console.ReadLine(), out int RestaurantCategory);

            try
            {
                Enums.GetValue(RestaurantCategory - 1);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Helper.Print("Duzgun category daxil edin: ", ConsoleColor.Red);
                return;
            }
            string str = await _restaurantService.CreateAsync(Name, (RestaurantCategory)RestaurantCategory);

            Console.WriteLine(str);
        }
        private async Task ShowAllRestaurant()
        {
            List<Restaurant> Restaurants = await _restaurantService.GetAllAsync();
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in Restaurants)
            {
                Console.WriteLine($"Id:{item.Id} Name: {item.Name}  RestaurantCategory: {item.RestaurantCategory}");
            }
        }
        private async Task GetRestaurantById()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Restaurant Id: ");
            int.TryParse(Console.ReadLine(), out int id);
            Restaurant Restaurant = await _restaurantService.GetAsync(id);
            Console.WriteLine($"Id:{Restaurant.Id} Name: {Restaurant.Name} RestaurantCategory: {Restaurant.RestaurantCategory}");
        }

        private async Task UpdateRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Add Restaurant Id: ");
            int.TryParse(Console.ReadLine(), out int id);
            Console.Write("Enter Name: ");
            string Name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Ad daxil edin: ");
                return;
            }


            string str = await _restaurantService.UpdateAsync(id, Name);
            Console.WriteLine(str);
        }
        private async Task RemoveRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Id: ");

            int.TryParse(Console.ReadLine(), out int id);

            string str = await _restaurantService.RemoveAsync(id);
            Console.WriteLine(str);
        }

        private async Task CreateProduct()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(" Please Enter Restaurant Id: ");
            int RestaurantId = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            string Name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Enter Name");
                return;
            }


            Console.WriteLine("Enter price");

            int.TryParse(Console.ReadLine(), out int price);


            Console.WriteLine("Choose Product Category:  ");


            var Enums = Enum.GetValues(typeof(ProductCategory));
            foreach (var item in Enums)
            {
                Console.WriteLine((int)item + "." + item);
            }
            int.TryParse(Console.ReadLine(), out int producttCategory);

            try
            {
                Enums.GetValue(producttCategory - 1);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Restaurant Category is not valid");
                return;
            }



            string str = await _productService.CreateAsync(Name, RestaurantId, price, (ProductCategory)producttCategory);

            Console.WriteLine(str);
        }

        private async Task ShowAllProducts()
        {
            List<Product> products = await _productService.GetAllAsync();

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in products)
            {
                Console.WriteLine($"Id:{item.Id} Name: {item.Name}  ProductCategory: {item.ProductCategory} RestaurantName: {item.Restaurant.Name} ");
            }

        }

        private async Task GetProductById()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter product Id");
            int.TryParse(Console.ReadLine(), out int id);
            Product product = await _productService.GetAsync(id);
            Console.WriteLine($"Id:{product.Id} Name: {product.Name} ProductCategory: {product.ProductCategory} RestoranName: {product.Restaurant.Name}");
        }

        private async Task UpdateProduct()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter Id");

            int.TryParse(Console.ReadLine(), out int Id);
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("*Enter Name");
            string Name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Please Enter Name");
                return;
            }

            Console.WriteLine("Enter Price");
            int.TryParse(Console.ReadLine(), out int price);

            string str = await _productService.UpdateAsync(Id, Name, price);
            Console.WriteLine(str);
        }

        private async Task RemoveProduct()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" Enter Id");

            int.TryParse(Console.ReadLine(), out int id);
            string str = await _productService.RemoveAsync(id);
            Console.WriteLine(str);
        }
    }
}
