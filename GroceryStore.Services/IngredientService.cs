﻿using GroceryStore.Data;
using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Services
{
    public class IngredientService
    {
        public bool CreateIngredient(IngredientCreate model)
        {
            var entity =
                new Ingredients()
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    Price = model.Price,
                    UPC = model.UPC
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<IngredientListItem> GetIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Ingredients
                    .Select(
                        e =>
                    new IngredientListItem
                    {
                        IngredientId = e.Id,
                        Name = e.Name,
                    }
                    );
                return query.ToArray();
            }
        }
    }
}