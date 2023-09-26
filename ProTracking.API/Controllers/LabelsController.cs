﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProTracking.API.Controllers
{
    [ApiController]
    public class LabelsController : BaseController
    {
        // GET: api/<LabelsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LabelsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LabelsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LabelsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LabelsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
