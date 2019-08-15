using System;
using CS321_W4D1_BookAPI.Models;
using CS321_W4D1_BookAPI.ApiModels;
using CS321_W4D1_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Routing;

namespace CS321_W4D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var publisherModels = _publisherService
                .GetAll()
                .ToApiModels();

            return Ok(publisherModels);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var publisher = _publisherService
                .Get(id)
                .ToApiModel();
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PublisherModel newPublisher)
        {
            try
            {
                _publisherService.Add(newPublisher.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddPublisher", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newPublisher.Id }, newPublisher);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PublisherModel updatedPublisher)
        {
            var publisher = _publisherService.Update(updatedPublisher.ToDomainModel());
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _publisherService.Get(id);
            if (publisher == null) return NotFound();
            _publisherService.Remove(publisher);
            return NoContent();
        }
    }
}
