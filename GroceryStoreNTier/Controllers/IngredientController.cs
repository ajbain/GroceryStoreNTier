﻿using GroceryStore.Models;
using GroceryStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroceryStoreNTier.Controllers
{
    public class IngredientController : ApiController
    {
        private IngredientService CreateIngredientService()
        {
            var ingredientService = new IngredientService();
            return ingredientService;
        }

        public IHttpActionResult Get()
        {
            IngredientService ingredientService = CreateIngredientService();
            var ingredients = ingredientService.GetIngredients();
            return Ok(ingredients);
        }
        public IHttpActionResult Post(IngredientCreate ingredient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateIngredientService();
            if (!service.CreateIngredient(ingredient))
                return InternalServerError();
            return Ok();
        }
    }
}