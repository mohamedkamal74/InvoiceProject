using InvoiceProject.Data;
using InvoiceProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceProject.APISControllers
{
    [Route("api/APIInvoice")]
    [ApiController]
    public class APIInvoiceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public APIInvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<APIInvoiceController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.InvoiceTemps.Include(x=>x.Category).Include(x=>x.Product).Where(x=>x.BranchId==2).ToList());
        }

        // GET api/<APIInvoiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<APIInvoiceController>
        [HttpPost]
        public IActionResult Post([FromBody] InvoiceTemp model)
        {
            try
            {
                model.BranchId = 2;
                var result = _context.InvoiceTemps.FirstOrDefault(x => x.CategoryId.Equals(model.CategoryId)
                  && x.ProductId.Equals(model.ProductId));
                if (result == null)
                    _context.InvoiceTemps.Add(model);
                else
                {
                    result.Quantity += model.Quantity;
                    result.Total += model.Price * model.Quantity;
                    _context.InvoiceTemps.Update(result);
                }

                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<APIInvoiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIInvoiceController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _context.InvoiceTemps.FirstOrDefault(x => x.InvoiceId == id && x.BranchId == 2);
                if (result == null)
                    return BadRequest();
                else
                {
                    _context.InvoiceTemps.Remove(result);
                    _context.SaveChanges();
                    return Ok();
                }
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
