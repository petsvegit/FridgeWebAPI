using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Fridge;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public FridgeInventory Get(string name)
        {

            FridgeWorker myFridge = new FridgeWorker();

            myFridge.AddIngredientToFridge("Falukorv", 10);
            var result = myFridge.GetInventoryItem(name);

            return result;
        }

        // GET api/values/5
        [HttpGet("{name}/{quantity}")]
        public bool Get(string name, double quantity)
        {

            FridgeWorker myFridge = new FridgeWorker();

            myFridge.AddIngredientToFridge("Falukorv", 10);
            var result = myFridge.IsItemAvailable(name, quantity);

            return result;
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
        }
    }
}
