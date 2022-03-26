using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XinCataLogSwaggerWebAPI.Data;

namespace XinCataLogSwaggerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XinComicsController : ControllerBase
    {
        private readonly XinCataLogContext _context;

        public XinComicsController(XinCataLogContext context)
        {
            _context = context;
        }

        // GET: api/XinComics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<XinComic>>> GetXinComics()
        {
            return await _context.XinComics.ToListAsync();
        }

        // GET: api/XinComics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<XinComic>> GetXinComic(int id)
        {
            var xinComic = await _context.XinComics.FindAsync(id);

            if (xinComic == null)
            {
                return NotFound();
            }

            return xinComic;
        }

        // PUT: api/XinComics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutXinComic(int id, XinComic xinComic)
        {
            if (id != xinComic.Id)
            {
                return BadRequest();
            }

            _context.Entry(xinComic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XinComicExists(id))
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

        // POST: api/XinComics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<XinComic>> PostXinComic(XinComic xinComic)
        {
            _context.XinComics.Add(xinComic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetXinComic", new { id = xinComic.Id }, xinComic);
        }

        // DELETE: api/XinComics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteXinComic(int id)
        {
            var xinComic = await _context.XinComics.FindAsync(id);
            if (xinComic == null)
            {
                return NotFound();
            }

            _context.XinComics.Remove(xinComic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool XinComicExists(int id)
        {
            return _context.XinComics.Any(e => e.Id == id);
        }
    }
}
