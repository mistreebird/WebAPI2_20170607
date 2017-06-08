using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI2_20170607.Controllers
{
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
    }

    public class TestController : ApiController
    {
        [Route("Person1/{name}/{age}")]
        [Route("Person1")]
        public IHttpActionResult GetPerson1(string name,int age)
        {
            return Ok(name + '-' + age);
        }

        [Route("Person2")]
        public IHttpActionResult PostPerson2(string name,[FromBody] int age)
        {
            return Ok(name + '-' + age);
        }

        [Route("Person3")]
        public IHttpActionResult PostPerson3(Person person)
        {
            return Ok(person.name + '-' + person.age);
        }

        [Route("Person4")]
        public IHttpActionResult PostPerson4([FromUri] Person person)
        {
            return Ok(person.name + '-' + person.age);
        }
    }
}
