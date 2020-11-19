using GroceryStore.Models.Transaction;
using GroceryStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroceryStoreNTier.Controllers
{
    public class TransactionController : ApiController
    {
        private TransactionService CreateTransactionService()
        {
            var transactionService = new TransactionService();
            return transactionService;
        }

        public IHttpActionResult Get()
        {
            TransactionService transactionService = CreateTransactionService();
            var transactions = transactionService.GetTransactions();
            return Ok(transactions);
        }
        public IHttpActionResult Post(TransactionCreate transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateTransactionService();
            if (!service.CreateTransaction(transaction))
                return InternalServerError();
            return Ok();
        }
    }
}
