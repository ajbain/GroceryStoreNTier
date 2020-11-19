using GroceryStore.Data;
using GroceryStore.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Services
{
    public class TransactionService
    {
        public bool CreateTransaction(TransactionCreate model)
        {
            var entity =
                new Transaction()
                {
                    IngredientId = model.IngredientId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transaction.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Transaction
                    .Select(
                        e =>
                        new TransactionListItem
                        {
                            IngredientId = e.IngredientId,
                            IngredientsName = e.Ingredients.Name
                        });
                return query.ToArray();
            }
        }
    }
}
