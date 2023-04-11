using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using PoCReportOData;

namespace PoCReportOData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutPutCustomersController : ControllerBase
    {
        private readonly ReadingContext _context;

        public OutPutCustomersController(ReadingContext context)
        {
            _context = context;
        }

		// GET: api/OutPutCustomers
		[EnableQuery]
		[HttpGet]
        public async Task<ActionResult<IEnumerable<OutPutCustomer>>> GetOutPutCustomer()
        {
			var data =  await _context.OutPutCustomer.FromSqlRaw("GetCustomers").ToListAsync();
            return Ok(data);
			//return await _context.OutPutCustomer.ToListAsync();
        }

        // GET: api/OutPutCustomers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OutPutCustomer>> GetOutPutCustomer(int id)
        {
          if (_context.OutPutCustomer == null)
          {
              return NotFound();
          }
            var outPutCustomer = await _context.OutPutCustomer.FindAsync(id);

            if (outPutCustomer == null)
            {
                return NotFound();
            }

            return outPutCustomer;
        }


        private bool OutPutCustomerExists(int id)
        {
            return (_context.OutPutCustomer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
