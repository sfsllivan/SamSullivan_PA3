using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.bin.Models;
using api.Models;
using api.bin.Models.interfaces;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class driversController : ControllerBase 
    {
        // GET: api/drivers
        //[EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetDrivers")]
        public List<Drivers> Get()
        {
            IGetAllDrivers readObject = new ReadDriverData();
            return readObject.GetAllDrivers();
        }

        // GET: api/drivers/5
        //[EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetDriver")]
        public Drivers Get(int id)
        {
            IGetDriver readObject = new ReadDriverData();
            return readObject.GetDriver(id);
        }

        // POST: api/drivers
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Drivers value)
        {
            IInsertDriver insertObject = new SaveDriver();
            insertObject.InsertDriver(value);
        }

        // PUT: api/drivers/5
        [HttpPut("{id}")]
        public void Put( [FromBody] Drivers value)
        {
            IEditDriver editObject = new SaveDriver();
            editObject.EditDriver(value);
        }

        // DELETE: api/drivers/5
        [HttpDelete("{id}")]
        public void Delete(Drivers value)
        {
            IDeleteDriver deletetobject = new SaveDriver();
            deletetobject.DeleteDriver(value);
        }
    }
}
