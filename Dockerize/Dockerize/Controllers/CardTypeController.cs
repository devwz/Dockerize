using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dockerize.Core;
using Dockerize.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dockerize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardTypeController : Controller
    {
        ApplicationDbContext context;

        public CardTypeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<CardType>> Get()
        {
            return context.CardTypeContext.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<CardType> Get(int id)
        {
            CardType cardType = context.CardTypeContext.Find(id);

            if (cardType == null)
            {
                return NotFound();
            }

            return cardType;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<CardType> Post(CardType cardType)
        {
            context.CardTypeContext.Add(cardType);
            context.SaveChanges();

            return CreatedAtAction("Get", new { id = cardType.Id }, cardType);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<CardType> Put(int id, CardType cardType)
        {
            if (id != cardType.Id)
            {
                return BadRequest();
            }

            context.Entry(cardType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult<CardType> Delete(int id)
        {
            CardType cardType = context.CardTypeContext.Find(id);

            if (cardType == null)
            {
                return NotFound();
            }

            context.CardTypeContext.Remove(cardType);
            context.SaveChanges();

            return NoContent();
        }
    }
}
