using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevisesController : ControllerBase
    {

        public List<Devise> listDevise = new List<Devise>();

        public DevisesController()
        {
            listDevise.Add(new Devise(1, "Dollar", 1.08));
            listDevise.Add(new Devise(2, "Franc Suisse", 1.07));
            listDevise.Add(new Devise(3, "Yen", 120));
        }
        // GET: api/<DeviseController>
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {

            return listDevise;
        }

        // GET api/<DeviseController>/5
        [HttpGet("{id}", Name = "GetDevise")]
        public ActionResult<Devise> GetById(int id)
        {
            Devise? devise = listDevise.FirstOrDefault((d) => d.Id == id);
            
            if (devise == null)
            {
                return NotFound();
            }
            return devise;
        }

        // POST api/<DeviseController>
        [HttpPost]
        public ActionResult<Devise> Post([FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            listDevise.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }

        // PUT api/<DeviseController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != devise.Id)
            {
                return BadRequest();
            }
            int index = listDevise.FindIndex((d) => d.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            listDevise[index] = devise;
            return NoContent();
        }

        // DELETE api/<DeviseController>/5
        [HttpDelete("{id}")]
        public ActionResult<Devise> Delete(int id)
        {
            Devise? devise = (from d in listDevise where d.Id == id select d).FirstOrDefault();
            // Devise? devise = devises.FirstOrDefault((d) => d.Id == id); //meme chose mais lambda expression
            if (devise == null)
            {
                return NotFound();
            }
            listDevise.Remove(devise);
            return devise;
        }
    }
}
