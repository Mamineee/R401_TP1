using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevisesController : ControllerBase
    {

        public List<Devise> listDevise;

        public DevisesController()
        {
            listDevise = new List<Devise>();
            listDevise.Add(new Devise(1, "Dollar", 1.08));
            listDevise.Add(new Devise(1, "Franc Suisse", 1.07));
            listDevise.Add(new Devise(1, "Yen", 120));
        }
        // GET: api/<DeviseController>
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {

            return listDevise;
        }

        // GET api/<DeviseController>/5
        [HttpGet("{id}", Name = "GetDevise")]
        public ActionResult<Devise> GetById(([FromRoute]int id)
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DeviseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DeviseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
