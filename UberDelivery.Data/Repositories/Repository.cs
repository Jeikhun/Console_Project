﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberDelivery.Core.Models.Base;
using UberDelivery.Core.Models.Repositories;

namespace UberDelivery.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private static List<T> _items = new List<T>();
        public List<T> Items { get { return _items; } }
        public async Task AddAsync(T model)
        {
            Items.Add(model);
        }

        public async Task<T> GetAsync(Func<T, bool> expression)
        {
            return Items.FirstOrDefault(expression);
        }
        public async Task<List<T>> GetAllAsync()
        {
            return Items;
        }

        public async Task UpdateAsync(T model)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].Id == model.Id)
                {
                    _items[i] = model;
                }
            }
        }

        public async Task RemoveAsync(T model)
        {
            Items.Remove(model);
        }

        
    }
}
