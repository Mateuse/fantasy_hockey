using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyHockeyAPI.Models;

namespace FantasyHockeyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly FantasyHockeyContext _context;

        public LeaguesController(FantasyHockeyContext context)
        {
            _context = context;
        }

        // GET: api/Leagues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeagueItem>>> GetLeagueItem()
        {
            return await _context.LeagueItem.ToListAsync();
        }

        // GET: api/Leagues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeagueItem>> GetLeagueItem(long id)
        {
            var leagueItem = await _context.LeagueItem.FindAsync(id);

            if (leagueItem == null)
            {
                return NotFound();
            }

            return leagueItem;
        }

        // PUT: api/Leagues/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeagueItem(long id, LeagueItem leagueItem)
        {
            if (id != leagueItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(leagueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeagueItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Leagues
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LeagueItem>> PostLeagueItem(LeagueItem leagueItem)
        {
            _context.LeagueItem.Add(leagueItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeagueItem", new { id = leagueItem.Id }, leagueItem);
        }

        // DELETE: api/Leagues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LeagueItem>> DeleteLeagueItem(long id)
        {
            var leagueItem = await _context.LeagueItem.FindAsync(id);
            if (leagueItem == null)
            {
                return NotFound();
            }

            _context.LeagueItem.Remove(leagueItem);
            await _context.SaveChangesAsync();

            return leagueItem;
        }

        private bool LeagueItemExists(long id)
        {
            return _context.LeagueItem.Any(e => e.Id == id);
        }
    }
}
