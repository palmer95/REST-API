using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCD_Web_API.DataProvider;
using SCD_Web_API.Models;

namespace SCD_Web_API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IUserDataProvider userDataProvider;

        public ValuesController(IUserDataProvider userDataProvider)
        {
            this.userDataProvider = userDataProvider;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<People>> Get()
        {
            return await this.userDataProvider.GetPeoples();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<People> Get(int Id)
        {
            return await this.userDataProvider.GetPerson(Id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]People person)
        {
            await this.userDataProvider.AddPerson(person);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]People person)
        {
            await this.userDataProvider.UpdatePerson(person);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.userDataProvider.DeletePerson(id);
        }
    }
}
