using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controller
{
   [Route("api/[controller]")]
   [ApiController]
   [ApiExplorerSettings(IgnoreApi =true)]
   public class ProcedimentoController : ControllerBase
   {
      // GET: api/<Procedimento>
      [HttpGet]
      public IEnumerable<string> Get()
      {
         return new string[] { "value1", "value2" };
      }

      // GET api/<Procedimento>/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
         return "value";
      }

      // POST api/<Procedimento>
      [HttpPost]
      public void Post([FromBody] string value)
      {
      }

      // PUT api/<Procedimento>/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody] string value)
      {
      }

      // DELETE api/<Procedimento>/5
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
      }
   }
}
