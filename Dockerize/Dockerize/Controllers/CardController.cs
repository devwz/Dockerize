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
    public class CardController : Controller
    {
        ApplicationDbContext context;

        public CardController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<Card>> Get()
        {
            return context.CardContext.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<Card> Get(int id)
        {
            Card card = context.CardContext.Find(id);

            if (card == null)
            {
                return NotFound();
            }

            return card;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Card> Post(Card card)
        {
            context.CardContext.Add(card);
            context.SaveChanges();

            return CreatedAtAction("Get", new { id = card.Id }, card);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<Card> Put(int id, Card card)
        {
            if (id != card.Id)
            {
                return BadRequest();
            }

            context.Entry(card).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult<Card> Delete(int id)
        {
            Card card = context.CardContext.Find(id);

            if (card == null)
            {
                NotFound();
            }

            context.CardContext.Remove(card);
            context.SaveChanges();

            return NoContent();
        }
    }
}
