using System;
using UberDelivery.Services.Services.Implementations;

namespace UberDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MenuService menuService = new MenuService();

            menuService.ShowMenuAsync();
        }
    }
}
