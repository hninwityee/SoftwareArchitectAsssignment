using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Transaction.Entities;
using Transaction.Services.Interfaces;

namespace Transaction.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
         public List<TransactionOutputEntity> Get([FromQuery] string currency, [FromQuery] string fromDate, [FromQuery] string toDate, [FromQuery] string status)
        {
            // return 
            return _transactionService.GetTransactions(currency, fromDate, toDate, status);

            //return "value";
        }

        [HttpGet]
        [Route("GetTransactionByCurrency")]
        public List<TransactionOutputEntity> GetByCurrency([FromQuery] string currency)
        {
            // return 
            return _transactionService.GetTransactionsByCurrency(currency );

            //return "value";
        }

        [HttpGet]
        [Route("GetTransactionByStatus")]
        public List<TransactionOutputEntity> GetByStatus([FromQuery] string status)
        {
            // return 
            return _transactionService.GetTransactionsByStatus(status);

            //return "value";
        }

        [HttpGet]
        [Route("GetTransactionByDateRange")]
        public List<TransactionOutputEntity> GetByDateRange([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            // return 
            return _transactionService.GetTransactionsByDateRange(fromDate,toDate);

            //return "value";
        }

    }
}
