using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    /// <summary>
    /// Provides the CRUD operations for the currency object 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly List<Currency> _devises;
        
        /// <summary>
        /// Provides the CRUD operations for the currency object
        /// </summary>
        public CurrencyController()
        {
            _devises =
            [
                new Currency(1, "Dollar", 1.08),
                new Currency(2, "Franc Suisse", 1.07),
                new Currency(3, "Yen", 120)
            ];
        }

        /// <summary>
        /// Get All currency
        /// </summary>
        /// <returns>Http Response</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        public IEnumerable<Currency> GetAll()
        {
            return _devises;
        }
        
        
        // GET api/<DevisesController>/5
        /// <summary>
        /// Get a single currency
        /// </summary>
        /// <param name="id">The currency ID</param>
        /// <returns>Http response</returns>
        /// <response code="200"> When the currency ID is found </response>
        /// <response code="404"> When the currency ID is not found </response>
        [HttpGet("{id}", Name = "GetDevise")]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<Currency> Get(int id)
        {
            var d = _devises.FirstOrDefault(d => d.Id == id);
            return d == null ? NotFound() : d;
        }

        // POST api/<DevisesController>
        /// <summary>
        /// Add a currency
        /// </summary>
        /// <param name="value">The currency you want to add</param>
        /// <returns>Http response</returns>
        /// <response code="400">When the body is not a valid currency object</response>
        /// <response code="200">When the body is valid currency object</response>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<Currency> Post([FromBody] Currency value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _devises.Add(value);
            return CreatedAtRoute("GetDevise", new { id = value.Id }, value);
        }

        // PUT api/<DevisesController>/5
        /// <summary>
        /// Delete a currency
        /// </summary>
        /// <param name="id">The currency ID</param>
        /// <param name="value">The currency as an object</param>
        /// <returns>Http response</returns>
        /// <response code="200">When the body is a valid currency object and the ID in parameter and body match</response>
        /// <response code="400">When the body is not a valid currency object or the ID in parameter and body don't match</response>
        /// <response code="404">When the currency ID is not found</response>
        [HttpPut("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<Currency> Put(int id, [FromBody] Currency value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != value.Id)
            {
                return BadRequest();
            }

            int idx = _devises.FindIndex(d => d.Id == id);
            if (idx < 0)
            {
                return NotFound();
            }
            
            _devises[idx] = value;
            return NoContent();
        }

        // DELETE api/<DevisesController>/5
        /// <summary>
        /// Delete a currency
        /// </summary>
        /// <param name="id">The currency ID you want to delete</param>
        /// <returns>Http response</returns>
        /// <response code="404">If the ID you want to delete is not found</response>
        /// <response code="200">If the ID you want to delete is found</response>
        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<Currency> Delete(int id)
        {
            var d = _devises.FirstOrDefault(d => d.Id == id);
            if (d == null)
            {
                return NotFound();
            }
            _devises.Remove(d); 
            return Ok(d);
        }
    }
}
