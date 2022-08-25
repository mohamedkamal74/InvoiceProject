using InvoiceProject.Data;
using InvoiceProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceProject.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiInvoiceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiInvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ApiInvoiceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ApiInvoiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiInvoiceController>
        [HttpPost]
        public IActionResult Post([FromBody] InvoiceTemp model)
        {
            try
            {
                _context.InvoiceTemps.Add(model);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ApiInvoiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiInvoiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
