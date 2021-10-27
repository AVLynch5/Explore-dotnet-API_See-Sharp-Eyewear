using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SeeSharp.Models;
using SeeSharp.Services;

namespace SeeSharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GlassesController : ControllerBase
    {
        public GlassesController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Glasses>> GetAll() =>
            GlassesService.GetAll();

        // GET by Id action
[       HttpGet("{id}")]
        public ActionResult<Glasses> Get(int id)
        {
            var glasses = GlassesService.Get(id);

            if(glasses == null)
                return NotFound();

            return glasses;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Glasses glasses)
        {            
            GlassesService.Add(glasses);
            return CreatedAtAction(nameof(Create), new { id = glasses.Id }, glasses);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Glasses glasses)
        {
            if (id != glasses.Id)
                return BadRequest();

            var existingGlasses = GlassesService.Get(id);
            if(existingGlasses is null)
                return NotFound();

            GlassesService.Update(glasses);           

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var glasses = GlassesService.Get(id);

            if (glasses is null)
                return NotFound();

            GlassesService.Delete(id);

            return NoContent();
        }
    }
}